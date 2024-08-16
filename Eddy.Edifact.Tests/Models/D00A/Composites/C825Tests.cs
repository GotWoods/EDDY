using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C825Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "X:t:6:N";

		var expected = new C825_DamageSeverity()
		{
			DamageSeverityDescriptionCode = "X",
			CodeListIdentificationCode = "t",
			CodeListResponsibleAgencyCode = "6",
			DamageSeverityDescription = "N",
		};

		var actual = Map.MapComposite<C825_DamageSeverity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
