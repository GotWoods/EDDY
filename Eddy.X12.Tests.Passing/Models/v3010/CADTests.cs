using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAD*3*b*d*Ff*Z*e1*Oh*3";

		var expected = new CAD_CarrierDetail()
		{
			TransportationMethodTypeCode = "3",
			EquipmentInitial = "b",
			EquipmentNumber = "d",
			StandardCarrierAlphaCode = "Ff",
			Routing = "Z",
			ShipmentOrderStatusCode = "e1",
			ReferenceNumberQualifier = "Oh",
			ReferenceNumber = "3",
		};

		var actual = Map.MapObject<CAD_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
