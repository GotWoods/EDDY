using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class FDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FDA*D*s*8F*r*5*g*2*O*G";

		var expected = new FDA_FacilityDescription()
		{
			PropertyOwnershipRightsCode = "D",
			Description = "s",
			TypeOfRealEstateAssetCode = "8F",
			YesNoConditionOrResponseCode = "r",
			Quantity = 5,
			FreeFormMessage = "g",
			ConstructionType = "2",
			ConstructionType2 = "O",
			Description2 = "G",
		};

		var actual = Map.MapObject<FDA_FacilityDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("D", "s", true)]
	[InlineData("D", "", true)]
	[InlineData("", "s", true)]
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
	[InlineData("r", "8F", true)]
	[InlineData("r", "", false)]
	[InlineData("", "8F", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		//At Least one
		subject.PropertyOwnershipRightsCode = "D";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("r", 5, false)]
	[InlineData("r", 0, true)]
	[InlineData("", 5, true)]
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
			subject.TypeOfRealEstateAssetCode = "8F";

        if (subject.YesNoConditionOrResponseCode != "")
            subject.TypeOfRealEstateAssetCode = "hh";

        //At Least one
        subject.PropertyOwnershipRightsCode = "D";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "8F", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "8F", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		//At Least one
		subject.PropertyOwnershipRightsCode = "D";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "2", true)]
	[InlineData("O", "", false)]
	[InlineData("", "2", true)]
	public void Validation_ARequiresBConstructionType2(string constructionType2, string constructionType, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		subject.ConstructionType2 = constructionType2;
		subject.ConstructionType = constructionType;
		//At Least one
		subject.PropertyOwnershipRightsCode = "D";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
