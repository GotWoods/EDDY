using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BR*fR*HI*xUAy8F*Rv*u*h*Ex*7*sgiS*ju*P";

		var expected = new BR_BeginningSegmentForMaterialManagement()
		{
			TransactionSetPurposeCode = "fR",
			TransactionTypeCode = "HI",
			Date = "xUAy8F",
			IdentificationCode = "Rv",
			IdentificationCodeQualifier = "u",
			ActionCode = "h",
			ReferenceNumberQualifier = "Ex",
			ReferenceNumber = "7",
			Time = "sgiS",
			ReferenceNumberQualifier2 = "ju",
			ReferenceNumber2 = "P",
		};

		var actual = Map.MapObject<BR_BeginningSegmentForMaterialManagement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fR", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionTypeCode = "HI";
		subject.Date = "xUAy8F";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ex";
			subject.ReferenceNumber = "7";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "ju";
			subject.ReferenceNumber2 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HI", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "fR";
		subject.Date = "xUAy8F";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ex";
			subject.ReferenceNumber = "7";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "ju";
			subject.ReferenceNumber2 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xUAy8F", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "fR";
		subject.TransactionTypeCode = "HI";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ex";
			subject.ReferenceNumber = "7";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "ju";
			subject.ReferenceNumber2 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "Rv", true)]
	[InlineData("u", "", false)]
	[InlineData("", "Rv", true)]
	public void Validation_ARequiresBIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "fR";
		subject.TransactionTypeCode = "HI";
		subject.Date = "xUAy8F";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ex";
			subject.ReferenceNumber = "7";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "ju";
			subject.ReferenceNumber2 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ex", "7", true)]
	[InlineData("Ex", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "fR";
		subject.TransactionTypeCode = "HI";
		subject.Date = "xUAy8F";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "ju";
			subject.ReferenceNumber2 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ju", "P", true)]
	[InlineData("ju", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "fR";
		subject.TransactionTypeCode = "HI";
		subject.Date = "xUAy8F";
		//Test Parameters
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ex";
			subject.ReferenceNumber = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
