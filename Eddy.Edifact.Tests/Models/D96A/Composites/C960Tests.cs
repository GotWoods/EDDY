using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C960Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "F:P:k:L";

		var expected = new C960_ReasonForChange()
		{
			ChangeReasonCoded = "F",
			CodeListQualifier = "P",
			CodeListResponsibleAgencyCoded = "k",
			ChangeReason = "L",
		};

		var actual = Map.MapComposite<C960_ReasonForChange>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
