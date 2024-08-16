using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E965Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Z:s";

		var expected = new E965_SpecialTravelFacilities()
		{
			FacilityTypeDescriptionCode = "Z",
			FacilityTypeDescription = "s",
		};

		var actual = Map.MapComposite<E965_SpecialTravelFacilities>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
