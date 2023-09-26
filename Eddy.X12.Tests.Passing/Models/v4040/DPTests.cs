using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class DPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DP*L*a*q*h*P*Uw*H*c*r*w*6*L*5*1*I*e*z";

		var expected = new DP_AutoClaimDetailParts()
		{
			ActionCode = "L",
			ProductServiceID = "a",
			Amount = "q",
			Amount2 = "h",
			YesNoConditionOrResponseCode = "P",
			ConditionIndicator = "Uw",
			YesNoConditionOrResponseCode2 = "H",
			YesNoConditionOrResponseCode3 = "c",
			YesNoConditionOrResponseCode4 = "r",
			YesNoConditionOrResponseCode5 = "w",
			Quantity = 6,
			ProductServiceID2 = "L",
			FreeFormDescription = "5",
			Percent = 1,
			AllowanceOrChargeTotalAmount = "I",
			YesNoConditionOrResponseCode6 = "e",
			YesNoConditionOrResponseCode7 = "z",
		};

		var actual = Map.MapObject<DP_AutoClaimDetailParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		//Required fields
		//Test Parameters
		subject.ActionCode = actionCode;
		//If one, at least one
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ProductServiceID) || !string.IsNullOrEmpty(subject.ProductServiceID2) || !string.IsNullOrEmpty(subject.FreeFormDescription))
		{
			subject.Quantity = 6;
			subject.ProductServiceID = "a";
			subject.ProductServiceID2 = "L";
			subject.FreeFormDescription = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", "", "", true)]
	[InlineData(6, "a", "L", "5", true)]
	[InlineData(6, "", "", "", false)]
	[InlineData(0, "a", "L", "5", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, string productServiceID, string productServiceID2, string freeFormDescription, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		//Required fields
		subject.ActionCode = "L";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		subject.ProductServiceID2 = productServiceID2;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
