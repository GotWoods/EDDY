using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C519Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "L:R:Q:m";

		var expected = new C519_RelatedLocationOneIdentification()
		{
			RelatedPlaceLocationOneIdentification = "L",
			CodeListIdentificationCode = "R",
			CodeListResponsibleAgencyCode = "Q",
			RelatedPlaceLocationOne = "m",
		};

		var actual = Map.MapComposite<C519_RelatedLocationOneIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
