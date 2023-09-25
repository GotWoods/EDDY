using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class XQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XQ*2*p6vP4yUt*tzDK6aEU*S*np";

		var expected = new XQ_ReportingDateAction()
		{
			TransactionHandlingCode = "2",
			Date = "p6vP4yUt",
			Date2 = "tzDK6aEU",
			ReferenceIdentification = "S",
			TransactionSetPurposeCode = "np",
		};

		var actual = Map.MapObject<XQ_ReportingDateAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new XQ_ReportingDateAction();
		//Required fields
		subject.Date = "p6vP4yUt";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p6vP4yUt", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new XQ_ReportingDateAction();
		//Required fields
		subject.TransactionHandlingCode = "2";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
