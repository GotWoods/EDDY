using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C553Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "R:L:A:G";

		var expected = new C553_RelatedLocationTwoIdentification()
		{
			SecondRelatedLocationNameCode = "R",
			CodeListIdentificationCode = "L",
			CodeListResponsibleAgencyCode = "A",
			SecondRelatedLocationName = "G",
		};

		var actual = Map.MapComposite<C553_RelatedLocationTwoIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
