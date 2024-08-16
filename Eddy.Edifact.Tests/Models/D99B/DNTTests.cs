using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class DNTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DNT+C+C+q+a+e";

		var expected = new DNT_DentalInformation()
		{
			ObjectIdentifier = "C",
			SurfaceLayerCode = "C",
			CavityZoneCode = "q",
			Quantity = "a",
			StatusDescriptionCode = "e",
		};

		var actual = Map.MapObject<DNT_DentalInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
