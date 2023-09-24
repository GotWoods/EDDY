using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W08Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W08*H*uT*S*H*U*dF*WM*24*VV";

		var expected = new W08_ReceiptCarrierInformation()
		{
			TransportationMethodTypeCode = "H",
			StandardCarrierAlphaCode = "uT",
			Routing = "S",
			EquipmentInitial = "H",
			EquipmentNumber = "U",
			SealNumber = "dF",
			SealNumber2 = "WM",
			SealStatusCode = "24",
			UnitLoadOptionCode = "VV",
		};

		var actual = Map.MapObject<W08_ReceiptCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new W08_ReceiptCarrierInformation();
		//Required fields
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
