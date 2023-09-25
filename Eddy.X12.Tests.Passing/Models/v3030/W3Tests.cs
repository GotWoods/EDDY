using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W3*6*1M7aAx*3L*3N*6t*b";

		var expected = new W3_ConsigneeInformation()
		{
			WaybillNumber = 6,
			Date = "1M7aAx",
			AbbreviatedCustomerName = "3L",
			CityName = "3N",
			StateOrProvinceCode = "6t",
			CityNameQualifierCode = "b",
		};

		var actual = Map.MapObject<W3_ConsigneeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
