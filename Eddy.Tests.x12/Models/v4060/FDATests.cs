using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class FDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FDA*G*v*Qq*U*2*O*i*w*p";

		var expected = new FDA_FacilityDescription()
		{
			PropertyOwnershipRightsCode = "G",
			Description = "v",
			TypeOfRealEstateAssetCode = "Qq",
			YesNoConditionOrResponseCode = "U",
			Quantity = 2,
			FreeFormInformation = "O",
			ConstructionType = "i",
			ConstructionType2 = "w",
			Description2 = "p",
		};

		var actual = Map.MapObject<FDA_FacilityDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("G", "v", true)]
	[InlineData("G", "", true)]
	[InlineData("", "v", true)]
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
	[InlineData("U", "Qq", true)]
	[InlineData("U", "", false)]
	[InlineData("", "Qq", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		//At Least one
		subject.PropertyOwnershipRightsCode = "G";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("U", 2, false)]
	[InlineData("U", 0, true)]
	[InlineData("", 2, true)]
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
			subject.TypeOfRealEstateAssetCode = "Qq";

        if (subject.YesNoConditionOrResponseCode != "")
            subject.TypeOfRealEstateAssetCode = "hh";

        //At Least one
        subject.PropertyOwnershipRightsCode = "G";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "Qq", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "Qq", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		//At Least one
		subject.PropertyOwnershipRightsCode = "G";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "i", true)]
	[InlineData("w", "", false)]
	[InlineData("", "i", true)]
	public void Validation_ARequiresBConstructionType2(string constructionType2, string constructionType, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		subject.ConstructionType2 = constructionType2;
		subject.ConstructionType = constructionType;
		//At Least one
		subject.PropertyOwnershipRightsCode = "G";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
