using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W3*4*YazFhd*SS*BZ*N9*E";

		var expected = new W3_ConsigneeInformation()
		{
			WaybillNumber = 4,
			Date = "YazFhd",
			AbbreviatedCustomerName = "SS",
			CityName = "BZ",
			StateOrProvinceCode = "N9",
			CityNameQualifierCode = "E",
		};

		var actual = Map.MapObject<W3_ConsigneeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
