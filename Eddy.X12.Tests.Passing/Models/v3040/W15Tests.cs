using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class W15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W15*c5t2G5*u*g*T4*qv*I";

		var expected = new W15_WarehouseAdjustmentIdentification()
		{
			Date = "c5t2G5",
			WarehouseAdjustmentNumber = "u",
			DepositorAdjustmentNumber = "g",
			TransactionSetPurposeCode = "T4",
			TransactionTypeCode = "qv",
			ActionCode = "I",
		};

		var actual = Map.MapObject<W15_WarehouseAdjustmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c5t2G5", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new W15_WarehouseAdjustmentIdentification();
		//Required fields
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WarehouseAdjustmentNumber) || !string.IsNullOrEmpty(subject.WarehouseAdjustmentNumber) || !string.IsNullOrEmpty(subject.DepositorAdjustmentNumber))
		{
			subject.WarehouseAdjustmentNumber = "u";
			subject.DepositorAdjustmentNumber = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "g", true)]
	[InlineData("u", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredWarehouseAdjustmentNumber(string warehouseAdjustmentNumber, string depositorAdjustmentNumber, bool isValidExpected)
	{
		var subject = new W15_WarehouseAdjustmentIdentification();
		//Required fields
		subject.Date = "c5t2G5";
		//Test Parameters
		subject.WarehouseAdjustmentNumber = warehouseAdjustmentNumber;
		subject.DepositorAdjustmentNumber = depositorAdjustmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
