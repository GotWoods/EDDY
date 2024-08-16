using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class C819Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "1:f:L:l";

		var expected = new C819_CountrySubdivisionDetails()
		{
			CountrySubdivisionIdentifier = "1",
			CodeListIdentificationCode = "f",
			CodeListResponsibleAgencyCode = "L",
			CountrySubdivisionName = "l",
		};

		var actual = Map.MapComposite<C819_CountrySubdivisionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
