using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCP*Nk*HX*a*V2AwLejs*VR*W2*OivbinAY*Wd0O*L*m*W*Z*h";

		var expected = new BCP_BeginningSegmentForContractPricingProposal()
		{
			TransactionSetPurposeCode = "Nk",
			ReferenceIdentificationQualifier = "HX",
			ReferenceIdentification = "a",
			Date = "V2AwLejs",
			ContractActionCode = "VR",
			ContractTypeCode = "W2",
			Date2 = "OivbinAY",
			Time = "Wd0O",
			ChangeOrderSequenceNumber = "L",
			ReferenceIdentification2 = "m",
			ReferenceIdentification3 = "W",
			Description = "Z",
			Description2 = "h",
		};

		var actual = Map.MapObject<BCP_BeginningSegmentForContractPricingProposal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nk", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.ReferenceIdentificationQualifier = "HX";
		subject.ReferenceIdentification = "a";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HX", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "Nk";
		subject.ReferenceIdentification = "a";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BCP_BeginningSegmentForContractPricingProposal();
		//Required fields
		subject.TransactionSetPurposeCode = "Nk";
		subject.ReferenceIdentificationQualifier = "HX";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
