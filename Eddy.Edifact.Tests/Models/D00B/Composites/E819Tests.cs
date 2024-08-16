using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E819Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "e:M:j:9";

		var expected = new E819_CountrySubEntityDetails()
		{
			CountrySubEntityNameCode = "e",
			CodeListIdentificationCode = "M",
			CodeListResponsibleAgencyCode = "j",
			CountrySubEntityName = "9",
		};

		var actual = Map.MapComposite<E819_CountrySubEntityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
