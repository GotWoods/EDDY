using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class AJTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "AJT+x+z";

		var expected = new AJT_AdjustmentDetails()
		{
			AdjustmentReasonDescriptionCode = "x",
			LineItemIdentifier = "z",
		};

		var actual = Map.MapObject<AJT_AdjustmentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredAdjustmentReasonDescriptionCode(string adjustmentReasonDescriptionCode, bool isValidExpected)
	{
		var subject = new AJT_AdjustmentDetails();
		//Required fields
		//Test Parameters
		subject.AdjustmentReasonDescriptionCode = adjustmentReasonDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
