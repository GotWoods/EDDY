using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C101Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:6:h:5";

		var expected = new C101_ReligionDetails()
		{
			ReligionCoded = "G",
			CodeListQualifier = "6",
			CodeListResponsibleAgencyCoded = "h",
			Religion = "5",
		};

		var actual = Map.MapComposite<C101_ReligionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
