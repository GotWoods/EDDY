using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class N8ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8A*sZ*5*v1N9Ln*m*wo*ft*Mo*U*9*1";

		var expected = new N8A_AdditionalReferenceInformation()
		{
			WaybillCrossReferenceCode = "sZ",
			WaybillNumber = 5,
			Date = "v1N9Ln",
			ReferenceNumber = "m",
			CityName = "wo",
			StateOrProvinceCode = "ft",
			StandardCarrierAlphaCode = "Mo",
			FreightStationAccountingCode = "U",
			EquipmentInitial = "9",
			EquipmentNumber = "1",
		};

		var actual = Map.MapObject<N8A_AdditionalReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
