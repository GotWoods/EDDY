using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BR*jx*6c*wdN3enEX*68*u*u*pj*C*yXYi*wd*o";

		var expected = new BR_BeginningSegmentForMaterialManagement()
		{
			TransactionSetPurposeCode = "jx",
			TransactionTypeCode = "6c",
			Date = "wdN3enEX",
			IdentificationCode = "68",
			IdentificationCodeQualifier = "u",
			ActionCode = "u",
			ReferenceIdentificationQualifier = "pj",
			ReferenceIdentification = "C",
			Time = "yXYi",
			ReferenceIdentificationQualifier2 = "wd",
			ReferenceIdentification2 = "o",
		};

		var actual = Map.MapObject<BR_BeginningSegmentForMaterialManagement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jx", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionTypeCode = "6c";
		subject.Date = "wdN3enEX";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pj";
			subject.ReferenceIdentification = "C";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "wd";
			subject.ReferenceIdentification2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6c", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "jx";
		subject.Date = "wdN3enEX";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pj";
			subject.ReferenceIdentification = "C";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "wd";
			subject.ReferenceIdentification2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wdN3enEX", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "jx";
		subject.TransactionTypeCode = "6c";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pj";
			subject.ReferenceIdentification = "C";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "wd";
			subject.ReferenceIdentification2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "68", true)]
	[InlineData("u", "", false)]
	[InlineData("", "68", true)]
	public void Validation_ARequiresBIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "jx";
		subject.TransactionTypeCode = "6c";
		subject.Date = "wdN3enEX";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pj";
			subject.ReferenceIdentification = "C";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "wd";
			subject.ReferenceIdentification2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pj", "C", true)]
	[InlineData("pj", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "jx";
		subject.TransactionTypeCode = "6c";
		subject.Date = "wdN3enEX";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "wd";
			subject.ReferenceIdentification2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wd", "o", true)]
	[InlineData("wd", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		//Required fields
		subject.TransactionSetPurposeCode = "jx";
		subject.TransactionTypeCode = "6c";
		subject.Date = "wdN3enEX";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pj";
			subject.ReferenceIdentification = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
