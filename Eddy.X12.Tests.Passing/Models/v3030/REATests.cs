using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class REATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REA*xG*7*FJsuLV*7*LFgLEX*K*TC*R*9B*4*z";

		var expected = new REA_RealEstatePropertyInformation()
		{
			TypeOfRealEstateAssetCode = "xG",
			Quantity = 7,
			Date = "FJsuLV",
			PropertyOwnershipRightsCode = "7",
			Date2 = "LFgLEX",
			StatusOfPlansForRealEstateAssetCode = "K",
			DateTimePeriodFormatQualifier = "TC",
			DateTimePeriod = "R",
			UnitOrBasisForMeasurementCode = "9B",
			Quantity2 = 4,
			LocationQualifier = "z",
		};

		var actual = Map.MapObject<REA_RealEstatePropertyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xG", true)]
	public void Validation_RequiredTypeOfRealEstateAssetCode(string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new REA_RealEstatePropertyInformation();
		//Required fields
		//Test Parameters
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "TC";
			subject.DateTimePeriod = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TC", "R", true)]
	[InlineData("TC", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new REA_RealEstatePropertyInformation();
		//Required fields
		subject.TypeOfRealEstateAssetCode = "xG";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "9B", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "9B", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new REA_RealEstatePropertyInformation();
		//Required fields
		subject.TypeOfRealEstateAssetCode = "xG";
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "TC";
			subject.DateTimePeriod = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
