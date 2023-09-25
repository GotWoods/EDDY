using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class N8ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8A*Cf*3*tVVfJfF4*W*qg*2L*FY*2*a*0";

		var expected = new N8A_AdditionalReferenceInformation()
		{
			WaybillCrossReferenceCode = "Cf",
			WaybillNumber = 3,
			Date = "tVVfJfF4",
			ReferenceIdentification = "W",
			CityName = "qg",
			StateOrProvinceCode = "2L",
			StandardCarrierAlphaCode = "FY",
			FreightStationAccountingCode = "2",
			EquipmentInitial = "a",
			EquipmentNumber = "0",
		};

		var actual = Map.MapObject<N8A_AdditionalReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
