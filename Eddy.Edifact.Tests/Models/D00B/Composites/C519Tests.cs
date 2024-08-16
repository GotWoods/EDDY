using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C519Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "N:w:6:L";

		var expected = new C519_RelatedLocationOneIdentification()
		{
			FirstRelatedLocationNameCode = "N",
			CodeListIdentificationCode = "w",
			CodeListResponsibleAgencyCode = "6",
			FirstRelatedLocationName = "L",
		};

		var actual = Map.MapComposite<C519_RelatedLocationOneIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
