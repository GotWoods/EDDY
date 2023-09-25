using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TBATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBA*tz*7*5";

		var expected = new TBA_TemporaryBuydownAdjustment()
		{
			UnitOfMeasurementCode = "tz",
			Quantity = 7,
			Percent = 5,
		};

		var actual = Map.MapObject<TBA_TemporaryBuydownAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "tz", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "tz", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new TBA_TemporaryBuydownAdjustment();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
