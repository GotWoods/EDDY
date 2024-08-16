using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class AJTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "AJT+x+y";

		var expected = new AJT_AdjustmentDetails()
		{
			AdjustmentReasonCoded = "x",
			LineItemNumber = "y",
		};

		var actual = Map.MapObject<AJT_AdjustmentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredAdjustmentReasonCoded(string adjustmentReasonCoded, bool isValidExpected)
	{
		var subject = new AJT_AdjustmentDetails();
		//Required fields
		//Test Parameters
		subject.AdjustmentReasonCoded = adjustmentReasonCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
