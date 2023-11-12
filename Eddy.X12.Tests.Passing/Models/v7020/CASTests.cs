using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class CASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAS*L*T*9*7*f*6*7*1*8*8*0*8*7*u*2*4*b*7*4";

		var expected = new CAS_ClaimsAdjustment()
		{
			ClaimAdjustmentGroupCode = "L",
			ClaimAdjustmentReasonCode = "T",
			MonetaryAmount = 9,
			Quantity = 7,
			ClaimAdjustmentReasonCode2 = "f",
			MonetaryAmount2 = 6,
			Quantity2 = 7,
			ClaimAdjustmentReasonCode3 = "1",
			MonetaryAmount3 = 8,
			Quantity3 = 8,
			ClaimAdjustmentReasonCode4 = "0",
			MonetaryAmount4 = 8,
			Quantity4 = 7,
			ClaimAdjustmentReasonCode5 = "u",
			MonetaryAmount5 = 2,
			Quantity5 = 4,
			ClaimAdjustmentReasonCode6 = "b",
			MonetaryAmount6 = 7,
			Quantity6 = 4,
		};

		var actual = Map.MapObject<CAS_ClaimsAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredClaimAdjustmentGroupCode(string claimAdjustmentGroupCode, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentGroupCode = claimAdjustmentGroupCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredClaimAdjustmentReasonCode(string claimAdjustmentReasonCode, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode = claimAdjustmentReasonCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("f", 6, 7, true)]
	[InlineData("f", 0, 0, false)]
	[InlineData("", 6, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode2(string claimAdjustmentReasonCode2, decimal monetaryAmount2, decimal quantity2, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode2 = claimAdjustmentReasonCode2;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//A Requires B
		if (monetaryAmount2 > 0)
			subject.ClaimAdjustmentReasonCode2 = "f";
		if (quantity2 > 0)
			subject.ClaimAdjustmentReasonCode2 = "f";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "f", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "f", true)]
	public void Validation_ARequiresBMonetaryAmount2(decimal monetaryAmount2, string claimAdjustmentReasonCode2, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
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
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "f", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "f", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string claimAdjustmentReasonCode2, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.ClaimAdjustmentReasonCode2 = claimAdjustmentReasonCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0)
		{
			subject.MonetaryAmount2 = 6;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("1", 8, 8, true)]
	[InlineData("1", 0, 0, false)]
	[InlineData("", 8, 8, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode3(string claimAdjustmentReasonCode3, decimal monetaryAmount3, decimal quantity3, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode3 = claimAdjustmentReasonCode3;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//A Requires B
		if (monetaryAmount3 > 0)
			subject.ClaimAdjustmentReasonCode3 = "1";
		if (quantity3 > 0)
			subject.ClaimAdjustmentReasonCode3 = "1";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "1", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "1", true)]
	public void Validation_ARequiresBMonetaryAmount3(decimal monetaryAmount3, string claimAdjustmentReasonCode3, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		subject.ClaimAdjustmentReasonCode3 = claimAdjustmentReasonCode3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.Quantity3 > 0)
		{
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "1", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "1", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string claimAdjustmentReasonCode3, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		subject.ClaimAdjustmentReasonCode3 = claimAdjustmentReasonCode3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("0", 8, 7, true)]
	[InlineData("0", 0, 0, false)]
	[InlineData("", 8, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode4(string claimAdjustmentReasonCode4, decimal monetaryAmount4, decimal quantity4, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode4 = claimAdjustmentReasonCode4;
		if (monetaryAmount4 > 0) 
			subject.MonetaryAmount4 = monetaryAmount4;
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		//A Requires B
		if (monetaryAmount4 > 0)
			subject.ClaimAdjustmentReasonCode4 = "0";
		if (quantity4 > 0)
			subject.ClaimAdjustmentReasonCode4 = "0";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "0", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "0", true)]
	public void Validation_ARequiresBMonetaryAmount4(decimal monetaryAmount4, string claimAdjustmentReasonCode4, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (monetaryAmount4 > 0) 
			subject.MonetaryAmount4 = monetaryAmount4;
		subject.ClaimAdjustmentReasonCode4 = claimAdjustmentReasonCode4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.Quantity4 > 0)
		{
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "0", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "0", true)]
	public void Validation_ARequiresBQuantity4(decimal quantity4, string claimAdjustmentReasonCode4, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		subject.ClaimAdjustmentReasonCode4 = claimAdjustmentReasonCode4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0)
		{
			subject.MonetaryAmount4 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("u", 2, 4, true)]
	[InlineData("u", 0, 0, false)]
	[InlineData("", 2, 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode5(string claimAdjustmentReasonCode5, decimal monetaryAmount5, decimal quantity5, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode5 = claimAdjustmentReasonCode5;
		if (monetaryAmount5 > 0) 
			subject.MonetaryAmount5 = monetaryAmount5;
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		//A Requires B
		if (monetaryAmount5 > 0)
			subject.ClaimAdjustmentReasonCode5 = "u";
		if (quantity5 > 0)
			subject.ClaimAdjustmentReasonCode5 = "u";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "u", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "u", true)]
	public void Validation_ARequiresBMonetaryAmount5(decimal monetaryAmount5, string claimAdjustmentReasonCode5, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (monetaryAmount5 > 0) 
			subject.MonetaryAmount5 = monetaryAmount5;
		subject.ClaimAdjustmentReasonCode5 = claimAdjustmentReasonCode5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.Quantity5 > 0)
		{
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "u", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "u", true)]
	public void Validation_ARequiresBQuantity5(decimal quantity5, string claimAdjustmentReasonCode5, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		subject.ClaimAdjustmentReasonCode5 = claimAdjustmentReasonCode5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0)
		{
			subject.MonetaryAmount5 = 2;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "b";
			subject.MonetaryAmount6 = 7;
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("b", 7, 4, true)]
	[InlineData("b", 0, 0, false)]
	[InlineData("", 7, 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode6(string claimAdjustmentReasonCode6, decimal monetaryAmount6, decimal quantity6, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode6 = claimAdjustmentReasonCode6;
		if (monetaryAmount6 > 0) 
			subject.MonetaryAmount6 = monetaryAmount6;
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		//A Requires B
		if (monetaryAmount6 > 0)
			subject.ClaimAdjustmentReasonCode6 = "b";
		if (quantity6 > 0)
			subject.ClaimAdjustmentReasonCode6 = "b";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "b", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "b", true)]
	public void Validation_ARequiresBMonetaryAmount6(decimal monetaryAmount6, string claimAdjustmentReasonCode6, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (monetaryAmount6 > 0) 
			subject.MonetaryAmount6 = monetaryAmount6;
		subject.ClaimAdjustmentReasonCode6 = claimAdjustmentReasonCode6;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.Quantity6 > 0)
		{
			subject.Quantity6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "b", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "b", true)]
	public void Validation_ARequiresBQuantity6(decimal quantity6, string claimAdjustmentReasonCode6, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "L";
		subject.ClaimAdjustmentReasonCode = "T";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		subject.ClaimAdjustmentReasonCode6 = claimAdjustmentReasonCode6;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "f";
			subject.MonetaryAmount2 = 6;
			subject.Quantity2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "1";
			subject.MonetaryAmount3 = 8;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "0";
			subject.MonetaryAmount4 = 8;
			subject.Quantity4 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "u";
			subject.MonetaryAmount5 = 2;
			subject.Quantity5 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0)
		{
			subject.MonetaryAmount6 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
