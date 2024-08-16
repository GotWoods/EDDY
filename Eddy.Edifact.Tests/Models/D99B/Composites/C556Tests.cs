using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C556Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:2:L:o";

		var expected = new C556_StatusReason()
		{
			StatusReasonDescriptionCode = "G",
			CodeListIdentificationCode = "2",
			CodeListResponsibleAgencyCode = "L",
			StatusReasonDescription = "o",
		};

		var actual = Map.MapComposite<C556_StatusReason>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredStatusReasonDescriptionCode(string statusReasonDescriptionCode, bool isValidExpected)
	{
		var subject = new C556_StatusReason();
		//Required fields
		//Test Parameters
		subject.StatusReasonDescriptionCode = statusReasonDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
