using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G27Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G27*C*x*E*dP*m*s2";

		var expected = new G27_CarrierDetail()
		{
			TransportationMethodTypeCode = "C",
			EquipmentInitial = "x",
			EquipmentNumber = "E",
			StandardCarrierAlphaCode = "dP",
			Routing = "m",
			ShipmentOrderStatusCode = "s2",
		};

		var actual = Map.MapObject<G27_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new G27_CarrierDetail();
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
