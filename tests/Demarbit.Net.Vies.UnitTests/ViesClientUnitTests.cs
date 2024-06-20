using Demarbit.Net.Vies.Clients;
using Demarbit.Net.Vies.Enums;

namespace Demarbit.Net.Vies.UnitTests
{
    [TestFixture(
        Author = "Nicolas Demarbaix",
        Category = "Vies",
        Description = "Vies client tests",
        TestOf = typeof(ViesClient))]
    public class ViesClientUnitTests
    {
        private const string TEST_VAT_NUMBER = "0729739314";
        private const string TEST_INVALID = "0000000000";
        private const string TEST_COMPANY_NAME = "BV DEMARBIT";

        private ViesClient client;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            client = new ViesClient();
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            client.Dispose();
        }

        [Test(
            Author = "NicolasDemarbaix",
            Description = "Fetch valid VAT information")]
        public void Test_Vies_FetchValidInfo()
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                var vatResult = await client.ValidateVatNumberAsync(EUCountryCodes.BE, TEST_VAT_NUMBER);

                Assert.Multiple(() =>
                {
                    Assert.That(vatResult, Is.Not.Null);
                    Assert.That(vatResult.IsValid, Is.True);
                    Assert.That(vatResult.Name, Is.EqualTo(TEST_COMPANY_NAME));
                });
            });
        }

        [Test(
            Author = "NicolasDemarbaix",
            Description = "Fetch valid VAT information (using country code)")]
        public void Test_Vies_FetchValidInfoUsingStringCode()
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                var vatResult = await client.ValidateVatNumberAsync("BE", TEST_VAT_NUMBER);

                Assert.Multiple(() =>
                {
                    Assert.That(vatResult, Is.Not.Null);
                    Assert.That(vatResult.IsValid, Is.True);
                    Assert.That(vatResult.Name, Is.EqualTo(TEST_COMPANY_NAME));
                    Assert.That(vatResult.Country, Is.EqualTo(EUCountryCodes.BE));
                });
            });
        }

        [Test(
            Author = "NicolasDemarbaix",
            Description = "Fetch invalid VAT information")]
        public void Test_Vies_FetchInvalidInfo()
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                var vatResult = await client.ValidateVatNumberAsync(EUCountryCodes.BE, TEST_INVALID);

                Assert.Multiple(() =>
                {
                    Assert.That(vatResult, Is.Not.Null);
                    Assert.That(vatResult.IsValid, Is.False);
                });
            });
        }
    }
}
