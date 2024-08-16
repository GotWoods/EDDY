using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C821Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "D:N:p:q";

		var expected = new C821_TypeOfDamage()
		{
			DamageTypeDescriptionCode = "D",
			CodeListIdentificationCode = "N",
			CodeListResponsibleAgencyCode = "p",
			DamageTypeDescription = "q",
		};

		var actual = Map.MapComposite<C821_TypeOfDamage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
