using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class XQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XQ*V*qgKQXK*5oiL8N";

		var expected = new XQ_ReportingDateAction()
		{
			TransactionHandlingCode = "V",
			Date = "qgKQXK",
			Date2 = "5oiL8N",
		};

		var actual = Map.MapObject<XQ_ReportingDateAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new XQ_ReportingDateAction();
		//Required fields
		subject.Date = "qgKQXK";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qgKQXK", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new XQ_ReportingDateAction();
		//Required fields
		subject.TransactionHandlingCode = "V";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
