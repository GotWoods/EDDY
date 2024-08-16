using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C042Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "6:9:T:y";

		var expected = new C042_NationalityDetails()
		{
			NationalityCoded = "6",
			CodeListQualifier = "9",
			CodeListResponsibleAgencyCoded = "T",
			Nationality = "y",
		};

		var actual = Map.MapComposite<C042_NationalityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
