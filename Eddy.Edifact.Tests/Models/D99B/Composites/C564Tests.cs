using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C564Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:f:P:O";

		var expected = new C564_PhysicalOrLogicalStateInformation()
		{
			PhysicalOrLogicalStateCoded = "9",
			CodeListIdentificationCode = "f",
			CodeListResponsibleAgencyCode = "P",
			PhysicalOrLogicalState = "O",
		};

		var actual = Map.MapComposite<C564_PhysicalOrLogicalStateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
