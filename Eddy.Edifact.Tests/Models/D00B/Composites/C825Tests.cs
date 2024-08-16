using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C825Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "j:J:j:n";

		var expected = new C825_DamageSeverity()
		{
			DamageSeverityDescriptionCode = "j",
			CodeListIdentificationCode = "J",
			CodeListResponsibleAgencyCode = "j",
			DamageSeverityDescription = "n",
		};

		var actual = Map.MapComposite<C825_DamageSeverity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
