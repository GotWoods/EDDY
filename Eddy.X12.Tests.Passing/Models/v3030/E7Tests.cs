using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class E7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E7*Sx*Hd*shscyd*sD*dRvdMX*OPus";

		var expected = new E7_CarHandlingInformation()
		{
			CityName = "Sx",
			StateOrProvinceCode = "Hd",
			StandardPointLocationCode = "shscyd",
			RailCarStatusOrderCode = "sD",
			Date = "dRvdMX",
			Time = "OPus",
		};

		var actual = Map.MapObject<E7_CarHandlingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
