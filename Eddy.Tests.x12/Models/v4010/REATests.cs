using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class REATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REA**5*LflxRVWJ*m*wPE8g81O*0*W4*3**8*W*j*z";

		var expected = new REA_RealEstatePropertyInformation()
		{
			CompositeTypeOfRealEstateAssetCode = null,
			Quantity = 5,
			Date = "LflxRVWJ",
			PropertyOwnershipRightsCode = "m",
			Date2 = "wPE8g81O",
			StatusOfPlansForRealEstateAssetCode = "0",
			DateTimePeriodFormatQualifier = "W4",
			DateTimePeriod = "3",
			CompositeUnitOfMeasure = null,
			Quantity2 = 8,
			LocationQualifier = "W",
			ReferenceIdentification = "j",
			TypeOfResidenceCode = "z",
		};

		var actual = Map.MapObject<REA_RealEstatePropertyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validation_RequiredCompositeTypeOfRealEstateAssetCode(string compositeTypeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new REA_RealEstatePropertyInformation();
		//Required fields
		//Test Parameters
		if (compositeTypeOfRealEstateAssetCode != "") 
			subject.CompositeTypeOfRealEstateAssetCode = new C047_CompositeTypeOfRealEstateAssetCode();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "W4";
			subject.DateTimePeriod = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W4", "3", true)]
	[InlineData("W4", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new REA_RealEstatePropertyInformation();
		//Required fields
		subject.CompositeTypeOfRealEstateAssetCode = new C047_CompositeTypeOfRealEstateAssetCode();
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
