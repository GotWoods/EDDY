using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BR*SQ*VA*ssviKp*0r*v*X*O6*q*lQls*sb*d";

		var expected = new BR_BeginningSegmentForMaterialManagement()
		{
			TransactionSetPurposeCode = "SQ",
			TransactionTypeCode = "VA",
			Date = "ssviKp",
			IdentificationCode = "0r",
			IdentificationCodeQualifier = "v",
			ActionCode = "X",
			ReferenceNumberQualifier = "O6",
			ReferenceNumber = "q",
			Time = "lQls",
			ReferenceNumberQualifier2 = "sb",
			ReferenceNumber2 = "d",
		};

		var actual = Map.MapObject<BR_BeginningSegmentForMaterialManagement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SQ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionTypeCode = "VA";
		subject.Date = "ssviKp";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "O6";
			subject.ReferenceNumber = "q";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "sb";
			subject.ReferenceNumber2 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VA", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "SQ";
		subject.Date = "ssviKp";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "O6";
			subject.ReferenceNumber = "q";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "sb";
			subject.ReferenceNumber2 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ssviKp", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "SQ";
		subject.TransactionTypeCode = "VA";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "O6";
			subject.ReferenceNumber = "q";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "sb";
			subject.ReferenceNumber2 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "0r", true)]
	[InlineData("v", "", false)]
	[InlineData("", "0r", true)]
	public void Validation_ARequiresBIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "SQ";
		subject.TransactionTypeCode = "VA";
		subject.Date = "ssviKp";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "O6";
			subject.ReferenceNumber = "q";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "sb";
			subject.ReferenceNumber2 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O6", "q", true)]
	[InlineData("O6", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "SQ";
		subject.TransactionTypeCode = "VA";
		subject.Date = "ssviKp";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "sb";
			subject.ReferenceNumber2 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sb", "d", true)]
	[InlineData("sb", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "SQ";
		subject.TransactionTypeCode = "VA";
		subject.Date = "ssviKp";
		//Test Parameters
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "O6";
			subject.ReferenceNumber = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
