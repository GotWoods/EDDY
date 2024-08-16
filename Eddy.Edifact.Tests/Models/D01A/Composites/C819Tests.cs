using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01A;
using Eddy.Edifact.Models.D01A.Composites;

namespace Eddy.Edifact.Tests.Models.D01A.Composites;

public class C819Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "C:N:Z:e";

		var expected = new C819_CountrySubEntityDetails()
		{
			CountrySubEntityNameCode = "C",
			CodeListIdentificationCode = "N",
			CodeListResponsibleAgencyCode = "Z",
			CountrySubEntityName = "e",
		};

		var actual = Map.MapComposite<C819_CountrySubEntityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
