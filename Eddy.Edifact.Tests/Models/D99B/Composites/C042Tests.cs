using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C042Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "3:v:l:h";

		var expected = new C042_NationalityDetails()
		{
			NationalityCoded = "3",
			CodeListIdentificationCode = "v",
			CodeListResponsibleAgencyCode = "l",
			Nationality = "h",
		};

		var actual = Map.MapComposite<C042_NationalityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
