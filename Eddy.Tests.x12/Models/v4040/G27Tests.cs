using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class G27Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G27*1*A*2*pd*P*eh";

		var expected = new G27_CarrierDetail()
		{
			TransportationMethodTypeCode = "1",
			EquipmentInitial = "A",
			EquipmentNumber = "2",
			StandardCarrierAlphaCode = "pd",
			Routing = "P",
			ShipmentOrderStatusCode = "eh",
		};

		var actual = Map.MapObject<G27_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new G27_CarrierDetail();
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.StandardCarrierAlphaCode = "pd";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("pd", "P", true)]
	[InlineData("pd", "", true)]
	[InlineData("", "P", true)]
	public void Validation_AtLeastOneStandardCarrierAlphaCode(string standardCarrierAlphaCode, string routing, bool isValidExpected)
	{
		var subject = new G27_CarrierDetail();
		subject.TransportationMethodTypeCode = "1";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.Routing = routing;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
