using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W3*4*wHDRvP*u7*Hf*Yc*E";

		var expected = new W3_ConsigneeInformation()
		{
			WaybillNumber = 4,
			WaybillDate = "wHDRvP",
			AbbreviatedCustomerName = "u7",
			CityName = "Hf",
			StateOrProvinceCode = "Yc",
			CityNameQualifierCode = "E",
		};

		var actual = Map.MapObject<W3_ConsigneeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
