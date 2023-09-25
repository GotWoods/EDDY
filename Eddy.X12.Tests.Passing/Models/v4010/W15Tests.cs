using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class W15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W15*q3auYXmg*l*b*Ba*RN*Z";

		var expected = new W15_WarehouseAdjustmentIdentification()
		{
			Date = "q3auYXmg",
			AdjustmentNumber = "l",
			AdjustmentNumber2 = "b",
			TransactionSetPurposeCode = "Ba",
			TransactionTypeCode = "RN",
			ActionCode = "Z",
		};

		var actual = Map.MapObject<W15_WarehouseAdjustmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q3auYXmg", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new W15_WarehouseAdjustmentIdentification();
		//Required fields
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AdjustmentNumber) || !string.IsNullOrEmpty(subject.AdjustmentNumber) || !string.IsNullOrEmpty(subject.AdjustmentNumber2))
		{
			subject.AdjustmentNumber = "l";
			subject.AdjustmentNumber2 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "b", true)]
	[InlineData("l", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredAdjustmentNumber(string adjustmentNumber, string adjustmentNumber2, bool isValidExpected)
	{
		var subject = new W15_WarehouseAdjustmentIdentification();
		//Required fields
		subject.Date = "q3auYXmg";
		//Test Parameters
		subject.AdjustmentNumber = adjustmentNumber;
		subject.AdjustmentNumber2 = adjustmentNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
