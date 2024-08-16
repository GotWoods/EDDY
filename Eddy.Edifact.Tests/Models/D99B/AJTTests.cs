using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class AJTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "AJT+H+Z";

		var expected = new AJT_AdjustmentDetails()
		{
			AdjustmentReasonDescriptionCode = "H",
			LineItemNumber = "Z",
		};

		var actual = Map.MapObject<AJT_AdjustmentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredAdjustmentReasonDescriptionCode(string adjustmentReasonDescriptionCode, bool isValidExpected)
	{
		var subject = new AJT_AdjustmentDetails();
		//Required fields
		//Test Parameters
		subject.AdjustmentReasonDescriptionCode = adjustmentReasonDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
