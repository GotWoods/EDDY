using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C042Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:O:Y:U";

		var expected = new C042_NationalityDetails()
		{
			NationalityNameCode = "a",
			CodeListIdentificationCode = "O",
			CodeListResponsibleAgencyCode = "Y",
			NationalityName = "U",
		};

		var actual = Map.MapComposite<C042_NationalityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
