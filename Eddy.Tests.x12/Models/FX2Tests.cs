using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FX2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FX2*f*0*6*6*i";

		var expected = new FX2_ProductClassification()
		{
			YesNoConditionOrResponseCode = "f",
			CommodityCodeQualifier = "0",
			CommodityCode = "6",
			Description = "6",
			Description2 = "i",
		};

		var actual = Map.MapObject<FX2_ProductClassification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FX2_ProductClassification();
		subject.CommodityCodeQualifier = "0";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
        subject.Description = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new FX2_ProductClassification();
		subject.YesNoConditionOrResponseCode = "f";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.Description = "AB";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("6","6", true)]
	[InlineData("", "6", true)]
	[InlineData("6", "", true)]
	public void Validation_AtLeastOneCommodityCode(string commodityCode, string description, bool isValidExpected)
	{
		var subject = new FX2_ProductClassification();
		subject.YesNoConditionOrResponseCode = "f";
		subject.CommodityCodeQualifier = "0";
		subject.CommodityCode = commodityCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
