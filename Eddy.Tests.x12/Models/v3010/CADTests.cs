using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAD*6*b*I*kR*5*Wx*wE*x";

		var expected = new CAD_CarrierDetail()
		{
			TransportationMethodTypeCode = "6",
			EquipmentInitial = "b",
			EquipmentNumber = "I",
			StandardCarrierAlphaCode = "kR",
			Routing = "5",
			ShipmentOrderStatusCode = "Wx",
			ReferenceNumberQualifier = "wE",
			ReferenceNumber = "x",
		};

		var actual = Map.MapObject<CAD_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
