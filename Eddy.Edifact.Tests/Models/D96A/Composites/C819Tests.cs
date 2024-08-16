using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C819Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "q:p:f:3";

		var expected = new C819_CountrySubEntityDetails()
		{
			CountrySubEntityIdentification = "q",
			CodeListQualifier = "p",
			CodeListResponsibleAgencyCoded = "f",
			CountrySubEntity = "3",
		};

		var actual = Map.MapComposite<C819_CountrySubEntityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
