using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DP*O*F*z*y*k*X4*j*E*d*6*7*f*e*2*d*f*L";

		var expected = new DP_AutoClaimDetailParts()
		{
			ActionCode = "O",
			ProductServiceID = "F",
			Amount = "z",
			Amount2 = "y",
			YesNoConditionOrResponseCode = "k",
			ConditionIndicatorCode = "X4",
			YesNoConditionOrResponseCode2 = "j",
			YesNoConditionOrResponseCode3 = "E",
			YesNoConditionOrResponseCode4 = "d",
			YesNoConditionOrResponseCode5 = "6",
			Quantity = 7,
			ProductServiceID2 = "f",
			FreeFormDescription = "e",
			PercentDecimalFormat = 2,
			AllowanceOrChargeTotalAmount = "d",
			YesNoConditionOrResponseCode6 = "f",
			YesNoConditionOrResponseCode7 = "L",
		};

		var actual = Map.MapObject<DP_AutoClaimDetailParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validatation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", "", "", true)]
	[InlineData(7, "", "", "", false)]
    [InlineData(7, "A", "", "",  true)]
    [InlineData(7, "", "A", "", true)]
    [InlineData(7, "", "", "A", true)]
    public void Validation_NEWQuantity(decimal quantity, string productServiceID, string productServiceID2, string freeFormDescription, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		subject.ActionCode = "O";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		subject.ProductServiceID2 = productServiceID2;
		subject.FreeFormDescription = freeFormDescription;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
