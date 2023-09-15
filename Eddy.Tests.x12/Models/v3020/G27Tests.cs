using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G27Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G27*p*C*R*sd*K*ta";

		var expected = new G27_CarrierDetail()
		{
			TransportationMethodTypeCode = "p",
			EquipmentInitial = "C",
			EquipmentNumber = "R",
			StandardCarrierAlphaCode = "sd",
			Routing = "K",
			ShipmentOrderStatusCode = "ta",
		};

		var actual = Map.MapObject<G27_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new G27_CarrierDetail();
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.StandardCarrierAlphaCode = "sd";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("sd", "K", true)]
	[InlineData("sd", "", true)]
	[InlineData("", "K", true)]
	public void Validation_AtLeastOneStandardCarrierAlphaCode(string standardCarrierAlphaCode, string routing, bool isValidExpected)
	{
		var subject = new G27_CarrierDetail();
		subject.TransportationMethodTypeCode = "p";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.Routing = routing;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
