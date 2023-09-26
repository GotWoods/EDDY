using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class BSWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSW*o5mRQSeH*Rg*Hw*T*q*Jk*0";

		var expected = new BSW_BeginningSegmentForCarrierServicesSettlement()
		{
			Date = "o5mRQSeH",
			StandardCarrierAlphaCode = "Rg",
			StandardCarrierAlphaCode2 = "Hw",
			NetAmountDue = "T",
			BillingCode = "q",
			CorrectionIndicatorCode = "Jk",
			StatementNumber = "0",
		};

		var actual = Map.MapObject<BSW_BeginningSegmentForCarrierServicesSettlement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o5mRQSeH", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.StandardCarrierAlphaCode = "Rg";
		subject.StandardCarrierAlphaCode2 = "Hw";
		subject.NetAmountDue = "T";
		subject.BillingCode = "q";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rg", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.Date = "o5mRQSeH";
		subject.StandardCarrierAlphaCode2 = "Hw";
		subject.NetAmountDue = "T";
		subject.BillingCode = "q";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hw", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.Date = "o5mRQSeH";
		subject.StandardCarrierAlphaCode = "Rg";
		subject.NetAmountDue = "T";
		subject.BillingCode = "q";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.Date = "o5mRQSeH";
		subject.StandardCarrierAlphaCode = "Rg";
		subject.StandardCarrierAlphaCode2 = "Hw";
		subject.BillingCode = "q";
		//Test Parameters
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredBillingCode(string billingCode, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.Date = "o5mRQSeH";
		subject.StandardCarrierAlphaCode = "Rg";
		subject.StandardCarrierAlphaCode2 = "Hw";
		subject.NetAmountDue = "T";
		//Test Parameters
		subject.BillingCode = billingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
