using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E819Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "5:G:i:1";

		var expected = new E819_CountrySubEntityDetails()
		{
			CountrySubdivisionIdentifier = "5",
			CodeListIdentificationCode = "G",
			CodeListResponsibleAgencyCode = "i",
			CountrySubdivisionName = "1",
		};

		var actual = Map.MapComposite<E819_CountrySubEntityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
