using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C960Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "W:u:J:v";

		var expected = new C960_ReasonForChange()
		{
			ChangeReasonDescriptionCode = "W",
			CodeListIdentificationCode = "u",
			CodeListResponsibleAgencyCode = "J",
			ChangeReasonDescription = "v",
		};

		var actual = Map.MapComposite<C960_ReasonForChange>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
