using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W15*SqlyyZHH*B*b*a9*ei*d";

		var expected = new W15_WarehouseAdjustmentIdentification()
		{
			Date = "SqlyyZHH",
			AdjustmentNumber = "B",
			AdjustmentNumber2 = "b",
			TransactionSetPurposeCode = "a9",
			TransactionTypeCode = "ei",
			ActionCode = "d",
		};

		var actual = Map.MapObject<W15_WarehouseAdjustmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SqlyyZHH", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new W15_WarehouseAdjustmentIdentification();
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("B","b", true)]
	[InlineData("", "b", true)]
	[InlineData("B", "", true)]
	public void Validation_AtLeastOneAdjustmentNumber(string adjustmentNumber, string adjustmentNumber2, bool isValidExpected)
	{
		var subject = new W15_WarehouseAdjustmentIdentification();
		subject.Date = "SqlyyZHH";
		subject.AdjustmentNumber = adjustmentNumber;
		subject.AdjustmentNumber2 = adjustmentNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
