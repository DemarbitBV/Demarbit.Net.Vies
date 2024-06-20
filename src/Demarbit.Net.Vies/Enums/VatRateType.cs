namespace Demarbit.Net.Vies.Enums
{
    /// <summary>
    /// VAT Rate Type indicator. For more information, see:
    /// <para> - <see href="https://europa.eu/youreurope/business/taxation/vat/vat-rules-rates/index_en.htm#shortcut-6">Standard rates</see></para>
    /// <para> - <see href="https://europa.eu/youreurope/business/taxation/vat/vat-rules-rates/index_en.htm#shortcut-7">Reduced rates</see></para>
    /// <para> - <see href="https://europa.eu/youreurope/business/taxation/vat/vat-rules-rates/index_en.htm#shortcut-8">Special rates</see></para>
    /// </summary>
    public enum VatRateType
    {
        /// <summary>
        /// Standard rate that applies to most goods and services. See <see href="https://europa.eu/youreurope/business/taxation/vat/vat-rules-rates/index_en.htm#shortcut-6">Standard rates</see>.
        /// </summary>
        Standard,

        /// <summary>
        /// Reduced rates that apply to some goods and services (minimum 5%). See <see href="https://europa.eu/youreurope/business/taxation/vat/vat-rules-rates/index_en.htm#shortcut-7">Reduced rates</see>.
        /// </summary>
        Reduced,

        /// <summary>
        /// Super-reduced rates of less that 5% are applied to the sales of limited goods and services in some EU countries. See <see href="https://europa.eu/youreurope/business/taxation/vat/vat-rules-rates/index_en.htm#shortcut-8">Special rates</see>.
        /// </summary>
        SuperReduced,

        /// <summary>
        /// Parking rates are applied by some EU countries to certain supplies of goods and services that aren't included in the Annex III of the VAT directive. See <see href="https://europa.eu/youreurope/business/taxation/vat/vat-rules-rates/index_en.htm#shortcut-8">Special rates</see>.
        /// </summary>
        Parking
    }
}
