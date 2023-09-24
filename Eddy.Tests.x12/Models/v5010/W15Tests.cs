using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class W15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W15*0f8Fgeyn*O*c*Ps*kn*q";

		var expected = new W15_WarehouseAdjustmentIdentification()
		{
			Date = "0f8Fgeyn",
			AdjustmentNumber = "O",
			AdjustmentNumber2 = "c",
			TransactionSetPurposeCode = "Ps",
			TransactionTypeCode = "kn",
			ActionCode = "q",
		};

		var actual = Map.MapObject<W15_WarehouseAdjustmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0f8Fgeyn", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new W15_WarehouseAdjustmentIdentification();
		//Required fields
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.AdjustmentNumber = "O";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("O", "c", true)]
	[InlineData("O", "", true)]
	[InlineData("", "c", true)]
	public void Validation_AtLeastOneAdjustmentNumber(string adjustmentNumber, string adjustmentNumber2, bool isValidExpected)
	{
		var subject = new W15_WarehouseAdjustmentIdentification();
		//Required fields
		subject.Date = "0f8Fgeyn";
		//Test Parameters
		subject.AdjustmentNumber = adjustmentNumber;
		subject.AdjustmentNumber2 = adjustmentNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
