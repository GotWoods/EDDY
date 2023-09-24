using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class E7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E7*MR*sN*Vc6FK2*kj*5FojvP*c6YA";

		var expected = new E7_CarHandlingInformation()
		{
			CityName = "MR",
			StateOrProvinceCode = "sN",
			StandardPointLocationCode = "Vc6FK2",
			RailCarStatusOrderCode = "kj",
			Date = "5FojvP",
			Time = "c6YA",
		};

		var actual = Map.MapObject<E7_CarHandlingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
