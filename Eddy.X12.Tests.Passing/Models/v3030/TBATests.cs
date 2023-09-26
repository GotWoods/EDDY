using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TBATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBA*ij*9*2";

		var expected = new TBA_TemporaryBuydownAdjustment()
		{
			UnitOrBasisForMeasurementCode = "ij",
			Quantity = 9,
			Percent = 2,
		};

		var actual = Map.MapObject<TBA_TemporaryBuydownAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "ij", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "ij", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new TBA_TemporaryBuydownAdjustment();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
