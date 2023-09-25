using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class REATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REA**6*MqLHaUfx*I*KvZjyBcR*y*a1*t**4*0*U*9*eU";

		var expected = new REA_RealEstatePropertyInformation()
		{
			CompositeTypeOfRealEstateAssetCode = null,
			Quantity = 6,
			Date = "MqLHaUfx",
			PropertyOwnershipRightsCode = "I",
			Date2 = "KvZjyBcR",
			StatusOfPlansForRealEstateAssetCode = "y",
			DateTimePeriodFormatQualifier = "a1",
			DateTimePeriod = "t",
			CompositeUnitOfMeasure = null,
			Quantity2 = 4,
			LocationQualifier = "0",
			ReferenceIdentification = "U",
			TypeOfResidenceCode = "9",
			ConditionIndicator = "eU",
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
			subject.DateTimePeriodFormatQualifier = "a1";
			subject.DateTimePeriod = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a1", "t", true)]
	[InlineData("a1", "", false)]
	[InlineData("", "t", false)]
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
