using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E965Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "F:v";

		var expected = new E965_SpecialTravelFacilities()
		{
			FacilityTypeCoded = "F",
			FacilityTypeDescription = "v",
		};

		var actual = Map.MapComposite<E965_SpecialTravelFacilities>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
