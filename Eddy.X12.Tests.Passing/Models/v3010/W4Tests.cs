using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W4*1q*lp*S*Nt*Hn";

		var expected = new W4_ConsignorInformation()
		{
			AbbreviatedCustomerName = "1q",
			StandardCarrierAlphaCode = "lp",
			FreightStationAccountingCode = "S",
			CityName = "Nt",
			StateOrProvinceCode = "Hn",
		};

		var actual = Map.MapObject<W4_ConsignorInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
