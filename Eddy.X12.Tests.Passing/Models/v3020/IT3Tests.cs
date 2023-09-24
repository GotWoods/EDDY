using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class IT3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT3*8*Bk*IX*7*t2";

		var expected = new IT3_AdditionalItemData()
		{
			NumberOfUnitsShipped = 8,
			UnitOfMeasurementCode = "Bk",
			ShipmentOrderStatusCode = "IX",
			QuantityDifference = 7,
			ChangeReasonCode = "t2",
		};

		var actual = Map.MapObject<IT3_AdditionalItemData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "Bk", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "Bk", true)]
	public void Validation_ARequiresBNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new IT3_AdditionalItemData();
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
