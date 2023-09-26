using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class DVITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DVI*8Vy*6*ous*R0*3*g*9*n*7u*RR*m*Ia*l";

		var expected = new DVI_DynamicVehicleInformation()
		{
			PriceIdentifierCode = "8Vy",
			UnitPrice = 6,
			CurrencyCode = "ous",
			DateTimePeriodFormatQualifier = "R0",
			DateTimePeriod = "3",
			Name = "g",
			Quantity = 9,
			ReferenceIdentification = "n",
			StateOrProvinceCode = "7u",
			DateTimePeriodFormatQualifier2 = "RR",
			DateTimePeriod2 = "m",
			LicensePlateType = "Ia",
			YesNoConditionOrResponseCode = "l",
		};

		var actual = Map.MapObject<DVI_DynamicVehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("8Vy", 6, true)]
	[InlineData("8Vy", 0, false)]
	[InlineData("", 6, true)]
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
			subject.DateTimePeriodFormatQualifier = "R0";
			subject.DateTimePeriod = "3";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "RR";
			subject.DateTimePeriod2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R0", "3", true)]
	[InlineData("R0", "", false)]
	[InlineData("", "3", false)]
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
			subject.DateTimePeriodFormatQualifier2 = "RR";
			subject.DateTimePeriod2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("RR", "m", true)]
	[InlineData("RR", "", false)]
	[InlineData("", "m", false)]
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
			subject.DateTimePeriodFormatQualifier = "R0";
			subject.DateTimePeriod = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
