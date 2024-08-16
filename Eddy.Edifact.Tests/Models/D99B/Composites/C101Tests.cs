using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C101Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:m:a:0";

		var expected = new C101_ReligionDetails()
		{
			ReligionCoded = "u",
			CodeListIdentificationCode = "m",
			CodeListResponsibleAgencyCode = "a",
			Religion = "0",
		};

		var actual = Map.MapComposite<C101_ReligionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
