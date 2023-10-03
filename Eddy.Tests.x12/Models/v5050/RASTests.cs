using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5050.Composites;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class RASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAS*4*k**7";

		var expected = new RAS_ReasonAdjustment()
		{
			MonetaryAmount = 4,
			ClaimAdjustmentGroupCode = "k",
			AdjustmentReason = null,
			Quantity = 7,
		};

		var actual = Map.MapObject<RAS_ReasonAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new RAS_ReasonAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "k";
		subject.AdjustmentReason = new C058_AdjustmentReason();
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredClaimAdjustmentGroupCode(string claimAdjustmentGroupCode, bool isValidExpected)
	{
		var subject = new RAS_ReasonAdjustment();
		//Required fields
		subject.MonetaryAmount = 4;
		subject.AdjustmentReason = new C058_AdjustmentReason();
		//Test Parameters
		subject.ClaimAdjustmentGroupCode = claimAdjustmentGroupCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAdjustmentReason(string adjustmentReason, bool isValidExpected)
	{
		var subject = new RAS_ReasonAdjustment();
		//Required fields
		subject.MonetaryAmount = 4;
		subject.ClaimAdjustmentGroupCode = "k";
		//Test Parameters
		if (adjustmentReason != "") 
			subject.AdjustmentReason = new C058_AdjustmentReason();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
