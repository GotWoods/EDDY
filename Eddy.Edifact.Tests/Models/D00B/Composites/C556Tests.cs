using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C556Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "X:a:t:M";

		var expected = new C556_StatusReason()
		{
			StatusReasonDescriptionCode = "X",
			CodeListIdentificationCode = "a",
			CodeListResponsibleAgencyCode = "t",
			StatusReasonDescription = "M",
		};

		var actual = Map.MapComposite<C556_StatusReason>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredStatusReasonDescriptionCode(string statusReasonDescriptionCode, bool isValidExpected)
	{
		var subject = new C556_StatusReason();
		//Required fields
		//Test Parameters
		subject.StatusReasonDescriptionCode = statusReasonDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
