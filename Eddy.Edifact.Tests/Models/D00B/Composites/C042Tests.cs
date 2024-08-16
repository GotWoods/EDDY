using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C042Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "8:w:I:Z";

		var expected = new C042_NationalityDetails()
		{
			NationalityNameCode = "8",
			CodeListIdentificationCode = "w",
			CodeListResponsibleAgencyCode = "I",
			NationalityName = "Z",
		};

		var actual = Map.MapComposite<C042_NationalityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
