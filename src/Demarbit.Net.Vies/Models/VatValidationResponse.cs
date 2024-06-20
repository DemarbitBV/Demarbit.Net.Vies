using Demarbit.Net.Vies.Enums;

namespace Demarbit.Net.Vies.Models
{
    /// <summary>
    /// Response model for the VAT number validation through the <see href="https://ec.europa.eu/taxation_customs/vies/#/vat-validation">VIES</see> interface.
    /// </summary>
    public sealed class VatValidationResponse
    {
        /// <summary>
        /// Indication of whether the requested VAT number is valid
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Date and time of the validation request
        /// </summary>
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// Name of the company.
        /// <para>This information might not be present in the VIES database.</para>
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Address of the company.
        /// <para>This information might not be present in the VIES database.</para>
        /// </summary>
        public string Address { get; set; } = null!;

        /// <summary>
        /// The VAT number of the company.
        /// </summary>
        public string VatNumber { get; set; } = null!;

        /// <summary>
        /// The <see cref="EUCountryCodes"/> code of the company.
        /// </summary>
        public EUCountryCodes Country { get; set; }
    }
}
