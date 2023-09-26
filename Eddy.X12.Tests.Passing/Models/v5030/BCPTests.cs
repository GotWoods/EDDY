using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCP*nK*i5*Q*DZxwfd6Z*MI*2G*5X1DdBQi*hNHQ*Y*7*f*6*H";

		var expected = new BCP_BeginningSegmentForContractPricingProposal()
		{
			TransactionSetPurposeCode = "nK",
			ReferenceIdentificationQualifier = "i5",
			ReferenceIdentification = "Q",
			Date = "DZxwfd6Z",
			ContractActionCode = "MI",
			ContractTypeCode = "2G",
			Date2 = "5X1DdBQi",
			Time = "hNHQ",
			ChangeOrderSequenceNumber = "Y",
			ReferenceIdentification2 = "7",
			ReferenceIdentification3 = "f",
			Description = "6",
			Description2 = "H",
		};

		var actual = Map.MapObject<BCP_BeginningSegmentForContractPricingProposal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nK", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.ReferenceIdentificationQualifier = "i5";
		subject.ReferenceIdentification = "Q";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i5", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "nK";
		subject.ReferenceIdentification = "Q";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "nK";
		subject.ReferenceIdentificationQualifier = "i5";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
