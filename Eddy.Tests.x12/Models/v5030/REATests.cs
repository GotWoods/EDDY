using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class REATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REA**5*hg5mA831*V*r33s2GQM*B*lO*7**1*b*z*t*IE";

		var expected = new REA_RealEstatePropertyInformation()
		{
			CompositeTypeOfRealEstateAssetCode = null,
			Quantity = 5,
			Date = "hg5mA831",
			PropertyOwnershipRightsCode = "V",
			Date2 = "r33s2GQM",
			StatusOfPlansForRealEstateAssetCode = "B",
			DateTimePeriodFormatQualifier = "lO",
			DateTimePeriod = "7",
			CompositeUnitOfMeasure = null,
			Quantity2 = 1,
			LocationQualifier = "b",
			ReferenceIdentification = "z",
			TypeOfResidenceCode = "t",
			ConditionIndicator = "IE",
		};

		var actual = Map.MapObject<REA_RealEstatePropertyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
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
			subject.DateTimePeriodFormatQualifier = "lO";
			subject.DateTimePeriod = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lO", "7", true)]
	[InlineData("lO", "", false)]
	[InlineData("", "7", false)]
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
