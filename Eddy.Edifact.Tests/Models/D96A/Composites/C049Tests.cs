using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C049Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "3:8:e:O:R";

		var expected = new C049_RemunerationTypeIdentification()
		{
			RemunerationTypeCoded = "3",
			CodeListQualifier = "8",
			CodeListResponsibleAgencyCoded = "e",
			RemunerationType = "O",
			RemunerationType2 = "R",
		};

		var actual = Map.MapComposite<C049_RemunerationTypeIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
