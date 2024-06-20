using Demarbit.Net.Vies.Enums;
using Demarbit.Net.Vies.Models.Internal;
using Demarbit.Net.Vies.Models;
using Demarbit.Net.Vies.Exceptions;
using System.Text.Json;

namespace Demarbit.Net.Vies.Clients
{
    /// <summary>
	/// Client for requesting a VAT number validation from the VIES service.
	/// </summary>
	public sealed class ViesClient : IDisposable
    {
        private const string MAX_CONCURRENT_REQ_ERROR = "MS_MAX_CONCURRENT_REQ";
        private const int MAX_NUMBER_OF_RETRIES = 3;
        private const int RETRY_DELAY = 500;

        private readonly HttpClient _client;

        /// <summary>
        /// 
        /// </summary>
        public ViesClient()
        {
            _client = SetupClient();
        }

        /// <summary>
        /// Validate a VAT number for a specific country.
        /// </summary>
        /// <param name="countryCode">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <param name="vatNumber">The VAT number to validate</param>
        /// <param name="allowRetries">Allow retry of request in case of maximum concurrent requests errors (MS_MAX_CONCURRENT_REQ). Default is <c>true</c>. Note: this introduces a delay to ensure that the error does not persist in the next run. A maximum of 3 retries are executed.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="VatValidationResponse"/> object.</returns>
        public async Task<VatValidationResponse> ValidateVatNumberAsync(string countryCode, string vatNumber, bool allowRetries = true, CancellationToken cancellationToken = default)
        {
            var country = (EUCountryCodes)Enum.Parse(typeof(EUCountryCodes), countryCode);

            return await ValidateVatNumberAsync(country, vatNumber, allowRetries, cancellationToken);
        }

        /// <summary>
        /// Validate a VAT number for a specific country.
        /// </summary>
        /// <param name="country">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <param name="vatNumber">The VAT number to validate.</param>
        /// <param name="allowRetries">Allow retry of request in case of maximum concurrent requests errors (MS_MAX_CONCURRENT_REQ). Default is <c>true</c>. Note: this introduces a delay to ensure that the error does not persist in the next run. A maximum of 3 retries are executed.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="VatValidationResponse"/> object.</returns>
        /// <exception cref="ViesRequestException"></exception>
        /// <exception cref="ViesModelException"></exception>
        public async Task<VatValidationResponse> ValidateVatNumberAsync(EUCountryCodes country, string vatNumber, bool allowRetries = true, CancellationToken cancellationToken = default)
        {
            int numberOfRetries = 0;
            int allowedNumberOfRetries = allowRetries ? MAX_NUMBER_OF_RETRIES : 0;

            while (numberOfRetries <= allowedNumberOfRetries)
            {
                var viesResponse = await ExecuteValidationRequestAsync(country, vatNumber, cancellationToken);

                if (viesResponse.UserError != MAX_CONCURRENT_REQ_ERROR)
                {
                    return GetResponseModel(viesResponse, country);
                }     
                
                await Task.Delay(RETRY_DELAY, cancellationToken);

                numberOfRetries++;
            }

            throw new ViesRequestException("Maximum retries reached");
        }

        private async Task<ViesResponse> ExecuteValidationRequestAsync(EUCountryCodes country, string vatNumber, CancellationToken cancellationToken = default)
        {
            vatNumber = vatNumber.Replace(" ", "")
                .Replace(".", "")
                .Replace(country.ToString(), "")
                .Trim();

            var response = await _client.GetAsync($"{country}/vat/{vatNumber}", cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new ViesRequestException($"An error occured fetching VAT information from VIES: {response.ReasonPhrase}");
            }

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken)
                ?? throw new ViesRequestException("Unable to read response content from VAT information request.");

            var viesResponse = JsonSerializer.Deserialize<ViesResponse>(responseContent)
                ?? throw new ViesModelException("Could not deserialize expected VIES model from response content of the VAT information request.");

            return viesResponse;
        }

        private static VatValidationResponse GetResponseModel(ViesResponse fromResponse, EUCountryCodes withCountry) => new VatValidationResponse
        {
            Address = fromResponse.Address,
            Country = withCountry,
            IsValid = fromResponse.IsValid,
            Name = fromResponse.Name,
            RequestDate = fromResponse.RequestDate,
            VatNumber = fromResponse.VatNumber,
        };

        #region IDisposable implementation
        public void Dispose()
        {
            GC.SuppressFinalize(this);

            _client.Dispose();
        }
        #endregion

        #region Setup
        private static HttpClient SetupClient()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://ec.europa.eu/taxation_customs/vies/rest-api/ms/")
            };

            return client;
        }
        #endregion
    }
}
