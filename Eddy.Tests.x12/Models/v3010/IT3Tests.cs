using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class IT3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT3*1*s9*W5*4*P3";

		var expected = new IT3_AdditionalItemData()
		{
			NumberOfUnitsShipped = 1,
			UnitOfMeasurementCode = "s9",
			ShipmentOrderStatusCode = "W5",
			QuantityDifference = 4,
			ChangeReasonCode = "P3",
		};

		var actual = Map.MapObject<IT3_AdditionalItemData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
