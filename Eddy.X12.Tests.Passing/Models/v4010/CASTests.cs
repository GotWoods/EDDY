using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAS*e*H*9*5*L*7*3*b*4*8*a*5*5*V*3*5*9*4*5";

		var expected = new CAS_ClaimsAdjustment()
		{
			ClaimAdjustmentGroupCode = "e",
			ClaimAdjustmentReasonCode = "H",
			MonetaryAmount = 9,
			Quantity = 5,
			ClaimAdjustmentReasonCode2 = "L",
			MonetaryAmount2 = 7,
			Quantity2 = 3,
			ClaimAdjustmentReasonCode3 = "b",
			MonetaryAmount3 = 4,
			Quantity3 = 8,
			ClaimAdjustmentReasonCode4 = "a",
			MonetaryAmount4 = 5,
			Quantity4 = 5,
			ClaimAdjustmentReasonCode5 = "V",
			MonetaryAmount5 = 3,
			Quantity5 = 5,
			ClaimAdjustmentReasonCode6 = "9",
			MonetaryAmount6 = 4,
			Quantity6 = 5,
		};

		var actual = Map.MapObject<CAS_ClaimsAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredClaimAdjustmentGroupCode(string claimAdjustmentGroupCode, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentGroupCode = claimAdjustmentGroupCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredClaimAdjustmentReasonCode(string claimAdjustmentReasonCode, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode = claimAdjustmentReasonCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
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
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("L", 7, 3, true)]
	[InlineData("L", 0, 0, false)]
	[InlineData("", 7, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode2(string claimAdjustmentReasonCode2, decimal monetaryAmount2, decimal quantity2, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode2 = claimAdjustmentReasonCode2;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//A Requires B
		if (monetaryAmount2 > 0)
			subject.ClaimAdjustmentReasonCode2 = "L";
		if (quantity2 > 0)
			subject.ClaimAdjustmentReasonCode2 = "L";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "L", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "L", true)]
	public void Validation_ARequiresBMonetaryAmount2(decimal monetaryAmount2, string claimAdjustmentReasonCode2, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		subject.ClaimAdjustmentReasonCode2 = claimAdjustmentReasonCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.Quantity2 > 0)
		{
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "L", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "L", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string claimAdjustmentReasonCode2, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.ClaimAdjustmentReasonCode2 = claimAdjustmentReasonCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0)
		{
			subject.MonetaryAmount2 = 7;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("b", 4, 8, true)]
	[InlineData("b", 0, 0, false)]
	[InlineData("", 4, 8, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode3(string claimAdjustmentReasonCode3, decimal monetaryAmount3, decimal quantity3, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode3 = claimAdjustmentReasonCode3;
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//A Requires B
		if (monetaryAmount3 > 0)
			subject.ClaimAdjustmentReasonCode3 = "b";
		if (quantity3 > 0)
			subject.ClaimAdjustmentReasonCode3 = "b";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "b", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "b", true)]
	public void Validation_ARequiresBMonetaryAmount3(decimal monetaryAmount3, string claimAdjustmentReasonCode3, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (monetaryAmount3 > 0) 
			subject.MonetaryAmount3 = monetaryAmount3;
		subject.ClaimAdjustmentReasonCode3 = claimAdjustmentReasonCode3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.Quantity3 > 0)
		{
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "b", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "b", true)]
	public void Validation_ARequiresBQuantity3(decimal quantity3, string claimAdjustmentReasonCode3, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		subject.ClaimAdjustmentReasonCode3 = claimAdjustmentReasonCode3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0)
		{
			subject.MonetaryAmount3 = 4;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("a", 5, 5, true)]
	[InlineData("a", 0, 0, false)]
	[InlineData("", 5, 5, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode4(string claimAdjustmentReasonCode4, decimal monetaryAmount4, decimal quantity4, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode4 = claimAdjustmentReasonCode4;
		if (monetaryAmount4 > 0) 
			subject.MonetaryAmount4 = monetaryAmount4;
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		//A Requires B
		if (monetaryAmount4 > 0)
			subject.ClaimAdjustmentReasonCode4 = "a";
		if (quantity4 > 0)
			subject.ClaimAdjustmentReasonCode4 = "a";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "a", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "a", true)]
	public void Validation_ARequiresBMonetaryAmount4(decimal monetaryAmount4, string claimAdjustmentReasonCode4, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (monetaryAmount4 > 0) 
			subject.MonetaryAmount4 = monetaryAmount4;
		subject.ClaimAdjustmentReasonCode4 = claimAdjustmentReasonCode4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.Quantity4 > 0)
		{
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "a", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "a", true)]
	public void Validation_ARequiresBQuantity4(decimal quantity4, string claimAdjustmentReasonCode4, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (quantity4 > 0) 
			subject.Quantity4 = quantity4;
		subject.ClaimAdjustmentReasonCode4 = claimAdjustmentReasonCode4;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0)
		{
			subject.MonetaryAmount4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("V", 3, 5, true)]
	[InlineData("V", 0, 0, false)]
	[InlineData("", 3, 5, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode5(string claimAdjustmentReasonCode5, decimal monetaryAmount5, decimal quantity5, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode5 = claimAdjustmentReasonCode5;
		if (monetaryAmount5 > 0) 
			subject.MonetaryAmount5 = monetaryAmount5;
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		//A Requires B
		if (monetaryAmount5 > 0)
			subject.ClaimAdjustmentReasonCode5 = "V";
		if (quantity5 > 0)
			subject.ClaimAdjustmentReasonCode5 = "V";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "V", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "V", true)]
	public void Validation_ARequiresBMonetaryAmount5(decimal monetaryAmount5, string claimAdjustmentReasonCode5, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (monetaryAmount5 > 0) 
			subject.MonetaryAmount5 = monetaryAmount5;
		subject.ClaimAdjustmentReasonCode5 = claimAdjustmentReasonCode5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.Quantity5 > 0)
		{
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "V", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "V", true)]
	public void Validation_ARequiresBQuantity5(decimal quantity5, string claimAdjustmentReasonCode5, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (quantity5 > 0) 
			subject.Quantity5 = quantity5;
		subject.ClaimAdjustmentReasonCode5 = claimAdjustmentReasonCode5;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0)
		{
			subject.MonetaryAmount5 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0 || subject.Quantity6 > 0)
		{
			subject.ClaimAdjustmentReasonCode6 = "9";
			subject.MonetaryAmount6 = 4;
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("9", 4, 5, true)]
	[InlineData("9", 0, 0, false)]
	[InlineData("", 4, 5, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ClaimAdjustmentReasonCode6(string claimAdjustmentReasonCode6, decimal monetaryAmount6, decimal quantity6, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ClaimAdjustmentReasonCode6 = claimAdjustmentReasonCode6;
		if (monetaryAmount6 > 0) 
			subject.MonetaryAmount6 = monetaryAmount6;
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		//A Requires B
		if (monetaryAmount6 > 0)
			subject.ClaimAdjustmentReasonCode6 = "9";
		if (quantity6 > 0)
			subject.ClaimAdjustmentReasonCode6 = "9";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "9", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "9", true)]
	public void Validation_ARequiresBMonetaryAmount6(decimal monetaryAmount6, string claimAdjustmentReasonCode6, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (monetaryAmount6 > 0) 
			subject.MonetaryAmount6 = monetaryAmount6;
		subject.ClaimAdjustmentReasonCode6 = claimAdjustmentReasonCode6;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.Quantity6 > 0)
		{
			subject.Quantity6 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "9", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "9", true)]
	public void Validation_ARequiresBQuantity6(decimal quantity6, string claimAdjustmentReasonCode6, bool isValidExpected)
	{
		var subject = new CAS_ClaimsAdjustment();
		//Required fields
		subject.ClaimAdjustmentGroupCode = "e";
		subject.ClaimAdjustmentReasonCode = "H";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (quantity6 > 0) 
			subject.Quantity6 = quantity6;
		subject.ClaimAdjustmentReasonCode6 = claimAdjustmentReasonCode6;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode2) || subject.MonetaryAmount2 > 0 || subject.Quantity2 > 0)
		{
			subject.ClaimAdjustmentReasonCode2 = "L";
			subject.MonetaryAmount2 = 7;
			subject.Quantity2 = 3;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode3) || subject.MonetaryAmount3 > 0 || subject.Quantity3 > 0)
		{
			subject.ClaimAdjustmentReasonCode3 = "b";
			subject.MonetaryAmount3 = 4;
			subject.Quantity3 = 8;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode4) || subject.MonetaryAmount4 > 0 || subject.Quantity4 > 0)
		{
			subject.ClaimAdjustmentReasonCode4 = "a";
			subject.MonetaryAmount4 = 5;
			subject.Quantity4 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || !string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode5) || subject.MonetaryAmount5 > 0 || subject.Quantity5 > 0)
		{
			subject.ClaimAdjustmentReasonCode5 = "V";
			subject.MonetaryAmount5 = 3;
			subject.Quantity5 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ClaimAdjustmentReasonCode6) || subject.MonetaryAmount6 > 0)
		{
			subject.MonetaryAmount6 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
