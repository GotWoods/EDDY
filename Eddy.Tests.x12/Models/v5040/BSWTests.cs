using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class BSWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSW*BHTRGEm6*QZ*xc*J*m*aj*6";

		var expected = new BSW_BeginningSegmentForCarrierServicesSettlement()
		{
			Date = "BHTRGEm6",
			StandardCarrierAlphaCode = "QZ",
			StandardCarrierAlphaCode2 = "xc",
			NetAmountDue = "J",
			BillingCode = "m",
			CorrectionIndicator = "aj",
			StatementNumber = "6",
		};

		var actual = Map.MapObject<BSW_BeginningSegmentForCarrierServicesSettlement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BHTRGEm6", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.StandardCarrierAlphaCode = "QZ";
		subject.StandardCarrierAlphaCode2 = "xc";
		subject.NetAmountDue = "J";
		subject.BillingCode = "m";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QZ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.Date = "BHTRGEm6";
		subject.StandardCarrierAlphaCode2 = "xc";
		subject.NetAmountDue = "J";
		subject.BillingCode = "m";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xc", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.Date = "BHTRGEm6";
		subject.StandardCarrierAlphaCode = "QZ";
		subject.NetAmountDue = "J";
		subject.BillingCode = "m";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.Date = "BHTRGEm6";
		subject.StandardCarrierAlphaCode = "QZ";
		subject.StandardCarrierAlphaCode2 = "xc";
		subject.BillingCode = "m";
		//Test Parameters
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredBillingCode(string billingCode, bool isValidExpected)
	{
		var subject = new BSW_BeginningSegmentForCarrierServicesSettlement();
		//Required fields
		subject.Date = "BHTRGEm6";
		subject.StandardCarrierAlphaCode = "QZ";
		subject.StandardCarrierAlphaCode2 = "xc";
		subject.NetAmountDue = "J";
		//Test Parameters
		subject.BillingCode = billingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
