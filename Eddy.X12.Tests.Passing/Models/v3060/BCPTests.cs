using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCP*LW*8N*4*6lRqn1*Xh*RQ*FjMZNT*817U*f*2*5*h*w";

		var expected = new BCP_BeginningSegmentForContractPricingProposal()
		{
			TransactionSetPurposeCode = "LW",
			ReferenceIdentificationQualifier = "8N",
			ReferenceIdentification = "4",
			Date = "6lRqn1",
			ContractActionCode = "Xh",
			ContractTypeCode = "RQ",
			Date2 = "FjMZNT",
			Time = "817U",
			ChangeOrderSequenceNumber = "f",
			ReferenceIdentification2 = "2",
			ReferenceIdentification3 = "5",
			Description = "h",
			Description2 = "w",
		};

		var actual = Map.MapObject<BCP_BeginningSegmentForContractPricingProposal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LW", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.ReferenceIdentificationQualifier = "8N";
		subject.ReferenceIdentification = "4";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8N", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "LW";
		subject.ReferenceIdentification = "4";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "LW";
		subject.ReferenceIdentificationQualifier = "8N";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
