using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class FX2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FX2*5*J*3*f*5";

		var expected = new FX2_ProductClassification()
		{
			YesNoConditionOrResponseCode = "5",
			CommodityCodeQualifier = "J",
			CommodityCode = "3",
			Description = "f",
			Description2 = "5",
		};

		var actual = Map.MapObject<FX2_ProductClassification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FX2_ProductClassification();
		//Required fields
		subject.CommodityCodeQualifier = "J";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//At Least one
		subject.CommodityCode = "3";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new FX2_ProductClassification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "5";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//At Least one
		subject.CommodityCode = "3";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("3", "f", true)]
	[InlineData("3", "", true)]
	[InlineData("", "f", true)]
	public void Validation_AtLeastOneCommodityCode(string commodityCode, string description, bool isValidExpected)
	{
		var subject = new FX2_ProductClassification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "5";
		subject.CommodityCodeQualifier = "J";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
