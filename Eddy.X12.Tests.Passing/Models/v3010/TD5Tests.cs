using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TD5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD5*d*0*Xf*s*r*lN*Y*l*Hc*Fl*8";

		var expected = new TD5_CarrierDetailsRoutingSequenceTransitTime()
		{
			RoutingSequenceCode = "d",
			IdentificationCodeQualifier = "0",
			IdentificationCode = "Xf",
			TransportationMethodTypeCode = "s",
			Routing = "r",
			ShipmentOrderStatusCode = "lN",
			LocationQualifier = "Y",
			LocationIdentifier = "l",
			TransitDirectionCode = "Hc",
			TransitTimeDirectionQualifier = "Fl",
			TransitTime = 8,
		};

		var actual = Map.MapObject<TD5_CarrierDetailsRoutingSequenceTransitTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
