using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C553Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "S:0:G:N";

		var expected = new C553_RelatedLocationTwoIdentification()
		{
			RelatedPlaceLocationTwoIdentification = "S",
			CodeListQualifier = "0",
			CodeListResponsibleAgencyCoded = "G",
			RelatedPlaceLocationTwo = "N",
		};

		var actual = Map.MapComposite<C553_RelatedLocationTwoIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
