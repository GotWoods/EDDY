using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAS*V*a*8*1";

		var expected = new CAS_ClaimsAdjustment()
		{
			ClaimAdjustmentGroupCode = "V",
			ClaimAdjustmentReasonCode = "a",
			MonetaryAmount = 8,
			Quantity = 1,
		};

		var actual = Map.MapObject<CAS_ClaimsAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredClaimAdjustmentGroupCode(string claimAdjustmentGroupCode, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentReasonCode = "a";
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.ClaimAdjustmentGroupCode = claimAdjustmentGroupCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredClaimAdjustmentReasonCode(string claimAdjustmentReasonCode, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "V";
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode = claimAdjustmentReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "V";
		subject.ClaimAdjustmentReasonCode = "a";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
