using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class DVITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DVI*eHg*7*uAr*sl*d*X*9*0*YA*J7*J*Lw*G*ZK";

		var expected = new DVI_DynamicVehicleInformation()
		{
			PriceIdentifierCode = "eHg",
			UnitPrice = 7,
			CurrencyCode = "uAr",
			DateTimePeriodFormatQualifier = "sl",
			DateTimePeriod = "d",
			Name = "X",
			Quantity = 9,
			ReferenceIdentification = "0",
			StateOrProvinceCode = "YA",
			DateTimePeriodFormatQualifier2 = "J7",
			DateTimePeriod2 = "J",
			LicensePlateTypeCode = "Lw",
			YesNoConditionOrResponseCode = "G",
			CountryCode = "ZK",
		};

		var actual = Map.MapObject<DVI_DynamicVehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("eHg", 7, true)]
	[InlineData("eHg", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBPriceIdentifierCode(string priceIdentifierCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new DVI_DynamicVehicleInformation();
		//Required fields
		//Test Parameters
		subject.PriceIdentifierCode = priceIdentifierCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "sl";
			subject.DateTimePeriod = "d";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "J7";
			subject.DateTimePeriod2 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sl", "d", true)]
	[InlineData("sl", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DVI_DynamicVehicleInformation();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "J7";
			subject.DateTimePeriod2 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J7", "J", true)]
	[InlineData("J7", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new DVI_DynamicVehicleInformation();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "sl";
			subject.DateTimePeriod = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZK", "YA", true)]
	[InlineData("ZK", "", false)]
	[InlineData("", "YA", true)]
	public void Validation_ARequiresBCountryCode(string countryCode, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new DVI_DynamicVehicleInformation();
		//Required fields
		//Test Parameters
		subject.CountryCode = countryCode;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "sl";
			subject.DateTimePeriod = "d";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "J7";
			subject.DateTimePeriod2 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
