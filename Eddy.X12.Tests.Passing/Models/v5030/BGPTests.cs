using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BGPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BGP*Fo*6k*as*u*D*j*9*GF7ary*b";

		var expected = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice()
		{
			TransactionSetPurposeCode = "Fo",
			ProblemLogReasonCode = "6k",
			ReferenceIdentificationQualifier = "as",
			ReferenceIdentification = "u",
			EquipmentInitial = "D",
			EquipmentNumber = "j",
			DateTimePeriod = "9",
			StandardPointLocationCode = "GF7ary",
			InterchangeTrainIdentification = "b",
		};

		var actual = Map.MapObject<BGP_BeginningSegmentForProblemLogInquiryOrAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fo", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "as";
			subject.ReferenceIdentification = "u";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "D";
			subject.EquipmentNumber = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("as", "u", true)]
	[InlineData("as", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "Fo";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "D";
			subject.EquipmentNumber = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "j", true)]
	[InlineData("D", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "Fo";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "as";
			subject.ReferenceIdentification = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
