using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C823Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "6:j:K:Y";

		var expected = new C823_TypeOfUnitComponent()
		{
			TypeOfUnitComponentCoded = "6",
			CodeListQualifier = "j",
			CodeListResponsibleAgencyCoded = "K",
			TypeOfUnitComponent = "Y",
		};

		var actual = Map.MapComposite<C823_TypeOfUnitComponent>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
