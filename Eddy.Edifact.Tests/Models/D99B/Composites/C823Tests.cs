using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C823Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:E:F:x";

		var expected = new C823_TypeOfUnitComponent()
		{
			TypeOfUnitComponentCoded = "7",
			CodeListIdentificationCode = "E",
			CodeListResponsibleAgencyCode = "F",
			TypeOfUnitComponent = "x",
		};

		var actual = Map.MapComposite<C823_TypeOfUnitComponent>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
