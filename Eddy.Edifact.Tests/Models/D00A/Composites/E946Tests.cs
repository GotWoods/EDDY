using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E946Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:e:J:b";

		var expected = new E946_Certainty()
		{
			CertaintyDescriptionCode = "k",
			CertaintyDescription = "e",
			LanguageNameCode = "J",
			CodeListResponsibleAgencyCode = "b",
		};

		var actual = Map.MapComposite<E946_Certainty>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
