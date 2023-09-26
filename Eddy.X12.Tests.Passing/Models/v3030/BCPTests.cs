using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCP*6p*gc*2*4Mm6bC*dY*At*HclNsl*5EQr*5*b*5*0*I";

		var expected = new BCP_BeginningSegmentForContractPricingProposal()
		{
			TransactionSetPurposeCode = "6p",
			ReferenceNumberQualifier = "gc",
			ReferenceNumber = "2",
			Date = "4Mm6bC",
			ContractActionCode = "dY",
			ContractTypeCode = "At",
			Date2 = "HclNsl",
			Time = "5EQr",
			ChangeOrderSequenceNumber = "5",
			ReferenceNumber2 = "b",
			ReferenceNumber3 = "5",
			Description = "0",
			Description2 = "I",
		};

		var actual = Map.MapObject<BCP_BeginningSegmentForContractPricingProposal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6p", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.ReferenceNumberQualifier = "gc";
		subject.ReferenceNumber = "2";
		subject.Date = "4Mm6bC";
		subject.ContractActionCode = "dY";
		subject.ContractTypeCode = "At";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gc", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "6p";
		subject.ReferenceNumber = "2";
		subject.Date = "4Mm6bC";
		subject.ContractActionCode = "dY";
		subject.ContractTypeCode = "At";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "6p";
		subject.ReferenceNumberQualifier = "gc";
		subject.Date = "4Mm6bC";
		subject.ContractActionCode = "dY";
		subject.ContractTypeCode = "At";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4Mm6bC", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "6p";
		subject.ReferenceNumberQualifier = "gc";
		subject.ReferenceNumber = "2";
		subject.ContractActionCode = "dY";
		subject.ContractTypeCode = "At";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dY", true)]
	public void Validation_RequiredContractActionCode(string contractActionCode, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "6p";
		subject.ReferenceNumberQualifier = "gc";
		subject.ReferenceNumber = "2";
		subject.Date = "4Mm6bC";
		subject.ContractTypeCode = "At";
		//Test Parameters
		subject.ContractActionCode = contractActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("At", true)]
	public void Validation_RequiredContractTypeCode(string contractTypeCode, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "6p";
		subject.ReferenceNumberQualifier = "gc";
		subject.ReferenceNumber = "2";
		subject.Date = "4Mm6bC";
		subject.ContractActionCode = "dY";
		//Test Parameters
		subject.ContractTypeCode = contractTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
