using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C819Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:k:Y:y";

		var expected = new C819_CountrySubEntityDetails()
		{
			CountrySubEntityNameCode = "G",
			CodeListIdentificationCode = "k",
			CodeListResponsibleAgencyCode = "Y",
			CountrySubEntityName = "y",
		};

		var actual = Map.MapComposite<C819_CountrySubEntityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
