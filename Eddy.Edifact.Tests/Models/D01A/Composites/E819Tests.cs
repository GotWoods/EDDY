using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01A;
using Eddy.Edifact.Models.D01A.Composites;

namespace Eddy.Edifact.Tests.Models.D01A.Composites;

public class E819Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:R:H:j";

		var expected = new E819_CountrySubEntityDetails()
		{
			CountrySubEntityNameCode = "k",
			CodeListIdentificationCode = "R",
			CodeListResponsibleAgencyCode = "H",
			CountrySubEntityName = "j",
		};

		var actual = Map.MapComposite<E819_CountrySubEntityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
