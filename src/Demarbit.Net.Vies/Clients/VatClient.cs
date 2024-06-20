using Demarbit.Net.Vies.Data;
using Demarbit.Net.Vies.Enums;
using Demarbit.Net.Vies.Models;

namespace Demarbit.Net.Vies.Clients
{
    /// <summary>
	/// Client for accessing VAT information for EU member states
	/// </summary>
	public sealed class VatClient
    {
        private readonly EUVatRates _rates;

        /// <summary>
        /// 
        /// </summary>
        public VatClient()
        {
            _rates = new EUVatRates();
        }

        /// <summary>
        /// Get all available rates for the specified country.
        /// </summary>
        /// <param name="countryCode">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <returns>List of <see cref="VatRate"/> objects.</returns>
        public List<VatRate> GetRatesForCountry(string countryCode)
        {
            return GetRatesForCountry(Enum.Parse<EUCountryCodes>(countryCode));
        }

        /// <summary>
        /// Get all available rates for the specified country
        /// </summary>
        /// <param name="country">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <returns>List of <see cref="VatRate"/> objects.</returns>
        public List<VatRate> GetRatesForCountry(EUCountryCodes country)
        {
            return GetRates(country);
        }

        /// <summary>
        /// Get the standard VAT rate for the specified country.
        /// </summary>
        /// <param name="countryCode">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <returns><see cref="VatRate"/> object.</returns>
        public VatRate GetStandardRateForCountry(string countryCode)
        {
            return GetStandardRateForCountry(Enum.Parse<EUCountryCodes>(countryCode));
        }

        /// <summary>
        /// Get the standard VAT rate for the specified country.
        /// </summary>
        /// <param name="country">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <returns><see cref="VatRate"/> object.</returns>
        public VatRate GetStandardRateForCountry(EUCountryCodes country)
        {
            return GetRates(country, VatRateType.Standard).First();
        }

        /// <summary>
        /// Get all available reduced rates (0 - 2) for the specified country.
        /// </summary>
        /// <param name="countryCode">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <returns>List of <see cref="VatRate"/> objects.</returns>
        public List<VatRate> GetReducedRatesForCountry(string countryCode)
        {
            return GetReducedRatesForCountry(Enum.Parse<EUCountryCodes>(countryCode));
        }

        /// <summary>
        /// Get all available reduced rates (0 - 2) for the specified country.
        /// </summary>
        /// <param name="country">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <returns>List of <see cref="VatRate"/> objects.</returns>
        public List<VatRate> GetReducedRatesForCountry(EUCountryCodes country)
        {
            return GetRates(country, VatRateType.Reduced);
        }

        /// <summary>
        /// Get the super reduced rate for the specified country if available.
        /// </summary>
        /// <param name="countryCode">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <returns><see cref="VatRate"/> object.</returns>
        public VatRate? GetSuperReducedRateForCountry(string countryCode)
        {
            return GetSuperReducedRateForCountry(Enum.Parse<EUCountryCodes>(countryCode));
        }

        /// <summary>
        /// Get the super reduced rate for the specified country if available.
        /// </summary>
        /// <param name="country">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <returns><see cref="VatRate"/> object.</returns>
        public VatRate? GetSuperReducedRateForCountry(EUCountryCodes country)
        {
            return GetRates(country, VatRateType.SuperReduced).FirstOrDefault();
        }

        /// <summary>
        /// Get the parking rate for the specified country if available.
        /// </summary>
        /// <param name="countryCode">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <returns><see cref="VatRate"/> object.</returns>
        public VatRate? GetParkingRateForCountry(string countryCode)
        {
            return GetParkingRateForCountry(Enum.Parse<EUCountryCodes>(countryCode));
        }

        /// <summary>
        /// Get the parking rate for the specified country if available.
        /// </summary>
        /// <param name="country">ISO 2 Code of the country. See <see cref="EUCountryCodes"/> for available options.</param>
        /// <returns><see cref="VatRate"/> object.</returns>
        public VatRate? GetParkingRateForCountry(EUCountryCodes country)
        {
            return GetRates(country, VatRateType.Parking).FirstOrDefault();
        }

        private List<VatRate> GetRates(EUCountryCodes forCountry, VatRateType? forType = null)
        {
            var query = _rates.Where(rate => rate.Country == forCountry);

            if (forType != null)
            {
                query = query.Where(rate => rate.Type == forType);
            }

            return query.ToList();
        }
    }
}
