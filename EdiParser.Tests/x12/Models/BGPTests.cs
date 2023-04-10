using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BGPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BGP*R5*C3*Vp*L*j*r*T*0Wh5kN*T";

		var expected = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice()
		{
			TransactionSetPurposeCode = "R5",
			ProblemLogReasonCode = "C3",
			ReferenceIdentificationQualifier = "Vp",
			ReferenceIdentification = "L",
			EquipmentInitial = "j",
			EquipmentNumber = "r",
			DateTimePeriod = "T",
			StandardPointLocationCode = "0Wh5kN",
			InterchangeTrainIdentification = "T",
		};

		var actual = Map.MapObject<BGP_BeginningSegmentForProblemLogInquiryOrAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R5", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Vp", "L", true)]
	[InlineData("", "L", false)]
	[InlineData("Vp", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		subject.TransactionSetPurposeCode = "R5";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("j", "r", true)]
	[InlineData("", "r", false)]
	[InlineData("j", "", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		subject.TransactionSetPurposeCode = "R5";
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
