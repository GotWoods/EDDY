using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BGPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BGP*1V*Om*z9*T*u*9*S*YWonjn*s";

		var expected = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice()
		{
			TransactionSetPurposeCode = "1V",
			ProblemLogReasonCode = "Om",
			ReferenceIdentificationQualifier = "z9",
			ReferenceIdentification = "T",
			EquipmentInitial = "u",
			EquipmentNumber = "9",
			DateTimePeriod = "S",
			StandardPointLocationCode = "YWonjn",
			InterchangeTrainIdentification = "s",
		};

		var actual = Map.MapObject<BGP_BeginningSegmentForProblemLogInquiryOrAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1V", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		subject.ProblemLogReasonCode = "Om";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "z9";
			subject.ReferenceIdentification = "T";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "u";
			subject.EquipmentNumber = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Om", true)]
	public void Validation_RequiredProblemLogReasonCode(string problemLogReasonCode, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "1V";
		//Test Parameters
		subject.ProblemLogReasonCode = problemLogReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "z9";
			subject.ReferenceIdentification = "T";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "u";
			subject.EquipmentNumber = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z9", "T", true)]
	[InlineData("z9", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "1V";
		subject.ProblemLogReasonCode = "Om";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "u";
			subject.EquipmentNumber = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "9", true)]
	[InlineData("u", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "1V";
		subject.ProblemLogReasonCode = "Om";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "z9";
			subject.ReferenceIdentification = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
