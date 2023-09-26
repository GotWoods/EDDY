using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class REATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REA*Sy*6*UGdQbE*W*7bIOoq*D*Zt*0**6*A*a";

		var expected = new REA_RealEstatePropertyInformation()
		{
			TypeOfRealEstateAssetCode = "Sy",
			Quantity = 6,
			Date = "UGdQbE",
			PropertyOwnershipRightsCode = "W",
			Date2 = "7bIOoq",
			StatusOfPlansForRealEstateAssetCode = "D",
			DateTimePeriodFormatQualifier = "Zt",
			DateTimePeriod = "0",
			CompositeUnitOfMeasure = null,
			Quantity2 = 6,
			LocationQualifier = "A",
			ReferenceIdentification = "a",
		};

		var actual = Map.MapObject<REA_RealEstatePropertyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sy", true)]
	public void Validation_RequiredTypeOfRealEstateAssetCode(string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new REA_RealEstatePropertyInformation();
		//Required fields
		//Test Parameters
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Zt";
			subject.DateTimePeriod = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Zt", "0", true)]
	[InlineData("Zt", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new REA_RealEstatePropertyInformation();
		//Required fields
		subject.TypeOfRealEstateAssetCode = "Sy";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
