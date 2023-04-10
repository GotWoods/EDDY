using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BSWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSW*IBoICgvm*h3*WV*6*o*Id*i";

		var expected = new BSW_BeginningSegmentForCarriersServicesSettlement()
		{
			Date = "IBoICgvm",
			StandardCarrierAlphaCode = "h3",
			StandardCarrierAlphaCode2 = "WV",
			NetAmountDue = "6",
			BillingCode = "o",
			CorrectionIndicatorCode = "Id",
			StatementNumber = "i",
		};

		var actual = Map.MapObject<BSW_BeginningSegmentForCarriersServicesSettlement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IBoICgvm", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarriersServicesSettlement();
		subject.StandardCarrierAlphaCode = "h3";
		subject.StandardCarrierAlphaCode2 = "WV";
		subject.NetAmountDue = "6";
		subject.BillingCode = "o";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h3", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarriersServicesSettlement();
		subject.Date = "IBoICgvm";
		subject.StandardCarrierAlphaCode2 = "WV";
		subject.NetAmountDue = "6";
		subject.BillingCode = "o";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WV", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarriersServicesSettlement();
		subject.Date = "IBoICgvm";
		subject.StandardCarrierAlphaCode = "h3";
		subject.NetAmountDue = "6";
		subject.BillingCode = "o";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validatation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarriersServicesSettlement();
		subject.Date = "IBoICgvm";
		subject.StandardCarrierAlphaCode = "h3";
		subject.StandardCarrierAlphaCode2 = "WV";
		subject.BillingCode = "o";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validatation_RequiredBillingCode(string billingCode, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarriersServicesSettlement();
		subject.Date = "IBoICgvm";
		subject.StandardCarrierAlphaCode = "h3";
		subject.StandardCarrierAlphaCode2 = "WV";
		subject.NetAmountDue = "6";
		subject.BillingCode = billingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
