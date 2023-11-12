using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class E7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E7*hU*rP*0beZk7*Yo*lifIqY*TpfC";

		var expected = new E7_CarHandlingInformation()
		{
			CityName = "hU",
			StateOrProvinceCode = "rP",
			StandardPointLocationCode = "0beZk7",
			RailCarStatusOrderCode = "Yo",
			Date = "lifIqY",
			Time = "TpfC",
		};

		var actual = Map.MapObject<E7_CarHandlingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
