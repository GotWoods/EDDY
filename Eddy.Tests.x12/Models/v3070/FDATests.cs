using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class FDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FDA*P*9*hh*n*4*d*z*4*v";

		var expected = new FDA_FacilityDescription()
		{
			PropertyOwnershipRightsCode = "P",
			Description = "9",
			TypeOfRealEstateAssetCode = "hh",
			YesNoConditionOrResponseCode = "n",
			Quantity = 4,
			FreeFormMessage = "d",
			ConstructionType = "z",
			ConstructionType2 = "4",
			Description2 = "v",
		};

		var actual = Map.MapObject<FDA_FacilityDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("P", "9", true)]
	[InlineData("P", "", true)]
	[InlineData("", "9", true)]
	public void Validation_AtLeastOnePropertyOwnershipRightsCode(string propertyOwnershipRightsCode, string description, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "hh", true)]
	[InlineData("n", "", false)]
	[InlineData("", "hh", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		//At Least one
		subject.PropertyOwnershipRightsCode = "P";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("n", 4, false)]
	[InlineData("n", 0, true)]
	[InlineData("", 4, true)]
	public void Validation_OnlyOneOfYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, decimal quantity, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//A Requires B
		if (quantity > 0)
			subject.TypeOfRealEstateAssetCode = "hh";
		//At Least one
		subject.PropertyOwnershipRightsCode = "P";

        if (subject.YesNoConditionOrResponseCode != "")
            subject.TypeOfRealEstateAssetCode = "hh";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "hh", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "hh", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		//At Least one
		subject.PropertyOwnershipRightsCode = "P";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "z", true)]
	[InlineData("4", "", false)]
	[InlineData("", "z", true)]
	public void Validation_ARequiresBConstructionType2(string constructionType2, string constructionType, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		subject.ConstructionType2 = constructionType2;
		subject.ConstructionType = constructionType;
		//At Least one
		subject.PropertyOwnershipRightsCode = "P";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
