using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C519Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "H:i:q:E";

		var expected = new C519_RelatedLocationOneIdentification()
		{
			FirstRelatedLocationNameCode = "H",
			CodeListIdentificationCode = "i",
			CodeListResponsibleAgencyCode = "q",
			FirstRelatedLocationName = "E",
		};

		var actual = Map.MapComposite<C519_RelatedLocationOneIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
