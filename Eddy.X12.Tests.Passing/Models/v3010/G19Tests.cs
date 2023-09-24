using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G19Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G19*9*dz*7*q4*N*XU*wx6qpuycYi4E*wQ*G";

		var expected = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences()
		{
			NumberOfUnitsShipped = 9,
			UnitOfMeasurementCode = "dz",
			QuantityDifference = 7,
			ShipmentOrderStatusCode = "q4",
			PriceReasonCode = "N",
			TermsExceptionCode = "XU",
			UPCCaseCode = "wx6qpuycYi4E",
			ProductServiceIDQualifier = "wQ",
			ProductServiceID = "G",
		};

		var actual = Map.MapObject<G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
