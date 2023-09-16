using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class NBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NB*Ew*Bm*yfg1eU";

		var expected = new NB_LocationOfService()
		{
			CityName = "Ew",
			StateOrProvinceCode = "Bm",
			StandardPointLocationCode = "yfg1eU",
		};

		var actual = Map.MapObject<NB_LocationOfService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
