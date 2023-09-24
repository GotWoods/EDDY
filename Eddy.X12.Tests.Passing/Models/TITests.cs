using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TI*DL*Vy*Z*0*fdUGSnGL*lV*h";

		var expected = new TI_TransportInformation()
		{
			StandardCarrierAlphaCode = "DL",
			StandardCarrierAlphaCode2 = "Vy",
			EquipmentInitial = "Z",
			EquipmentNumber = "0",
			Date = "fdUGSnGL",
			SealStatusCode = "lV",
			CarTypeCode = "h",
		};

		var actual = Map.MapObject<TI_TransportInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
