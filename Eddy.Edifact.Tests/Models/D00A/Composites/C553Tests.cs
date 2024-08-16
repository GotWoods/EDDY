using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C553Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "o:q:z:e";

		var expected = new C553_RelatedLocationTwoIdentification()
		{
			SecondRelatedLocationNameCode = "o",
			CodeListIdentificationCode = "q",
			CodeListResponsibleAgencyCode = "z",
			SecondRelatedLocationName = "e",
		};

		var actual = Map.MapComposite<C553_RelatedLocationTwoIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
