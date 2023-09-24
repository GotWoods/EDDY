using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class XQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XQ*c*awCLpz5m*OUj60G30*1*7V";

		var expected = new XQ_ReportingDateAction()
		{
			TransactionHandlingCode = "c",
			Date = "awCLpz5m",
			Date2 = "OUj60G30",
			ReferenceIdentification = "1",
			TransactionSetPurposeCode = "7V",
		};

		var actual = Map.MapObject<XQ_ReportingDateAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new XQ_ReportingDateAction();
		//Required fields
		subject.Date = "awCLpz5m";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("awCLpz5m", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new XQ_ReportingDateAction();
		//Required fields
		subject.TransactionHandlingCode = "c";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
