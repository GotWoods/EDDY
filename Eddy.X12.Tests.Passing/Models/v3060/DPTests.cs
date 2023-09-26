using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class DPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DP*E*X*E*S*G*Ly*B*z*q*p*8*t*E*1*r";

		var expected = new DP_AutoClaimDetailParts()
		{
			ActionCode = "E",
			ProductServiceID = "X",
			Amount = "E",
			Amount2 = "S",
			YesNoConditionOrResponseCode = "G",
			ConditionIndicator = "Ly",
			YesNoConditionOrResponseCode2 = "B",
			YesNoConditionOrResponseCode3 = "z",
			YesNoConditionOrResponseCode4 = "q",
			YesNoConditionOrResponseCode5 = "p",
			Quantity = 8,
			ProductServiceID2 = "t",
			FreeFormDescription = "E",
			Percent = 1,
			AllowanceOrChargeTotalAmount = "r",
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
			subject.Quantity = 8;
			subject.ProductServiceID = "X";
			subject.ProductServiceID2 = "t";
			subject.FreeFormDescription = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", "", "", true)]
	[InlineData(8, "X", "t", "E", true)]
	[InlineData(8, "", "", "", false)]
	[InlineData(0, "X", "t", "E", true)]
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
