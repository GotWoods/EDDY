using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C235Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "b:j45A";

		var expected = new C235_HazardIdentificationPlacardDetails()
		{
			OrangeHazardPlacardUpperPartIdentifier = "b",
			OrangeHazardPlacardLowerPartIdentifier = "j45A",
		};

		var actual = Map.MapComposite<C235_HazardIdentificationPlacardDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
