using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class CTHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTH*0w*g*Ir*dh*H*WvHUM0lF*6lfZ*Kl*i*xB*Y";

		var expected = new CTH_BeginningSegmentForContractTransactionSet()
		{
			TransactionSetPurposeCode = "0w",
			ContractNumber = "g",
			ContractActionCode = "Ir",
			ReferenceIdentificationQualifier = "dh",
			ReferenceIdentification = "H",
			Date = "WvHUM0lF",
			Time = "6lfZ",
			ContractLevelCode = "Kl",
			ContractDateBasisCode = "i",
			EntityIdentifierCode = "xB",
			Description = "Y",
		};

		var actual = Map.MapObject<CTH_BeginningSegmentForContractTransactionSet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0w", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new CTH_BeginningSegmentForContractTransactionSet();
		//Required fields
		subject.ContractNumber = "g";
		subject.ContractActionCode = "Ir";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "dh";
			subject.ReferenceIdentification = "H";
		}
		if(!string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode))
		{
			subject.ContractDateBasisCode = "i";
			subject.EntityIdentifierCode = "xB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredContractNumber(string contractNumber, bool isValidExpected)
	{
		var subject = new CTH_BeginningSegmentForContractTransactionSet();
		//Required fields
		subject.TransactionSetPurposeCode = "0w";
		subject.ContractActionCode = "Ir";
		//Test Parameters
		subject.ContractNumber = contractNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "dh";
			subject.ReferenceIdentification = "H";
		}
		if(!string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode))
		{
			subject.ContractDateBasisCode = "i";
			subject.EntityIdentifierCode = "xB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ir", true)]
	public void Validation_RequiredContractActionCode(string contractActionCode, bool isValidExpected)
	{
		var subject = new CTH_BeginningSegmentForContractTransactionSet();
		//Required fields
		subject.TransactionSetPurposeCode = "0w";
		subject.ContractNumber = "g";
		//Test Parameters
		subject.ContractActionCode = contractActionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "dh";
			subject.ReferenceIdentification = "H";
		}
		if(!string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode))
		{
			subject.ContractDateBasisCode = "i";
			subject.EntityIdentifierCode = "xB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dh", "H", true)]
	[InlineData("dh", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CTH_BeginningSegmentForContractTransactionSet();
		//Required fields
		subject.TransactionSetPurposeCode = "0w";
		subject.ContractNumber = "g";
		subject.ContractActionCode = "Ir";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode))
		{
			subject.ContractDateBasisCode = "i";
			subject.EntityIdentifierCode = "xB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "xB", true)]
	[InlineData("i", "", false)]
	[InlineData("", "xB", false)]
	public void Validation_AllAreRequiredContractDateBasisCode(string contractDateBasisCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CTH_BeginningSegmentForContractTransactionSet();
		//Required fields
		subject.TransactionSetPurposeCode = "0w";
		subject.ContractNumber = "g";
		subject.ContractActionCode = "Ir";
		//Test Parameters
		subject.ContractDateBasisCode = contractDateBasisCode;
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "dh";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
