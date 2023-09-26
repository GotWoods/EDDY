using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class DPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DP*E*K*N*N*n*20*S*W*f*i*9*t*U*5*h*w*W";

		var expected = new DP_AutoClaimDetailParts()
		{
			ActionCode = "E",
			ProductServiceID = "K",
			Amount = "N",
			Amount2 = "N",
			YesNoConditionOrResponseCode = "n",
			ConditionIndicatorCode = "20",
			YesNoConditionOrResponseCode2 = "S",
			YesNoConditionOrResponseCode3 = "W",
			YesNoConditionOrResponseCode4 = "f",
			YesNoConditionOrResponseCode5 = "i",
			Quantity = 9,
			ProductServiceID2 = "t",
			FreeFormDescription = "U",
			PercentDecimalFormat = 5,
			AllowanceOrChargeTotalAmount = "h",
			YesNoConditionOrResponseCode6 = "w",
			YesNoConditionOrResponseCode7 = "W",
		};

		var actual = Map.MapObject<DP_AutoClaimDetailParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
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
			subject.ProductServiceID = "K";
			subject.ProductServiceID2 = "t";
			subject.FreeFormDescription = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", "", "", true)]
	[InlineData(9, "K", "t", "U", true)]
	[InlineData(9, "", "", "", false)]
	[InlineData(0, "K", "t", "U", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, string productServiceID, string productServiceID2, string freeFormDescription, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		//Required fields
		subject.ActionCode = "E";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		subject.ProductServiceID2 = productServiceID2;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
