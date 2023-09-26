using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BGPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BGP*l2*ug*qk*h*i*6*i*wQawhn*G";

		var expected = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice()
		{
			TransactionSetPurposeCode = "l2",
			ProblemLogReasonCode = "ug",
			ReferenceIdentificationQualifier = "qk",
			ReferenceIdentification = "h",
			EquipmentInitial = "i",
			EquipmentNumber = "6",
			DateTimePeriod = "i",
			StandardPointLocationCode = "wQawhn",
			InterchangeTrainIdentification = "G",
		};

		var actual = Map.MapObject<BGP_BeginningSegmentForProblemLogInquiryOrAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l2", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qk";
			subject.ReferenceIdentification = "h";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "i";
			subject.EquipmentNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qk", "h", true)]
	[InlineData("qk", "", false)]
	[InlineData("", "h", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "l2";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "i";
			subject.EquipmentNumber = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "6", true)]
	[InlineData("i", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "l2";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qk";
			subject.ReferenceIdentification = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
