using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CTHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTH*vN*D*6Z*Xp*f*QnfRveMc*QI2B*gj*Z*va*S";

		var expected = new CTH_BeginningSegmentForContractTransactionSet()
		{
			TransactionSetPurposeCode = "vN",
			ContractNumber = "D",
			ContractActionCode = "6Z",
			ReferenceIdentificationQualifier = "Xp",
			ReferenceIdentification = "f",
			Date = "QnfRveMc",
			Time = "QI2B",
			ContractLevelCode = "gj",
			ContractDateBasisCode = "Z",
			EntityIdentifierCode = "va",
			Description = "S",
		};

		var actual = Map.MapObject<CTH_BeginningSegmentForContractTransactionSet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vN", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new CTH_BeginningSegmentForContractTransactionSet();
		subject.ContractNumber = "D";
		subject.ContractActionCode = "6Z";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validatation_RequiredContractNumber(string contractNumber, bool isValidExpected)
	{
		var subject = new CTH_BeginningSegmentForContractTransactionSet();
		subject.TransactionSetPurposeCode = "vN";
		subject.ContractActionCode = "6Z";
		subject.ContractNumber = contractNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6Z", true)]
	public void Validatation_RequiredContractActionCode(string contractActionCode, bool isValidExpected)
	{
		var subject = new CTH_BeginningSegmentForContractTransactionSet();
		subject.TransactionSetPurposeCode = "vN";
		subject.ContractNumber = "D";
		subject.ContractActionCode = contractActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Xp", "f", true)]
	[InlineData("", "f", false)]
	[InlineData("Xp", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CTH_BeginningSegmentForContractTransactionSet();
		subject.TransactionSetPurposeCode = "vN";
		subject.ContractNumber = "D";
		subject.ContractActionCode = "6Z";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Z", "va", true)]
	[InlineData("", "va", false)]
	[InlineData("Z", "", false)]
	public void Validation_AllAreRequiredContractDateBasisCode(string contractDateBasisCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CTH_BeginningSegmentForContractTransactionSet();
		subject.TransactionSetPurposeCode = "vN";
		subject.ContractNumber = "D";
		subject.ContractActionCode = "6Z";
		subject.ContractDateBasisCode = contractDateBasisCode;
		subject.EntityIdentifierCode = entityIdentifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
