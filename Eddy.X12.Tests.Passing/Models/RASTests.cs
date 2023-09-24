using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class RASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAS*1*1**7";

		var expected = new RAS_ReasonAdjustment()
		{
			MonetaryAmount = 1,
			ClaimAdjustmentGroupCode = "1",
			AdjustmentReason = null,
			Quantity = 7,
		};

		var actual = Map.MapObject<RAS_ReasonAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new RAS_ReasonAdjustment();
		subject.ClaimAdjustmentGroupCode = "1";
		subject.AdjustmentReason = new C058_AdjustmentReason();
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredClaimAdjustmentGroupCode(string claimAdjustmentGroupCode, bool isValidExpected)
	{
		var subject = new RAS_ReasonAdjustment();
		subject.MonetaryAmount = 1;
		subject.AdjustmentReason = new C058_AdjustmentReason();
		subject.ClaimAdjustmentGroupCode = claimAdjustmentGroupCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredAdjustmentReason(string adjustmentReason, bool isValidExpected)
	{
		var subject = new RAS_ReasonAdjustment();
		subject.MonetaryAmount = 1;
		subject.ClaimAdjustmentGroupCode = "1";
		
        if (adjustmentReason != "")
            subject.AdjustmentReason = new C058_AdjustmentReason() { ClaimAdjustmentReasonCode = adjustmentReason };

        
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
