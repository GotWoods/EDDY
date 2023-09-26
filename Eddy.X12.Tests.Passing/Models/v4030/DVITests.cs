using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class DVITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DVI*bwl*5*98d*fV*g*6*1*n*mI*mn*i*SI*U";

		var expected = new DVI_DynamicVehicleInformation()
		{
			PriceIdentifierCode = "bwl",
			UnitPrice = 5,
			CurrencyCode = "98d",
			DateTimePeriodFormatQualifier = "fV",
			DateTimePeriod = "g",
			Name = "6",
			Quantity = 1,
			ReferenceIdentification = "n",
			StateOrProvinceCode = "mI",
			DateTimePeriodFormatQualifier2 = "mn",
			DateTimePeriod2 = "i",
			LicensePlateType = "SI",
			YesNoConditionOrResponseCode = "U",
		};

		var actual = Map.MapObject<DVI_DynamicVehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("bwl", 5, true)]
	[InlineData("bwl", 0, false)]
	[InlineData("", 5, true)]
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
			subject.DateTimePeriodFormatQualifier = "fV";
			subject.DateTimePeriod = "g";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "mn";
			subject.DateTimePeriod2 = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fV", "g", true)]
	[InlineData("fV", "", false)]
	[InlineData("", "g", false)]
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
			subject.DateTimePeriodFormatQualifier2 = "mn";
			subject.DateTimePeriod2 = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mn", "i", true)]
	[InlineData("mn", "", false)]
	[InlineData("", "i", false)]
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
			subject.DateTimePeriodFormatQualifier = "fV";
			subject.DateTimePeriod = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
