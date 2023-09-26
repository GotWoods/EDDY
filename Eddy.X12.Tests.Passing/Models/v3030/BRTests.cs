using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BR*38*rG*Z4ZYXx*if*w*Y*CZ*w*SSwF*A1*3";

		var expected = new BR_BeginningSegmentForMaterialManagement()
		{
			TransactionSetPurposeCode = "38",
			TransactionTypeCode = "rG",
			Date = "Z4ZYXx",
			IdentificationCode = "if",
			IdentificationCodeQualifier = "w",
			ActionCode = "Y",
			ReferenceNumberQualifier = "CZ",
			ReferenceNumber = "w",
			Time = "SSwF",
			ReferenceNumberQualifier2 = "A1",
			ReferenceNumber2 = "3",
		};

		var actual = Map.MapObject<BR_BeginningSegmentForMaterialManagement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("38", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionTypeCode = "rG";
		subject.Date = "Z4ZYXx";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "CZ";
			subject.ReferenceNumber = "w";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "A1";
			subject.ReferenceNumber2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rG", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "38";
		subject.Date = "Z4ZYXx";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "CZ";
			subject.ReferenceNumber = "w";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "A1";
			subject.ReferenceNumber2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z4ZYXx", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "38";
		subject.TransactionTypeCode = "rG";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "CZ";
			subject.ReferenceNumber = "w";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "A1";
			subject.ReferenceNumber2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "if", true)]
	[InlineData("w", "", false)]
	[InlineData("", "if", true)]
	public void Validation_ARequiresBIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "38";
		subject.TransactionTypeCode = "rG";
		subject.Date = "Z4ZYXx";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "CZ";
			subject.ReferenceNumber = "w";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "A1";
			subject.ReferenceNumber2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CZ", "w", true)]
	[InlineData("CZ", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "38";
		subject.TransactionTypeCode = "rG";
		subject.Date = "Z4ZYXx";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "A1";
			subject.ReferenceNumber2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A1", "3", true)]
	[InlineData("A1", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "38";
		subject.TransactionTypeCode = "rG";
		subject.Date = "Z4ZYXx";
		//Test Parameters
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "CZ";
			subject.ReferenceNumber = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
