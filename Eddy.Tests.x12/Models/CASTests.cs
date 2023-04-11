namespace Eddy.Tests.x12.Models;
//TODO: enable this test
// public class CASTests
// {
// 	[Fact]
// 	public void Parse_ShouldReturnCorrectObject()
// 	{
// 		string x12Line = "CAS*T*7*6*5*w*8*2*x*2*9*b*5*4*w*5*1*T*8*5";
//
// 		var expected = new CAS_ClaimsAdjustment()
// 		{
// 			ClaimAdjustmentGroupCode = "T",
// 			ClaimAdjustmentReasonCode = "7",
// 			MonetaryAmount = 6,
// 			Quantity = 5,
// 			ClaimAdjustmentReasonCode2 = "w",
// 			MonetaryAmount2 = 8,
// 			Quantity2 = 2,
// 			ClaimAdjustmentReasonCode3 = "x",
// 			MonetaryAmount3 = 2,
// 			Quantity3 = 9,
// 			ClaimAdjustmentReasonCode4 = "b",
// 			MonetaryAmount4 = 5,
// 			Quantity4 = 4,
// 			ClaimAdjustmentReasonCode5 = "w",
// 			MonetaryAmount5 = 5,
// 			Quantity5 = 1,
// 			ClaimAdjustmentReasonCode6 = "T",
// 			MonetaryAmount6 = 8,
// 			Quantity6 = 5,
// 		};
//
// 		var actual = Map.MapObject<CAS_ClaimsAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
// 		try
// 		{
// 			Assert.Equivalent(expected, actual);
// 		}
// 		catch
// 		{
// 			Assert.Fail(actual.ValidationResult.ToString());
// 		}
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("T", true)]
// 	public void Validation_RequiredClaimAdjustmentGroupCode(string claimAdjustmentGroupCode, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		subject.ClaimAdjustmentGroupCode = claimAdjustmentGroupCode;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("7", true)]
// 	public void Validation_RequiredClaimAdjustmentReasonCode(string claimAdjustmentReasonCode, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.MonetaryAmount = 6;
// 		subject.ClaimAdjustmentReasonCode = claimAdjustmentReasonCode;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData(0, false)]
// 	[InlineData(6, true)]
// 	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		if (monetaryAmount > 0)
// 		subject.MonetaryAmount = monetaryAmount;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("",0, true)]
// 	[InlineData("w", 8, false)]
// 	[InlineData("",8, true)]
// 	[InlineData("w", 0, true)]
// 	public void Validation_NEWClaimAdjustmentReasonCode2(string claimAdjustmentReasonCode2, decimal monetaryAmount2, decimal quantity2, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		subject.ClaimAdjustmentReasonCode2 = claimAdjustmentReasonCode2;
// 		if (monetaryAmount2 > 0)
// 		subject.MonetaryAmount2 = monetaryAmount2;
// 		if (quantity2 > 0)
// 		subject.Quantity2 = quantity2;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
// 	}
//
// 	[Theory]
// 	[InlineData(0, "", true)]
// 	[InlineData(0, "w", true)]
// 	[InlineData(8, "", false)]
// 	public void Validation_ARequiresBMonetaryAmount2(decimal monetaryAmount2, string claimAdjustmentReasonCode2, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		if (monetaryAmount2 > 0)
// 		subject.MonetaryAmount2 = monetaryAmount2;
// 		subject.ClaimAdjustmentReasonCode2 = claimAdjustmentReasonCode2;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData(0, "", true)]
// 	[InlineData(0, "w", true)]
// 	[InlineData(2, "", false)]
// 	public void Validation_ARequiresBQuantity2(decimal quantity2, string claimAdjustmentReasonCode2, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		if (quantity2 > 0)
// 		subject.Quantity2 = quantity2;
// 		subject.ClaimAdjustmentReasonCode2 = claimAdjustmentReasonCode2;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("",0, true)]
// 	[InlineData("x", 2, false)]
// 	[InlineData("",2, true)]
// 	[InlineData("x", 0, true)]
// 	public void Validation_NEWClaimAdjustmentReasonCode3(string claimAdjustmentReasonCode3, decimal monetaryAmount3, decimal quantity3, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		subject.ClaimAdjustmentReasonCode3 = claimAdjustmentReasonCode3;
// 		if (monetaryAmount3 > 0)
// 		subject.MonetaryAmount3 = monetaryAmount3;
// 		if (quantity3 > 0)
// 		subject.Quantity3 = quantity3;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
// 	}
//
// 	[Theory]
// 	[InlineData(0, "", true)]
// 	[InlineData(0, "x", true)]
// 	[InlineData(2, "", false)]
// 	public void Validation_ARequiresBMonetaryAmount3(decimal monetaryAmount3, string claimAdjustmentReasonCode3, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		if (monetaryAmount3 > 0)
// 		subject.MonetaryAmount3 = monetaryAmount3;
// 		subject.ClaimAdjustmentReasonCode3 = claimAdjustmentReasonCode3;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData(0, "", true)]
// 	[InlineData(0, "x", true)]
// 	[InlineData(9, "", false)]
// 	public void Validation_ARequiresBQuantity3(decimal quantity3, string claimAdjustmentReasonCode3, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		if (quantity3 > 0)
// 		subject.Quantity3 = quantity3;
// 		subject.ClaimAdjustmentReasonCode3 = claimAdjustmentReasonCode3;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("",0, true)]
// 	[InlineData("b", 5, false)]
// 	[InlineData("",5, true)]
// 	[InlineData("b", 0, true)]
// 	public void Validation_NEWClaimAdjustmentReasonCode4(string claimAdjustmentReasonCode4, decimal monetaryAmount4, decimal quantity4, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		subject.ClaimAdjustmentReasonCode4 = claimAdjustmentReasonCode4;
// 		if (monetaryAmount4 > 0)
// 		subject.MonetaryAmount4 = monetaryAmount4;
// 		if (quantity4 > 0)
// 		subject.Quantity4 = quantity4;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
// 	}
//
// 	[Theory]
// 	[InlineData(0, "", true)]
// 	[InlineData(0, "b", true)]
// 	[InlineData(5, "", false)]
// 	public void Validation_ARequiresBMonetaryAmount4(decimal monetaryAmount4, string claimAdjustmentReasonCode4, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		if (monetaryAmount4 > 0)
// 		subject.MonetaryAmount4 = monetaryAmount4;
// 		subject.ClaimAdjustmentReasonCode4 = claimAdjustmentReasonCode4;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData(0, "", true)]
// 	[InlineData(0, "b", true)]
// 	[InlineData(4, "", false)]
// 	public void Validation_ARequiresBQuantity4(decimal quantity4, string claimAdjustmentReasonCode4, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		if (quantity4 > 0)
// 		subject.Quantity4 = quantity4;
// 		subject.ClaimAdjustmentReasonCode4 = claimAdjustmentReasonCode4;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("",0, true)]
// 	[InlineData("w", 5, false)]
// 	[InlineData("",5, true)]
// 	[InlineData("w", 0, true)]
// 	public void Validation_NEWClaimAdjustmentReasonCode5(string claimAdjustmentReasonCode5, decimal monetaryAmount5, decimal quantity5, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		subject.ClaimAdjustmentReasonCode5 = claimAdjustmentReasonCode5;
// 		if (monetaryAmount5 > 0)
// 		subject.MonetaryAmount5 = monetaryAmount5;
// 		if (quantity5 > 0)
// 		subject.Quantity5 = quantity5;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
// 	}
//
// 	[Theory]
// 	[InlineData(0, "", true)]
// 	[InlineData(0, "w", true)]
// 	[InlineData(5, "", false)]
// 	public void Validation_ARequiresBMonetaryAmount5(decimal monetaryAmount5, string claimAdjustmentReasonCode5, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		if (monetaryAmount5 > 0)
// 		subject.MonetaryAmount5 = monetaryAmount5;
// 		subject.ClaimAdjustmentReasonCode5 = claimAdjustmentReasonCode5;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData(0, "", true)]
// 	[InlineData(0, "w", true)]
// 	[InlineData(1, "", false)]
// 	public void Validation_ARequiresBQuantity5(decimal quantity5, string claimAdjustmentReasonCode5, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		if (quantity5 > 0)
// 		subject.Quantity5 = quantity5;
// 		subject.ClaimAdjustmentReasonCode5 = claimAdjustmentReasonCode5;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("",0, true)]
// 	[InlineData("T", 8, false)]
// 	[InlineData("",8, true)]
// 	[InlineData("T", 0, true)]
// 	public void Validation_NEWClaimAdjustmentReasonCode6(string claimAdjustmentReasonCode6, decimal monetaryAmount6, decimal quantity6, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		subject.ClaimAdjustmentReasonCode6 = claimAdjustmentReasonCode6;
// 		if (monetaryAmount6 > 0)
// 		subject.MonetaryAmount6 = monetaryAmount6;
// 		if (quantity6 > 0)
// 		subject.Quantity6 = quantity6;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
// 	}
//
// 	[Theory]
// 	[InlineData(0, "", true)]
// 	[InlineData(0, "T", true)]
// 	[InlineData(8, "", false)]
// 	public void Validation_ARequiresBMonetaryAmount6(decimal monetaryAmount6, string claimAdjustmentReasonCode6, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		if (monetaryAmount6 > 0)
// 		subject.MonetaryAmount6 = monetaryAmount6;
// 		subject.ClaimAdjustmentReasonCode6 = claimAdjustmentReasonCode6;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData(0, "", true)]
// 	[InlineData(0, "T", true)]
// 	[InlineData(5, "", false)]
// 	public void Validation_ARequiresBQuantity6(decimal quantity6, string claimAdjustmentReasonCode6, bool isValidExpected)
// 	{
// 		var subject = new CAS_ClaimsAdjustment();
// 		subject.ClaimAdjustmentGroupCode = "T";
// 		subject.ClaimAdjustmentReasonCode = "7";
// 		subject.MonetaryAmount = 6;
// 		if (quantity6 > 0)
// 		subject.Quantity6 = quantity6;
// 		subject.ClaimAdjustmentReasonCode6 = claimAdjustmentReasonCode6;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// }
