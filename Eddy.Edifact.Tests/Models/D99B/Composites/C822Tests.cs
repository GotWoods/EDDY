using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C822Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "k:j:x:x";

		var expected = new C822_DamageArea()
		{
			DamageAreaIdentification = "k",
			CodeListIdentificationCode = "j",
			CodeListResponsibleAgencyCode = "x",
			DamageArea = "x",
		};

		var actual = Map.MapComposite<C822_DamageArea>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
