using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C821Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Z:p:d:V";

		var expected = new C821_TypeOfDamage()
		{
			TypeOfDamageCoded = "Z",
			CodeListIdentificationCode = "p",
			CodeListResponsibleAgencyCode = "d",
			TypeOfDamage = "V",
		};

		var actual = Map.MapComposite<C821_TypeOfDamage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
