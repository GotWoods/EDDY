using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C232Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "v:n:Q:2";

		var expected = new C232_GovernmentAction()
		{
			GovernmentAgencyCoded = "v",
			GovernmentInvolvementCoded = "n",
			GovernmentActionCoded = "Q",
			GovernmentProcedureCoded = "2",
		};

		var actual = Map.MapComposite<C232_GovernmentAction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
