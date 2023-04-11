using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FDA*c*n*Np*6*4*C*7*I*N";

		var expected = new FDA_FacilityDescription()
		{
			PropertyOwnershipRightsCode = "c",
			Description = "n",
			TypeOfRealEstateAssetCode = "Np",
			YesNoConditionOrResponseCode = "6",
			Quantity = 4,
			FreeFormInformation = "C",
			ConstructionTypeCode = "7",
			ConstructionTypeCode2 = "I",
			Description2 = "N",
		};

		var actual = Map.MapObject<FDA_FacilityDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("c","n", true)]
	[InlineData("", "n", true)]
	[InlineData("c", "", true)]
	public void Validation_AtLeastOnePropertyOwnershipRightsCode(string propertyOwnershipRightsCode, string description, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Np", true)]
	[InlineData("6", "", false)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("6", 4, false)]
	[InlineData("", 4, true)]
	[InlineData("6", 0, true)]
	public void Validation_OnlyOneOfYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, decimal quantity, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Np", true)]
	[InlineData(4, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "7", true)]
	[InlineData("I", "", false)]
	public void Validation_ARequiresBConstructionTypeCode2(string constructionTypeCode2, string constructionTypeCode, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		subject.ConstructionTypeCode2 = constructionTypeCode2;
		subject.ConstructionTypeCode = constructionTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
