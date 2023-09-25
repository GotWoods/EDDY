using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class REATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REA**8*8rdOGoaq*n*7a3VtJJe*P*Uj*k**2*Z*T*R*JF";

		var expected = new REA_RealEstatePropertyInformation()
		{
			CompositeTypeOfRealEstateAssetCode = null,
			Quantity = 8,
			Date = "8rdOGoaq",
			PropertyOwnershipRightsCode = "n",
			Date2 = "7a3VtJJe",
			StatusOfPlansForRealEstateAssetCode = "P",
			DateTimePeriodFormatQualifier = "Uj",
			DateTimePeriod = "k",
			CompositeUnitOfMeasure = null,
			Quantity2 = 2,
			LocationQualifier = "Z",
			ReferenceIdentification = "T",
			TypeOfResidenceCode = "R",
			ConditionIndicatorCode = "JF",
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
			subject.DateTimePeriodFormatQualifier = "Uj";
			subject.DateTimePeriod = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Uj", "k", true)]
	[InlineData("Uj", "", false)]
	[InlineData("", "k", false)]
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
