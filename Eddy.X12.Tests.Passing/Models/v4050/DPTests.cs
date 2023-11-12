using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class DPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DP*9*S*X*D*7*Hi*W*A*Z*E*3*S*3*6*m*E*P";

		var expected = new DP_AutoClaimDetailParts()
		{
			ActionCode = "9",
			ProductServiceID = "S",
			Amount = "X",
			Amount2 = "D",
			YesNoConditionOrResponseCode = "7",
			ConditionIndicator = "Hi",
			YesNoConditionOrResponseCode2 = "W",
			YesNoConditionOrResponseCode3 = "A",
			YesNoConditionOrResponseCode4 = "Z",
			YesNoConditionOrResponseCode5 = "E",
			Quantity = 3,
			ProductServiceID2 = "S",
			FreeFormDescription = "3",
			PercentDecimalFormat = 6,
			AllowanceOrChargeTotalAmount = "m",
			YesNoConditionOrResponseCode6 = "E",
			YesNoConditionOrResponseCode7 = "P",
		};

		var actual = Map.MapObject<DP_AutoClaimDetailParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		//Required fields
		//Test Parameters
		subject.ActionCode = actionCode;
		//If one, at least one
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ProductServiceID) || !string.IsNullOrEmpty(subject.ProductServiceID2) || !string.IsNullOrEmpty(subject.FreeFormDescription))
		{
			subject.Quantity = 3;
			subject.ProductServiceID = "S";
			subject.ProductServiceID2 = "S";
			subject.FreeFormDescription = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", "", "", true)]
	[InlineData(3, "S", "S", "3", true)]
	[InlineData(3, "", "", "", false)]
	[InlineData(0, "S", "S", "3", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, string productServiceID, string productServiceID2, string freeFormDescription, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		//Required fields
		subject.ActionCode = "9";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		subject.ProductServiceID2 = productServiceID2;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
