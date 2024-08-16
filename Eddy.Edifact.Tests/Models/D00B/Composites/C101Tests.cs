using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C101Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:V:s:E";

		var expected = new C101_ReligionDetails()
		{
			ReligionNameCode = "7",
			CodeListIdentificationCode = "V",
			CodeListResponsibleAgencyCode = "s",
			ReligionName = "E",
		};

		var actual = Map.MapComposite<C101_ReligionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
