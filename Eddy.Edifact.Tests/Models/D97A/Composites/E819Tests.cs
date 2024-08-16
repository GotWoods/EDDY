using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E819Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "F:2:g:0";

		var expected = new E819_CountrySubEntityDetails()
		{
			CountrySubEntityIdentification = "F",
			CodeListQualifier = "2",
			CodeListResponsibleAgencyCoded = "g",
			CountrySubEntity = "0",
		};

		var actual = Map.MapComposite<E819_CountrySubEntityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
