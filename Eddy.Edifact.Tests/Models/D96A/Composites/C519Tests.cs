using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C519Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:N:f:f";

		var expected = new C519_RelatedLocationOneIdentification()
		{
			RelatedPlaceLocationOneIdentification = "M",
			CodeListQualifier = "N",
			CodeListResponsibleAgencyCoded = "f",
			RelatedPlaceLocationOne = "f",
		};

		var actual = Map.MapComposite<C519_RelatedLocationOneIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
