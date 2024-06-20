using Demarbit.Net.Vies.Clients;
using Demarbit.Net.Vies.Enums;
using Demarbit.Net.Vies.Models;

namespace Demarbit.Net.Vies.UnitTests
{
    [TestFixture(
        Author = "Nicolas Demarbaix",
        Category = "VAT",
        Description = " Vat client tests",
        TestOf = typeof(VatClient))]
    public class VatClientUnitTests
    {
        private VatClient client;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            client = new VatClient();
        }

        [Test(
            Author = "Nicolas Demarbaix",
            Description = "Check catch of invalid rate values")]
        [TestCase(2)]
        [TestCase(-1)]
        public void TestCatchInvalidRateValue(double testRate)
        {
            Assert.Throws<ArgumentException>(() => new VatRate(EUCountryCodes.BE, VatRateType.Standard, testRate));
        }

        [Test(
            Author = "Nicolas Demarbaix",
            Description = "Get valid rates for country 'BE'")]
        [TestCase("BE", 4)]
        [TestCase("BG", 2)]
        [TestCase("CY", 3)]
        [Parallelizable(ParallelScope.All)]
        public void TestFetchValidRates(string countryCode, int expectedRates)
        {
            Assert.DoesNotThrow(() =>
            {
                var rates = client.GetRatesForCountry(countryCode);

                Assert.Multiple(() =>
                {
                    Assert.That(rates, Is.Not.Null);
                    Assert.That(rates, Has.Count.EqualTo(expectedRates));
                    Assert.That(rates.Count(r => r.Type == Enums.VatRateType.Standard), Is.EqualTo(1));
                });
            });
        }

        [Test(
            Author = "Nicolas Demarbaix",
            Description = "Test fetching valid standard rates")]
        [TestCase("BE", .21)]
        [TestCase("FI", .24)]
        public void TestFetchValidStandardRate(string countryCode, double expectedRate)
        {
            Assert.DoesNotThrow(() =>
            {
                var standardRate = client.GetStandardRateForCountry(countryCode);

                Assert.Multiple(() =>
                {
                    Assert.That(standardRate, Is.Not.Null);
                    Assert.That(standardRate.Country.ToString(), Is.EqualTo(countryCode));
                    Assert.That(standardRate.Rate, Is.EqualTo(expectedRate));
                });
            });
        }

        [Test(
            Author = "NicolasDemarbaix",
            Description = "Get Valid Reduced Rates")]
        [TestCase("AT", .13, .10)]
        [TestCase("BE", .12, .06)]
        [TestCase("EE", .09)]
        public void Test_Vat_FetchValidReducedRates(string countryCode, params double[] expectedRates)
        {
            Assert.DoesNotThrow(() =>
            {
                var reducedRates = client.GetReducedRatesForCountry(countryCode);

                Assert.Multiple(() =>
                {
                    Assert.That(reducedRates, Is.Not.Null);
                    Assert.That(reducedRates, Has.Count.EqualTo(expectedRates.Length));
                    Assert.That(reducedRates.Select(r => r.Rate).ToArray(), Is.EqualTo(expectedRates));
                });
            });
        }

        [Test(Author = "NicolasDemarbaix",
            Description = "Get Valid Parking Rate")]
        [TestCase("BE", 0.12)]
        [TestCase("LU", 0.14)]
        public void Test_Vat_FetchValidParkingRate(string countryCode, double expectedRate)
        {
            Assert.DoesNotThrow(() =>
            {
                var parkingRate = client.GetParkingRateForCountry(countryCode);

                Assert.Multiple(() =>
                {
                    Assert.That(parkingRate, Is.Not.Null);
                    Assert.That(parkingRate!.Type, Is.EqualTo(VatRateType.Parking));
                    Assert.That(parkingRate.Rate, Is.EqualTo(expectedRate));
                });
            });
        }

        [Test(Author = "NicolasDemarbaix",
            Description = "Get Invalid Parking Rate")]
        public void Test_Vat_FetchInvalidParkingRate()
        {
            var parkingRate = client.GetParkingRateForCountry("BG");

            Assert.That(parkingRate, Is.Null);
        }

        [Test(Author = "NicolasDemarbaix",
            Description = "Get Valid Super Reduced Rate")]
        public void Test_Vat_FetchValidSuperReducedRate()
        {
            var superReducedRate = client.GetSuperReducedRateForCountry("FR");

            Assert.Multiple(() =>
            {
                Assert.That(superReducedRate, Is.Not.Null);
                Assert.That(superReducedRate!.Type, Is.EqualTo(VatRateType.SuperReduced));
            });
        }


        [Test(Author = "NicolasDemarbaix",
            Description = "Get Invalid Super Reduced Rate")]
        public void Test_Vat_FetchInvalidSuperReducedRate()
        {
            var superReducedRate = client.GetSuperReducedRateForCountry("BG");

            Assert.That(superReducedRate, Is.Null);
        }

        [Test(Author = "NicolasDemarbaix",
            Description = "Get Data for invalid country")]
        public void Test_Vat_GetDataForInvalidCountry()
        {
            Assert.Throws<ArgumentException>(() => client.GetRatesForCountry("GB"));
        }
    }
}
