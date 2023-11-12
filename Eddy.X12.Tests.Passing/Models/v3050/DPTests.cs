using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class DPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DP*3*U*5*U*U*Vj*h*G*S*9*2*L*t*6*k";

		var expected = new DP_AutoClaimDetailParts()
		{
			ActionCode = "3",
			ProductServiceID = "U",
			Amount = "5",
			Amount2 = "U",
			YesNoConditionOrResponseCode = "U",
			StatusCode = "Vj",
			YesNoConditionOrResponseCode2 = "h",
			YesNoConditionOrResponseCode3 = "G",
			YesNoConditionOrResponseCode4 = "S",
			YesNoConditionOrResponseCode5 = "9",
			Quantity = 2,
			ProductServiceID2 = "L",
			FreeFormDescription = "t",
			Percent = 6,
			AllowanceOrChargeTotalAmount = "k",
		};

		var actual = Map.MapObject<DP_AutoClaimDetailParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		//Required fields
		//Test Parameters
		subject.ActionCode = actionCode;
		//If one, at least one
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ProductServiceID) || !string.IsNullOrEmpty(subject.ProductServiceID2) || !string.IsNullOrEmpty(subject.FreeFormDescription))
		{
			subject.Quantity = 2;
			subject.ProductServiceID = "U";
			subject.ProductServiceID2 = "L";
			subject.FreeFormDescription = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", "", "", true)]
	[InlineData(2, "U", "L", "t", true)]
	[InlineData(2, "", "", "", false)]
	[InlineData(0, "U", "L", "t", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Quantity(decimal quantity, string productServiceID, string productServiceID2, string freeFormDescription, bool isValidExpected)
	{
		var subject = new DP_AutoClaimDetailParts();
		//Required fields
		subject.ActionCode = "3";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.ProductServiceID = productServiceID;
		subject.ProductServiceID2 = productServiceID2;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
