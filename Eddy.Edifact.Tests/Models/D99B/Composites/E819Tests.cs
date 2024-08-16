using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E819Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "U:p:E:2";

		var expected = new E819_CountrySubEntityDetails()
		{
			CountrySubEntityNameCode = "U",
			CodeListIdentificationCode = "p",
			CodeListResponsibleAgencyCode = "E",
			CountrySubEntityName = "2",
		};

		var actual = Map.MapComposite<E819_CountrySubEntityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
