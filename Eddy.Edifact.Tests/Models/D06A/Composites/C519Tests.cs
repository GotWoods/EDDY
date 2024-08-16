using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class C519Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "8:0:Y:N";

		var expected = new C519_RelatedLocationOneIdentification()
		{
			FirstRelatedLocationIdentifier = "8",
			CodeListIdentificationCode = "0",
			CodeListResponsibleAgencyCode = "Y",
			FirstRelatedLocationName = "N",
		};

		var actual = Map.MapComposite<C519_RelatedLocationOneIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
