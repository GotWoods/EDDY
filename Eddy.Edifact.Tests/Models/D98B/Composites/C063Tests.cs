using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C063Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "e:s:W:w";

		var expected = new C063_EventIdentification()
		{
			EventIdentification = "e",
			CodeListQualifier = "s",
			CodeListResponsibleAgencyCoded = "W",
			Event = "w",
		};

		var actual = Map.MapComposite<C063_EventIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
