using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C825Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "y:2:O:4";

		var expected = new C825_DamageSeverity()
		{
			DamageSeverityCoded = "y",
			CodeListIdentificationCode = "2",
			CodeListResponsibleAgencyCode = "O",
			DamageSeverity = "4",
		};

		var actual = Map.MapComposite<C825_DamageSeverity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
