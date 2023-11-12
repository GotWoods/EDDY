using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class DPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DP*t*2*J*P*R*MO*w*Q*f*y*9*l*j*7*D*A*G";

		var expected = new DP_AutoClaimDetailParts()
		{
			ActionCode = "t",
			ProductServiceID = "2",
			Amount = "J",
			Amount2 = "P",
			YesNoConditionOrResponseCode = "R",
			ConditionIndicator = "MO",
			YesNoConditionOrResponseCode2 = "w",
			YesNoConditionOrResponseCode3 = "Q",
			YesNoConditionOrResponseCode4 = "f",
			YesNoConditionOrResponseCode5 = "y",
			Quantity = 9,
			ProductServiceID2 = "l",
			FreeFormDescription = "j",
			PercentDecimalFormat = 7,
			AllowanceOrChargeTotalAmount = "D",
			YesNoConditionOrResponseCode6 = "A",
			YesNoConditionOrResponseCode7 = "G",
		};

		var actual = Map.MapObject<DP_AutoClaimDetailParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		//Required fields
		//Test Parameters
		subject.ActionCode = actionCode;
		//If one, at least one
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ProductServiceID) || !string.IsNullOrEmpty(subject.ProductServiceID2) || !string.IsNullOrEmpty(subject.FreeFormDescription))
		{
			subject.Quantity = 9;
			subject.ProductServiceID = "2";
			subject.ProductServiceID2 = "l";
			subject.FreeFormDescription = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", "", "", true)]
	[InlineData(9, "2", "l", "j", true)]
	[InlineData(9, "", "", "", false)]
	[InlineData(0, "2", "l", "j", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, string productServiceID, string productServiceID2, string freeFormDescription, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		//Required fields
		subject.ActionCode = "t";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		subject.ProductServiceID2 = productServiceID2;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
