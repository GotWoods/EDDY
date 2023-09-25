using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class XBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XB*mlKVFE*9TIz*S*F8*0i*KZSCFr";

		var expected = new XB_SwitchRequestInformation()
		{
			Date = "mlKVFE",
			Time = "9TIz",
			Name = "S",
			CityName = "F8",
			StateOrProvinceCode = "0i",
			StandardPointLocationCode = "KZSCFr",
		};

		var actual = Map.MapObject<XB_SwitchRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
