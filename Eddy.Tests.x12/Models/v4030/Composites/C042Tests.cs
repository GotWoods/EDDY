using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4030;
using Eddy.x12.Models.v4030.Composites;

namespace Eddy.x12.Tests.Models.v4030.Composites;

public class C042Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "Lh*n";

		var expected = new C042_AdjustmentIdentifier()
		{
			AdjustmentReasonCode = "Lh",
			ReferenceIdentification = "n",
		};

		var actual = Map.MapObject<C042_AdjustmentIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lh", true)]
	public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
	{
		var subject = new C042_AdjustmentIdentifier();
		//Required fields
		//Test Parameters
		subject.AdjustmentReasonCode = adjustmentReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
