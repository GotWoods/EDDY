using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCP*LS*4B*v*BxUjAi*lg*yd*87QMHr*79XW*p*x*w*M*J";

		var expected = new BCP_BeginningSegmentForContractPricingProposal()
		{
			TransactionSetPurposeCode = "LS",
			ReferenceNumberQualifier = "4B",
			ReferenceNumber = "v",
			Date = "BxUjAi",
			ContractActionCode = "lg",
			ContractTypeCode = "yd",
			Date2 = "87QMHr",
			Time = "79XW",
			ChangeOrderSequenceNumber = "p",
			ReferenceNumber2 = "x",
			ReferenceNumber3 = "w",
			Description = "M",
			Description2 = "J",
		};

		var actual = Map.MapObject<BCP_BeginningSegmentForContractPricingProposal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LS", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.ReferenceNumberQualifier = "4B";
		subject.ReferenceNumber = "v";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4B", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "LS";
		subject.ReferenceNumber = "v";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "LS";
		subject.ReferenceNumberQualifier = "4B";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
