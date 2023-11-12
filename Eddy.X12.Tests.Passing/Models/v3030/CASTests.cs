using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAS*x*u*4*3*P*5*7*K*2*3*U*8*3*8*4*8*p*4*4";

		var expected = new CAS_ClaimsAdjustment()
		{
			ClaimAdjustmentGroupCode = "x",
			ClaimAdjustmentReasonCode = "u",
			MonetaryAmount = 4,
			Quantity = 3,
			ClaimAdjustmentReasonCode2 = "P",
			MonetaryAmount2 = 5,
			Quantity2 = 7,
			ClaimAdjustmentReasonCode3 = "K",
			MonetaryAmount3 = 2,
			Quantity3 = 3,
			ClaimAdjustmentReasonCode4 = "U",
			MonetaryAmount4 = 8,
			Quantity4 = 3,
			ClaimAdjustmentReasonCode5 = "8",
			MonetaryAmount5 = 4,
			Quantity5 = 8,
			ClaimAdjustmentReasonCode6 = "p",
			MonetaryAmount6 = 4,
			Quantity6 = 4,
		};

		var actual = Map.MapObject<CAS_ClaimsAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredClaimAdjustmentGroupCode(string claimAdjustmentGroupCode, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.ClaimAdjustmentGroupCode = claimAdjustmentGroupCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredClaimAdjustmentReasonCode(string claimAdjustmentReasonCode, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode = claimAdjustmentReasonCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("P", 5, 7, true)]
	[InlineData("P", 0, 0, false)]
	[InlineData("", 5, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode2(string claimAdjustmentReasonCode2, decimal monetaryAmount2, decimal quantity2, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode2 = claimAdjustmentReasonCode2;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//A Requires B
		if (monetaryAmount2 > 0)
			subject.ClaimAdjustmentReasonCode2 = "P";
		if (quantity2 > 0)
			subject.ClaimAdjustmentReasonCode2 = "P";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "P", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "P", true)]
	public void Validation_ARequiresBMonetaryAmount2(decimal monetaryAmount2, string claimAdjustmentReasonCode2, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		subject.ClaimAdjustmentReasonCode2 = claimAdjustmentReasonCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.Quantity2 > 0)
		{
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "P", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "P", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string claimAdjustmentReasonCode2, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.ClaimAdjustmentReasonCode2 = claimAdjustmentReasonCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0)
		{
			subject.MonetaryAmount2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("K", 2, 3, true)]
	[InlineData("K", 0, 0, false)]
	[InlineData("", 2, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode3(string claimAdjustmentReasonCode3, decimal monetaryAmount3, decimal quantity3, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode3 = claimAdjustmentReasonCode3;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//A Requires B
		if (monetaryAmount3 > 0)
			subject.ClaimAdjustmentReasonCode3 = "K";
		if (quantity3 > 0)
			subject.ClaimAdjustmentReasonCode3 = "K";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "K", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "K", true)]
	public void Validation_ARequiresBMonetaryAmount3(decimal monetaryAmount3, string claimAdjustmentReasonCode3, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		subject.ClaimAdjustmentReasonCode3 = claimAdjustmentReasonCode3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.Quantity3 > 0)
		{
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "K", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "K", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string claimAdjustmentReasonCode3, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		subject.ClaimAdjustmentReasonCode3 = claimAdjustmentReasonCode3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount3 = 2;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("U", 8, 3, true)]
	[InlineData("U", 0, 0, false)]
	[InlineData("", 8, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode4(string claimAdjustmentReasonCode4, decimal monetaryAmount4, decimal quantity4, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode4 = claimAdjustmentReasonCode4;
		if (monetaryAmount4 > 0) 
			subject.MonetaryAmount4 = monetaryAmount4;
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		//A Requires B
		if (monetaryAmount4 > 0)
			subject.ClaimAdjustmentReasonCode4 = "U";
		if (quantity4 > 0)
			subject.ClaimAdjustmentReasonCode4 = "U";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "U", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "U", true)]
	public void Validation_ARequiresBMonetaryAmount4(decimal monetaryAmount4, string claimAdjustmentReasonCode4, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (monetaryAmount4 > 0) 
			subject.MonetaryAmount4 = monetaryAmount4;
		subject.ClaimAdjustmentReasonCode4 = claimAdjustmentReasonCode4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.Quantity4 > 0)
		{
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "U", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "U", true)]
	public void Validation_ARequiresBQuantity4(decimal quantity4, string claimAdjustmentReasonCode4, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		subject.ClaimAdjustmentReasonCode4 = claimAdjustmentReasonCode4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0)
		{
			subject.MonetaryAmount4 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("8", 4, 8, true)]
	[InlineData("8", 0, 0, false)]
	[InlineData("", 4, 8, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode5(string claimAdjustmentReasonCode5, decimal monetaryAmount5, decimal quantity5, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode5 = claimAdjustmentReasonCode5;
		if (monetaryAmount5 > 0) 
			subject.MonetaryAmount5 = monetaryAmount5;
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		//A Requires B
		if (monetaryAmount5 > 0)
			subject.ClaimAdjustmentReasonCode5 = "8";
		if (quantity5 > 0)
			subject.ClaimAdjustmentReasonCode5 = "8";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "8", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "8", true)]
	public void Validation_ARequiresBMonetaryAmount5(decimal monetaryAmount5, string claimAdjustmentReasonCode5, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (monetaryAmount5 > 0) 
			subject.MonetaryAmount5 = monetaryAmount5;
		subject.ClaimAdjustmentReasonCode5 = claimAdjustmentReasonCode5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.Quantity5 > 0)
		{
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "8", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "8", true)]
	public void Validation_ARequiresBQuantity5(decimal quantity5, string claimAdjustmentReasonCode5, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		subject.ClaimAdjustmentReasonCode5 = claimAdjustmentReasonCode5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0)
		{
			subject.MonetaryAmount5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "p";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("p", 4, 4, true)]
	[InlineData("p", 0, 0, false)]
	[InlineData("", 4, 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode6(string claimAdjustmentReasonCode6, decimal monetaryAmount6, decimal quantity6, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode6 = claimAdjustmentReasonCode6;
		if (monetaryAmount6 > 0) 
			subject.MonetaryAmount6 = monetaryAmount6;
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		//A Requires B
		if (monetaryAmount6 > 0)
			subject.ClaimAdjustmentReasonCode6 = "p";
		if (quantity6 > 0)
			subject.ClaimAdjustmentReasonCode6 = "p";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "p", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "p", true)]
	public void Validation_ARequiresBMonetaryAmount6(decimal monetaryAmount6, string claimAdjustmentReasonCode6, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (monetaryAmount6 > 0) 
			subject.MonetaryAmount6 = monetaryAmount6;
		subject.ClaimAdjustmentReasonCode6 = claimAdjustmentReasonCode6;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.Quantity6 > 0)
		{
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "p", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "p", true)]
	public void Validation_ARequiresBQuantity6(decimal quantity6, string claimAdjustmentReasonCode6, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "x";
		subject.ClaimAdjustmentReasonCode = "u";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		subject.ClaimAdjustmentReasonCode6 = claimAdjustmentReasonCode6;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "P";
			subject.MonetaryAmount2 = 5;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "K";
			subject.MonetaryAmount3 = 2;
			subject.Quantity3 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "U";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "8";
			subject.MonetaryAmount5 = 4;
			subject.Quantity5 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0)
		{
			subject.MonetaryAmount6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
