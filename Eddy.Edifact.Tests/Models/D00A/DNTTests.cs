using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class DNTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DNT+i+H+1+X+p";

		var expected = new DNT_DentalInformation()
		{
			ObjectIdentifier = "i",
			SurfaceOrLayerCode = "H",
			CavityZoneCode = "1",
			Quantity = "X",
			StatusDescriptionCode = "p",
		};

		var actual = Map.MapObject<DNT_DentalInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
