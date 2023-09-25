using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class XQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XQ*L*I3Gv5SrX*322f9xt4";

		var expected = new XQ_ReportingDateAction()
		{
			TransactionHandlingCode = "L",
			Date = "I3Gv5SrX",
			Date2 = "322f9xt4",
		};

		var actual = Map.MapObject<XQ_ReportingDateAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredTransactionHandlingCode(string transactionHandlingCode, bool isValidExpected)
	{
		var subject = new XQ_ReportingDateAction();
		//Required fields
		subject.Date = "I3Gv5SrX";
		//Test Parameters
		subject.TransactionHandlingCode = transactionHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I3Gv5SrX", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new XQ_ReportingDateAction();
		//Required fields
		subject.TransactionHandlingCode = "L";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
