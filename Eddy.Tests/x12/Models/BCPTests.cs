using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCP*6k*B6*T*hZr1vy2N*5k*Re*WyZ3JIqf*10WC*Q*u*r*Y*r";

		var expected = new BCP_BeginningSegmentForContractPricingProposal()
		{
			TransactionSetPurposeCode = "6k",
			ReferenceIdentificationQualifier = "B6",
			ReferenceIdentification = "T",
			Date = "hZr1vy2N",
			ContractActionCode = "5k",
			ContractTypeCode = "Re",
			Date2 = "WyZ3JIqf",
			Time = "10WC",
			ChangeOrderSequenceNumber = "Q",
			ReferenceIdentification2 = "u",
			ReferenceIdentification3 = "r",
			Description = "Y",
			Description2 = "r",
		};

		var actual = Map.MapObject<BCP_BeginningSegmentForContractPricingProposal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6k", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		subject.ReferenceIdentificationQualifier = "B6";
		subject.ReferenceIdentification = "T";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B6", true)]
	public void Validatation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		subject.TransactionSetPurposeCode = "6k";
		subject.ReferenceIdentification = "T";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		subject.TransactionSetPurposeCode = "6k";
		subject.ReferenceIdentificationQualifier = "B6";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
