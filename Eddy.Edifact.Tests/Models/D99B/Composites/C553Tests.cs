using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C553Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "T:q:F:a";

		var expected = new C553_RelatedLocationTwoIdentification()
		{
			RelatedPlaceLocationTwoIdentification = "T",
			CodeListIdentificationCode = "q",
			CodeListResponsibleAgencyCode = "F",
			RelatedPlaceLocationTwo = "a",
		};

		var actual = Map.MapComposite<C553_RelatedLocationTwoIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
