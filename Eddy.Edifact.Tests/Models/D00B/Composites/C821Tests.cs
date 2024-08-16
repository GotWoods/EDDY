using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C821Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "A:g:l:r";

		var expected = new C821_TypeOfDamage()
		{
			DamageTypeDescriptionCode = "A",
			CodeListIdentificationCode = "g",
			CodeListResponsibleAgencyCode = "l",
			DamageTypeDescription = "r",
		};

		var actual = Map.MapComposite<C821_TypeOfDamage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
