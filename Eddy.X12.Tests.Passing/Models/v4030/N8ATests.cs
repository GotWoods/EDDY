using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class N8ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8A*QX*6*qGNlyqkb*V*WH*h4*Ye*f*x*o";

		var expected = new N8A_AdditionalReferenceInformation()
		{
			WaybillCrossReferenceCode = "QX",
			WaybillNumber = 6,
			Date = "qGNlyqkb",
			ReferenceIdentification = "V",
			CityName = "WH",
			StateOrProvinceCode = "h4",
			StandardCarrierAlphaCode = "Ye",
			FreightStationAccountingCode = "f",
			EquipmentInitial = "x",
			EquipmentNumber = "o",
		};

		var actual = Map.MapObject<N8A_AdditionalReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
