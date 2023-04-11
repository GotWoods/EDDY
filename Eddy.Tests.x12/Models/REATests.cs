using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class REATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REA**3*7bncUTpB*6*jJxDLMMw*Y*nL*X**3*K*I*Y*g2";

		var expected = new REA_RealEstatePropertyInformation()
		{
			CompositeTypeOfRealEstateAssetCode = null,
			Quantity = 3,
			Date = "7bncUTpB",
			PropertyOwnershipRightsCode = "6",
			Date2 = "jJxDLMMw",
			StatusOfPlansForRealEstateAssetCode = "Y",
			DateTimePeriodFormatQualifier = "nL",
			DateTimePeriod = "X",
			CompositeUnitOfMeasure = null,
			Quantity2 = 3,
			LocationQualifier = "K",
			ReferenceIdentification = "I",
			TypeOfResidenceCode = "Y",
			ConditionIndicatorCode = "g2",
		};

		var actual = Map.MapObject<REA_RealEstatePropertyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredCompositeTypeOfRealEstateAssetCode(string compositeTypeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new REA_RealEstatePropertyInformation();

        if (compositeTypeOfRealEstateAssetCode != "")
            subject.CompositeTypeOfRealEstateAssetCode = new C047_CompositeTypeOfRealEstateAssetCode() {};
		
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("nL", "X", true)]
	[InlineData("", "X", false)]
	[InlineData("nL", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new REA_RealEstatePropertyInformation();
		subject.CompositeTypeOfRealEstateAssetCode = new C047_CompositeTypeOfRealEstateAssetCode();
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
