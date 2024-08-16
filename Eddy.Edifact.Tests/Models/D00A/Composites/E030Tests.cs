using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E030Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "O:l:V";

		var expected = new E030_AdjustmentInformation()
		{
			AdjustmentCategoryCode = "O",
			AdjustmentReasonDescriptionCode = "l",
			MonetaryAmount = "V",
		};

		var actual = Map.MapComposite<E030_AdjustmentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredAdjustmentCategoryCode(string adjustmentCategoryCode, bool isValidExpected)
	{
		var subject = new E030_AdjustmentInformation();
		//Required fields
		subject.AdjustmentReasonDescriptionCode = "l";
		//Test Parameters
		subject.AdjustmentCategoryCode = adjustmentCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredAdjustmentReasonDescriptionCode(string adjustmentReasonDescriptionCode, bool isValidExpected)
	{
		var subject = new E030_AdjustmentInformation();
		//Required fields
		subject.AdjustmentCategoryCode = "O";
		//Test Parameters
		subject.AdjustmentReasonDescriptionCode = adjustmentReasonDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
