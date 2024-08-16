using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C821Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "U:f:i:L";

		var expected = new C821_TypeOfDamage()
		{
			TypeOfDamageCoded = "U",
			CodeListQualifier = "f",
			CodeListResponsibleAgencyCoded = "i",
			TypeOfDamage = "L",
		};

		var actual = Map.MapComposite<C821_TypeOfDamage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
