using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W15*VsNOKk*R*F";

		var expected = new W15_WarehouseAdjustmentIdentification()
		{
			Date = "VsNOKk",
			WarehouseAdjustmentNumber = "R",
			DepositorAdjustmentNumber = "F",
		};

		var actual = Map.MapObject<W15_WarehouseAdjustmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VsNOKk", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new W15_WarehouseAdjustmentIdentification();
		//Required fields
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WarehouseAdjustmentNumber) || !string.IsNullOrEmpty(subject.WarehouseAdjustmentNumber) || !string.IsNullOrEmpty(subject.DepositorAdjustmentNumber))
		{
			subject.WarehouseAdjustmentNumber = "R";
			subject.DepositorAdjustmentNumber = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "F", true)]
	[InlineData("R", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredWarehouseAdjustmentNumber(string warehouseAdjustmentNumber, string depositorAdjustmentNumber, bool isValidExpected)
	{
		var subject = new W15_WarehouseAdjustmentIdentification();
		//Required fields
		subject.Date = "VsNOKk";
		//Test Parameters
		subject.WarehouseAdjustmentNumber = warehouseAdjustmentNumber;
		subject.DepositorAdjustmentNumber = depositorAdjustmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
