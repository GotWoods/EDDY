using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C823Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "H:X:Y:3";

		var expected = new C823_TypeOfUnitComponent()
		{
			UnitOrComponentTypeDescriptionCode = "H",
			CodeListIdentificationCode = "X",
			CodeListResponsibleAgencyCode = "Y",
			UnitOrComponentTypeDescription = "3",
		};

		var actual = Map.MapComposite<C823_TypeOfUnitComponent>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
