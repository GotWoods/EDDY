using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class XQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XQ*t*0e0ridb3*8R4T5jyG*H*45";

		var expected = new XQ_ReportingDateAction()
		{
			TransactionHandlingCode = "t",
			Date = "0e0ridb3",
			Date2 = "8R4T5jyG",
			ReferenceIdentification = "H",
			TransactionSetPurposeCode = "45",
		};

		var actual = Map.MapObject<XQ_ReportingDateAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new XQ_ReportingDateAction();
		subject.Date = "0e0ridb3";
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0e0ridb3", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new XQ_ReportingDateAction();
		subject.TransactionHandlingCode = "t";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
