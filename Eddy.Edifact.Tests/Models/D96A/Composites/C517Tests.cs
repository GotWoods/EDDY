using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C517Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "N:a:8:i";

		var expected = new C517_LocationIdentification()
		{
			PlaceLocationIdentification = "N",
			CodeListQualifier = "a",
			CodeListResponsibleAgencyCoded = "8",
			PlaceLocation = "i",
		};

		var actual = Map.MapComposite<C517_LocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
