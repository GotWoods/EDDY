using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C063Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:x:R:o";

		var expected = new C063_EventIdentification()
		{
			EventDescriptionCode = "k",
			CodeListIdentificationCode = "x",
			CodeListResponsibleAgencyCode = "R",
			Event = "o",
		};

		var actual = Map.MapComposite<C063_EventIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
