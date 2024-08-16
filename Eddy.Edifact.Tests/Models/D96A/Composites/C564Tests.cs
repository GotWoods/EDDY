using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C564Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "D:s:s:H";

		var expected = new C564_PhysicalOrLogicalStateInformation()
		{
			PhysicalOrLogicalStateCoded = "D",
			CodeListQualifier = "s",
			CodeListResponsibleAgencyCoded = "s",
			PhysicalOrLogicalState = "H",
		};

		var actual = Map.MapComposite<C564_PhysicalOrLogicalStateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
