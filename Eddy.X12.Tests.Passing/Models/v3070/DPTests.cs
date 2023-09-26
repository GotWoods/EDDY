using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class DPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DP*s*r*J*M*k*Fa*z*Z*z*f*6*t*R*1*H*q";

		var expected = new DP_AutoClaimDetailParts()
		{
			ActionCode = "s",
			ProductServiceID = "r",
			Amount = "J",
			Amount2 = "M",
			YesNoConditionOrResponseCode = "k",
			ConditionIndicator = "Fa",
			YesNoConditionOrResponseCode2 = "z",
			YesNoConditionOrResponseCode3 = "Z",
			YesNoConditionOrResponseCode4 = "z",
			YesNoConditionOrResponseCode5 = "f",
			Quantity = 6,
			ProductServiceID2 = "t",
			FreeFormDescription = "R",
			Percent = 1,
			AllowanceOrChargeTotalAmount = "H",
			YesNoConditionOrResponseCode6 = "q",
		};

		var actual = Map.MapObject<DP_AutoClaimDetailParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
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
			subject.ProductServiceID = "r";
			subject.ProductServiceID2 = "t";
			subject.FreeFormDescription = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", "", "", true)]
	[InlineData(6, "r", "t", "R", true)]
	[InlineData(6, "", "", "", false)]
	[InlineData(0, "r", "t", "R", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, string productServiceID, string productServiceID2, string freeFormDescription, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		//Required fields
		subject.ActionCode = "s";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		subject.ProductServiceID2 = productServiceID2;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
