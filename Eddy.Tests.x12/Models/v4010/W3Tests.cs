using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class W3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W3*8*pZR81EEN*4y*sx*vi*x";

		var expected = new W3_ConsigneeInformation()
		{
			WaybillNumber = 8,
			Date = "pZR81EEN",
			AbbreviatedCustomerName = "4y",
			CityName = "sx",
			StateOrProvinceCode = "vi",
			CityNameQualifierCode = "x",
		};

		var actual = Map.MapObject<W3_ConsigneeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
