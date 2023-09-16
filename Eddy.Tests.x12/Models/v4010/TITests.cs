using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TI*DC*gY*i*K*oOxmtx7I*aD*L";

		var expected = new TI_TransportInformation()
		{
			StandardCarrierAlphaCode = "DC",
			StandardCarrierAlphaCode2 = "gY",
			EquipmentInitial = "i",
			EquipmentNumber = "K",
			Date = "oOxmtx7I",
			SealStatusCode = "aD",
			CarTypeCode = "L",
		};

		var actual = Map.MapObject<TI_TransportInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
