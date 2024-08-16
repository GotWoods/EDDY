using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C564Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "T:6:h:p";

		var expected = new C564_PhysicalOrLogicalStateInformation()
		{
			PhysicalOrLogicalStateDescriptionCode = "T",
			CodeListIdentificationCode = "6",
			CodeListResponsibleAgencyCode = "h",
			PhysicalOrLogicalStateDescription = "p",
		};

		var actual = Map.MapComposite<C564_PhysicalOrLogicalStateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
