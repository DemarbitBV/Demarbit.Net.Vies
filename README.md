# Demarbit.Net.Vies

Integrate the [VIES Service](https://ec.europa.eu/taxation_customs/vies/#/vat-validation) API into your .NET project!

The Demarbit VIES .NET Library targets the .NET 8 framework.

## Installation with Nuget
To install the library via NuGet:
* Search for `Demarbit.Net.Vies` in the NuGet Library, or
* Type `Install-Package Demarbit.Net.Vies` in the NuGet Package Manager, or
* Install using the dotnet CLI with `dotnet add package Demarbit.Net.Vies`

## Usage
### 1. Validating VAT numbers.
To validate VAT numbers you can use the `ViesClient` class:

```C#
var client = new ViesClient();

var vatResult = await client.ValidateVatNumberAsync(EUCountryCodes.BE, "someVatNumber");

if (vatResult.isValid) {
  Console.WriteLine("Valid VAT number:");
  Console.WriteLine(" - Company = " + vatResult.Name);
  Console.WriteLine(" - Address = " + vatResult.Address);
} else {
  Console.WriteLine("Invalid VAT number.");
}
```

### 2. Get VAT Rate information
With the VatClient you can retrieve specific VAT rate information for a country. 

```C#
var client = new VatClient();

var rates = client.GetRatesForCountry("BE");
```