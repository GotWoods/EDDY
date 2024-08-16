using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C822Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "O:c:Z:I";

		var expected = new C822_DamageArea()
		{
			DamageAreaDescriptionCode = "O",
			CodeListIdentificationCode = "c",
			CodeListResponsibleAgencyCode = "Z",
			DamageAreaDescription = "I",
		};

		var actual = Map.MapComposite<C822_DamageArea>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
