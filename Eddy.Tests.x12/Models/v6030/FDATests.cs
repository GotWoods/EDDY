using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class FDATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FDA*B*r*LE*n*2*2*3*c*p";

		var expected = new FDA_FacilityDescription()
		{
			PropertyOwnershipRightsCode = "B",
			Description = "r",
			TypeOfRealEstateAssetCode = "LE",
			YesNoConditionOrResponseCode = "n",
			Quantity = 2,
			FreeFormInformation = "2",
			ConstructionTypeCode = "3",
			ConstructionTypeCode2 = "c",
			Description2 = "p",
		};

		var actual = Map.MapObject<FDA_FacilityDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("B", "r", true)]
	[InlineData("B", "", true)]
	[InlineData("", "r", true)]
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
	[InlineData("n", "LE", true)]
	[InlineData("n", "", false)]
	[InlineData("", "LE", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		//At Least one
		subject.PropertyOwnershipRightsCode = "B";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("n", 2, false)]
	[InlineData("n", 0, true)]
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
			subject.TypeOfRealEstateAssetCode = "LE";

        if (subject.YesNoConditionOrResponseCode != "")
            subject.TypeOfRealEstateAssetCode = "hh";

        //At Least one
        subject.PropertyOwnershipRightsCode = "B";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "LE", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "LE", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		//At Least one
		subject.PropertyOwnershipRightsCode = "B";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "3", true)]
	[InlineData("c", "", false)]
	[InlineData("", "3", true)]
	public void Validation_ARequiresBConstructionTypeCode2(string constructionTypeCode2, string constructionTypeCode, bool isValidExpected)
	{
		var subject = new FDA_FacilityDescription();
		//Required fields
		//Test Parameters
		subject.ConstructionTypeCode2 = constructionTypeCode2;
		subject.ConstructionTypeCode = constructionTypeCode;
		//At Least one
		subject.PropertyOwnershipRightsCode = "B";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
