using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C101Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "y:t:x:J";

		var expected = new C101_ReligionDetails()
		{
			ReligionNameCode = "y",
			CodeListIdentificationCode = "t",
			CodeListResponsibleAgencyCode = "x",
			ReligionName = "J",
		};

		var actual = Map.MapComposite<C101_ReligionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
