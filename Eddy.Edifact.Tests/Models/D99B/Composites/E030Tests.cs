using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E030Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "M:h:w";

		var expected = new E030_AdjustmentInformation()
		{
			AdjustmentCategoryCode = "M",
			AdjustmentReasonDescriptionCode = "h",
			MonetaryAmountValue = "w",
		};

		var actual = Map.MapComposite<E030_AdjustmentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredAdjustmentCategoryCode(string adjustmentCategoryCode, bool isValidExpected)
	{
		var subject = new E030_AdjustmentInformation();
		//Required fields
		subject.AdjustmentReasonDescriptionCode = "h";
		//Test Parameters
		subject.AdjustmentCategoryCode = adjustmentCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredAdjustmentReasonDescriptionCode(string adjustmentReasonDescriptionCode, bool isValidExpected)
	{
		var subject = new E030_AdjustmentInformation();
		//Required fields
		subject.AdjustmentCategoryCode = "M";
		//Test Parameters
		subject.AdjustmentReasonDescriptionCode = adjustmentReasonDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
