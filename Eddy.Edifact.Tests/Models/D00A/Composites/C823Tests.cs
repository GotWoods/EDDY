using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C823Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "k:M:S:S";

		var expected = new C823_TypeOfUnitComponent()
		{
			UnitOrComponentTypeDescriptionCode = "k",
			CodeListIdentificationCode = "M",
			CodeListResponsibleAgencyCode = "S",
			UnitOrComponentTypeDescription = "S",
		};

		var actual = Map.MapComposite<C823_TypeOfUnitComponent>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
