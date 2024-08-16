using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C063Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "W:V:g:m";

		var expected = new C063_EventIdentification()
		{
			EventDescriptionCode = "W",
			CodeListIdentificationCode = "V",
			CodeListResponsibleAgencyCode = "g",
			Event = "m",
		};

		var actual = Map.MapComposite<C063_EventIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
