using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IT3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT3*8*n9*uD*4*bK";

		var expected = new IT3_AdditionalItemData()
		{
			NumberOfUnitsShipped = 8,
			UnitOrBasisForMeasurementCode = "n9",
			ShipmentOrderStatusCode = "uD",
			QuantityDifference = 4,
			ChangeReasonCode = "bK",
		};

		var actual = Map.MapObject<IT3_AdditionalItemData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "n9", true)]
	[InlineData(0, "n9", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new IT3_AdditionalItemData();
		if (numberOfUnitsShipped > 0)
		subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
