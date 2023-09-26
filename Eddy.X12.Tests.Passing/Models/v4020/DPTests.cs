using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class DPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DP*w*e*m*1*F*SW*g*3*M*H*3*o*I*5*w*V*U";

		var expected = new DP_AutoClaimDetailParts()
		{
			ActionCode = "w",
			ProductServiceID = "e",
			Amount = "m",
			Amount2 = "1",
			YesNoConditionOrResponseCode = "F",
			ConditionIndicator = "SW",
			YesNoConditionOrResponseCode2 = "g",
			YesNoConditionOrResponseCode3 = "3",
			YesNoConditionOrResponseCode4 = "M",
			YesNoConditionOrResponseCode5 = "H",
			Quantity = 3,
			ProductServiceID2 = "o",
			FreeFormDescription = "I",
			Percent = 5,
			AllowanceOrChargeTotalAmount = "w",
			YesNoConditionOrResponseCode6 = "V",
			YesNoConditionOrResponseCode7 = "U",
		};

		var actual = Map.MapObject<DP_AutoClaimDetailParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
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
			subject.ProductServiceID = "e";
			subject.ProductServiceID2 = "o";
			subject.FreeFormDescription = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", "", "", true)]
	[InlineData(3, "e", "o", "I", true)]
	[InlineData(3, "", "", "", false)]
	[InlineData(0, "e", "o", "I", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, string productServiceID, string productServiceID2, string freeFormDescription, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		//Required fields
		subject.ActionCode = "w";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		subject.ProductServiceID2 = productServiceID2;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
