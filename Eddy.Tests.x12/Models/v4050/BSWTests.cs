using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class BSWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSW*aA7c6Myj*AW*Gm*P*e*fG*Y";

		var expected = new BSW_BeginningSegmentForCarrierServicesSettlement()
		{
			Date = "aA7c6Myj",
			StandardCarrierAlphaCode = "AW",
			StandardCarrierAlphaCode2 = "Gm",
			NetAmountDue = "P",
			BillingCode = "e",
			CorrectionIndicator = "fG",
			StatementNumber = "Y",
		};

		var actual = Map.MapObject<BSW_BeginningSegmentForCarrierServicesSettlement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aA7c6Myj", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.StandardCarrierAlphaCode = "AW";
		subject.StandardCarrierAlphaCode2 = "Gm";
		subject.NetAmountDue = "P";
		subject.BillingCode = "e";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AW", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.Date = "aA7c6Myj";
		subject.StandardCarrierAlphaCode2 = "Gm";
		subject.NetAmountDue = "P";
		subject.BillingCode = "e";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gm", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.Date = "aA7c6Myj";
		subject.StandardCarrierAlphaCode = "AW";
		subject.NetAmountDue = "P";
		subject.BillingCode = "e";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.Date = "aA7c6Myj";
		subject.StandardCarrierAlphaCode = "AW";
		subject.StandardCarrierAlphaCode2 = "Gm";
		subject.BillingCode = "e";
		//Test Parameters
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredBillingCode(string billingCode, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.Date = "aA7c6Myj";
		subject.StandardCarrierAlphaCode = "AW";
		subject.StandardCarrierAlphaCode2 = "Gm";
		subject.NetAmountDue = "P";
		//Test Parameters
		subject.BillingCode = billingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
