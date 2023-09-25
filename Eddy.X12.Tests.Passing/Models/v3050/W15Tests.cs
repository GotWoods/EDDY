using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class W15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W15*Xv85kb*A*E*HO*u6*I";

		var expected = new W15_WarehouseAdjustmentIdentification()
		{
			Date = "Xv85kb",
			AdjustmentNumber = "A",
			AdjustmentNumber2 = "E",
			TransactionSetPurposeCode = "HO",
			TransactionTypeCode = "u6",
			ActionCode = "I",
		};

		var actual = Map.MapObject<W15_WarehouseAdjustmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xv85kb", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new W15_WarehouseAdjustmentIdentification();
		//Required fields
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AdjustmentNumber) || !string.IsNullOrEmpty(subject.AdjustmentNumber) || !string.IsNullOrEmpty(subject.AdjustmentNumber2))
		{
			subject.AdjustmentNumber = "A";
			subject.AdjustmentNumber2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "E", true)]
	[InlineData("A", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredAdjustmentNumber(string adjustmentNumber, string adjustmentNumber2, bool isValidExpected)
	{
		var subject = new W15_WarehouseAdjustmentIdentification();
		//Required fields
		subject.Date = "Xv85kb";
		//Test Parameters
		subject.AdjustmentNumber = adjustmentNumber;
		subject.AdjustmentNumber2 = adjustmentNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
