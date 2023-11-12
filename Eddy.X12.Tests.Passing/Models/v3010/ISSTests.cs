using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ISSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISS*6*L0*7*nt*2*0g";

		var expected = new ISS_InvoiceShipmentSummary()
		{
			NumberOfUnitsShipped = 6,
			UnitOfMeasurementCode = "L0",
			Weight = 7,
			UnitOfMeasurementCode2 = "nt",
			Volume = 2,
			UnitOfMeasurementCode3 = "0g",
		};

		var actual = Map.MapObject<ISS_InvoiceShipmentSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
