using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C819Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "t:3:U:m";

		var expected = new C819_CountrySubEntityDetails()
		{
			CountrySubEntityNameCode = "t",
			CodeListIdentificationCode = "3",
			CodeListResponsibleAgencyCode = "U",
			CountrySubEntityName = "m",
		};

		var actual = Map.MapComposite<C819_CountrySubEntityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
