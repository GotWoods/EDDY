using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class IT3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT3*2*f9*EM*5*d5";

		var expected = new IT3_AdditionalItemData()
		{
			NumberOfUnitsShipped = 2,
			UnitOrBasisForMeasurementCode = "f9",
			ShipmentOrderStatusCode = "EM",
			QuantityDifference = 5,
			ChangeReasonCode = "d5",
		};

		var actual = Map.MapObject<IT3_AdditionalItemData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "f9", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "f9", true)]
	public void Validation_ARequiresBNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new IT3_AdditionalItemData();
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
