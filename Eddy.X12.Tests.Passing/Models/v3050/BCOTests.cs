using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCO*iX*z*4aP3gt*w*4R*eq2M7t*1kKu7C*Ck*ub*q*d5*5";

		var expected = new BCO_BeginningSegmentForProcurementNotices()
		{
			TransactionSetPurposeCode = "iX",
			RequestForQuoteReferenceNumber = "z",
			Date = "4aP3gt",
			ReferenceNumber = "w",
			ContractStatusCode = "4R",
			Date2 = "eq2M7t",
			Date3 = "1kKu7C",
			AcknowledgmentType = "Ck",
			ReferenceNumberQualifier = "ub",
			ReferenceNumber2 = "q",
			TransactionTypeCode = "d5",
			ActionCode = "5",
		};

		var actual = Map.MapObject<BCO_BeginningSegmentForProcurementNotices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iX", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCO_BeginningSegmentForProcurementNotices();
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
