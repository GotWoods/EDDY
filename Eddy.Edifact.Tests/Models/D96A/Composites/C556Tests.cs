using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C556Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "4:U:m:V";

		var expected = new C556_StatusReason()
		{
			StatusReasonCoded = "4",
			CodeListQualifier = "U",
			CodeListResponsibleAgencyCoded = "m",
			StatusReason = "V",
		};

		var actual = Map.MapComposite<C556_StatusReason>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredStatusReasonCoded(string statusReasonCoded, bool isValidExpected)
	{
		var subject = new C556_StatusReason();
		//Required fields
		//Test Parameters
		subject.StatusReasonCoded = statusReasonCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
