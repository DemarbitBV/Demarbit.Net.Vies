using Demarbit.Net.Vies.Enums;
using Demarbit.Net.Vies.Models;
using System.Diagnostics.CodeAnalysis;

namespace Demarbit.Net.Vies.Data
{
    [ExcludeFromCodeCoverage]
    internal sealed class EUVatRates : List<VatRate>
    {
        public EUVatRates()
        {
            // AT - Austria
            Add(new VatRate(EUCountryCodes.AT, VatRateType.Standard, .20));
            Add(new VatRate(EUCountryCodes.AT, VatRateType.Reduced, .13));
            Add(new VatRate(EUCountryCodes.AT, VatRateType.Reduced, .10));
            Add(new VatRate(EUCountryCodes.AT, VatRateType.Parking, .13));

            // BE - Belgium
            Add(new VatRate(EUCountryCodes.BE, VatRateType.Standard, .21));
            Add(new VatRate(EUCountryCodes.BE, VatRateType.Reduced, .12));
            Add(new VatRate(EUCountryCodes.BE, VatRateType.Reduced, .06));
            Add(new VatRate(EUCountryCodes.BE, VatRateType.Parking, .12));

            // BG - Bulgaria
            Add(new VatRate(EUCountryCodes.BG, VatRateType.Standard, .20));
            Add(new VatRate(EUCountryCodes.BG, VatRateType.Reduced, .09));

            // CY - Cyprus
            Add(new VatRate(EUCountryCodes.CY, VatRateType.Standard, .19));
            Add(new VatRate(EUCountryCodes.CY, VatRateType.Reduced, .09));
            Add(new VatRate(EUCountryCodes.CY, VatRateType.Reduced, .05));

            // CZ - Czechia
            Add(new VatRate(EUCountryCodes.CZ, VatRateType.Standard, .21));
            Add(new VatRate(EUCountryCodes.CZ, VatRateType.Reduced, .15));
            Add(new VatRate(EUCountryCodes.CZ, VatRateType.Reduced, .10));

            // DE - Germany
            Add(new VatRate(EUCountryCodes.DE, VatRateType.Standard, .19));
            Add(new VatRate(EUCountryCodes.DE, VatRateType.Reduced, .07));

            // DK - Denmark
            Add(new VatRate(EUCountryCodes.DK, VatRateType.Standard, .25));

            // EE - Estonia
            Add(new VatRate(EUCountryCodes.EE, VatRateType.Standard, .20));
            Add(new VatRate(EUCountryCodes.EE, VatRateType.Reduced, .09));

            // EL - Greece
            Add(new VatRate(EUCountryCodes.EL, VatRateType.Standard, .24));
            Add(new VatRate(EUCountryCodes.EL, VatRateType.Reduced, .13));
            Add(new VatRate(EUCountryCodes.EL, VatRateType.Reduced, .06));

            // ES - Spain
            Add(new VatRate(EUCountryCodes.ES, VatRateType.Standard, .21));
            Add(new VatRate(EUCountryCodes.ES, VatRateType.Reduced, .10));
            Add(new VatRate(EUCountryCodes.ES, VatRateType.SuperReduced, .04));

            // FI - Finland
            Add(new VatRate(EUCountryCodes.FI, VatRateType.Standard, .24));
            Add(new VatRate(EUCountryCodes.FI, VatRateType.Reduced, .14));
            Add(new VatRate(EUCountryCodes.FI, VatRateType.Reduced, .10));

            // FR - France
            Add(new VatRate(EUCountryCodes.FR, VatRateType.Standard, .20));
            Add(new VatRate(EUCountryCodes.FR, VatRateType.Reduced, .10));
            Add(new VatRate(EUCountryCodes.FR, VatRateType.Reduced, .055));
            Add(new VatRate(EUCountryCodes.FR, VatRateType.SuperReduced, 0.021));

            // HR - Croatia
            Add(new VatRate(EUCountryCodes.HR, VatRateType.Standard, .25));
            Add(new VatRate(EUCountryCodes.HR, VatRateType.Reduced, .13));
            Add(new VatRate(EUCountryCodes.HR, VatRateType.Reduced, .05));

            // HU - Hungary
            Add(new VatRate(EUCountryCodes.HU, VatRateType.Standard, .27));
            Add(new VatRate(EUCountryCodes.HU, VatRateType.Reduced, .18));
            Add(new VatRate(EUCountryCodes.HU, VatRateType.Reduced, .05));

            // IE - Ireland
            Add(new VatRate(EUCountryCodes.IE, VatRateType.Standard, .23));
            Add(new VatRate(EUCountryCodes.IE, VatRateType.Reduced, .135));
            Add(new VatRate(EUCountryCodes.IE, VatRateType.Reduced, .09));
            Add(new VatRate(EUCountryCodes.IE, VatRateType.SuperReduced, 0.048));
            Add(new VatRate(EUCountryCodes.IE, VatRateType.Parking, 0.135));

            // IT - Italy
            Add(new VatRate(EUCountryCodes.IT, VatRateType.Standard, .22));
            Add(new VatRate(EUCountryCodes.IT, VatRateType.Reduced, .10));
            Add(new VatRate(EUCountryCodes.IT, VatRateType.Reduced, .05));
            Add(new VatRate(EUCountryCodes.IT, VatRateType.SuperReduced, 0.04));

            // LT - Lithuania
            Add(new VatRate(EUCountryCodes.LT, VatRateType.Standard, .21));
            Add(new VatRate(EUCountryCodes.LT, VatRateType.Reduced, .09));
            Add(new VatRate(EUCountryCodes.LT, VatRateType.Reduced, .05));

            // LU - Luxembourg
            Add(new VatRate(EUCountryCodes.LU, VatRateType.Standard, .17));
            Add(new VatRate(EUCountryCodes.LU, VatRateType.Reduced, .08));
            Add(new VatRate(EUCountryCodes.LU, VatRateType.SuperReduced, .03));
            Add(new VatRate(EUCountryCodes.LU, VatRateType.Parking, 0.14));

            // LV - Latvia
            Add(new VatRate(EUCountryCodes.LV, VatRateType.Standard, .21));
            Add(new VatRate(EUCountryCodes.LV, VatRateType.Reduced, .12));
            Add(new VatRate(EUCountryCodes.LV, VatRateType.Reduced, .05));

            // MT - Malta
            Add(new VatRate(EUCountryCodes.MT, VatRateType.Standard, .18));
            Add(new VatRate(EUCountryCodes.MT, VatRateType.Reduced, .07));
            Add(new VatRate(EUCountryCodes.MT, VatRateType.Reduced, .05));

            // NL - Netherlands
            Add(new VatRate(EUCountryCodes.NL, VatRateType.Standard, .21));
            Add(new VatRate(EUCountryCodes.NL, VatRateType.Reduced, .09));

            // PL - Poland
            Add(new VatRate(EUCountryCodes.PL, VatRateType.Standard, .23));
            Add(new VatRate(EUCountryCodes.PL, VatRateType.Reduced, .08));
            Add(new VatRate(EUCountryCodes.PL, VatRateType.Reduced, .05));

            // PT - Portugal
            Add(new VatRate(EUCountryCodes.PT, VatRateType.Standard, .23));
            Add(new VatRate(EUCountryCodes.PT, VatRateType.Reduced, .13));
            Add(new VatRate(EUCountryCodes.PT, VatRateType.Reduced, .06));
            Add(new VatRate(EUCountryCodes.PT, VatRateType.Parking, .13));

            // RO - Romania
            Add(new VatRate(EUCountryCodes.RO, VatRateType.Standard, .19));
            Add(new VatRate(EUCountryCodes.RO, VatRateType.Reduced, .09));
            Add(new VatRate(EUCountryCodes.RO, VatRateType.Reduced, .05));

            // SE - Sweden
            Add(new VatRate(EUCountryCodes.SE, VatRateType.Standard, .25));
            Add(new VatRate(EUCountryCodes.SE, VatRateType.Reduced, .12));
            Add(new VatRate(EUCountryCodes.SE, VatRateType.Reduced, .06));

            // SL - Slovenia
            Add(new VatRate(EUCountryCodes.SI, VatRateType.Standard, .22));
            Add(new VatRate(EUCountryCodes.SI, VatRateType.Reduced, .095));
            Add(new VatRate(EUCountryCodes.SI, VatRateType.Reduced, .05));

            // SK - Slovakia
            Add(new VatRate(EUCountryCodes.SK, VatRateType.Standard, .20));
            Add(new VatRate(EUCountryCodes.SK, VatRateType.Reduced, .10));
        }
    }
}
