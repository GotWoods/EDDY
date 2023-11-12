using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class FX2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FX2*W*0*T*R*M";

		var expected = new FX2_ProductClassification()
		{
			YesNoConditionOrResponseCode = "W",
			CommodityCodeQualifier = "0",
			CommodityCode = "T",
			Description = "R",
			Description2 = "M",
		};

		var actual = Map.MapObject<FX2_ProductClassification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FX2_ProductClassification();
		//Required fields
		subject.CommodityCodeQualifier = "0";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//At Least one
		subject.CommodityCode = "T";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new FX2_ProductClassification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "W";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//At Least one
		subject.CommodityCode = "T";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("T", "R", true)]
	[InlineData("T", "", true)]
	[InlineData("", "R", true)]
	public void Validation_AtLeastOneCommodityCode(string commodityCode, string description, bool isValidExpected)
	{
		var subject = new FX2_ProductClassification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "W";
		subject.CommodityCodeQualifier = "0";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
