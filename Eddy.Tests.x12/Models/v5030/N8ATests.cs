using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class N8ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8A*JP*3*G94x7Q2L*p*1a*dd*X0*q*8*z";

		var expected = new N8A_AdditionalReferenceInformation()
		{
			WaybillCrossReferenceCode = "JP",
			WaybillNumber = 3,
			Date = "G94x7Q2L",
			ReferenceIdentification = "p",
			CityName = "1a",
			StateOrProvinceCode = "dd",
			StandardCarrierAlphaCode = "X0",
			FreightStationAccountingCode = "q",
			EquipmentInitial = "8",
			EquipmentNumber = "z",
		};

		var actual = Map.MapObject<N8A_AdditionalReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
