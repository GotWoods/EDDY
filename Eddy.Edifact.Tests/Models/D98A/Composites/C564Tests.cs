using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class C564Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "6:m:f:D";

		var expected = new C564_PhysicalOrLogicalStateInformation()
		{
			PhysicalOrLogicalStateCoded = "6",
			CodeListQualifier = "m",
			CodeListResponsibleAgencyCoded = "f",
			PhysicalOrLogicalState = "D",
		};

		var actual = Map.MapComposite<C564_PhysicalOrLogicalStateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
