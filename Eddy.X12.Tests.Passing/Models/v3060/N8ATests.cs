using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class N8ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8A*TO*1*7pXsS6*u*fM*W0*uj*G*d*F";

		var expected = new N8A_AdditionalReferenceInformation()
		{
			WaybillCrossReferenceCode = "TO",
			WaybillNumber = 1,
			Date = "7pXsS6",
			ReferenceIdentification = "u",
			CityName = "fM",
			StateOrProvinceCode = "W0",
			StandardCarrierAlphaCode = "uj",
			FreightStationAccountingCode = "G",
			EquipmentInitial = "d",
			EquipmentNumber = "F",
		};

		var actual = Map.MapObject<N8A_AdditionalReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
