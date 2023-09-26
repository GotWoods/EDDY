using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class N8ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8A*FR*7*gkDR78rR*Y*QU*7o*Aa*i*s*Z";

		var expected = new N8A_AdditionalReferenceInformation()
		{
			WaybillCrossReferenceCode = "FR",
			WaybillNumber = 7,
			Date = "gkDR78rR",
			ReferenceIdentification = "Y",
			CityName = "QU",
			StateOrProvinceCode = "7o",
			StandardCarrierAlphaCode = "Aa",
			FreightStationAccountingCode = "i",
			EquipmentInitial = "s",
			EquipmentNumber = "Z",
		};

		var actual = Map.MapObject<N8A_AdditionalReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
