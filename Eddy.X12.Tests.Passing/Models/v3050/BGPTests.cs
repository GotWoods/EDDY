using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BGPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BGP*ml*tO*rX*D*X*E*X*nYR8na*8";

		var expected = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice()
		{
			TransactionSetPurposeCode = "ml",
			ProblemLogReasonCode = "tO",
			ReferenceNumberQualifier = "rX",
			ReferenceNumber = "D",
			EquipmentInitial = "X",
			EquipmentNumber = "E",
			DateTimePeriod = "X",
			StandardPointLocationCode = "nYR8na",
			InterchangeTrainIdentification = "8",
		};

		var actual = Map.MapObject<BGP_BeginningSegmentForProblemLogInquiryOrAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ml", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		subject.ProblemLogReasonCode = "tO";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "rX";
			subject.ReferenceNumber = "D";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "X";
			subject.EquipmentNumber = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tO", true)]
	public void Validation_RequiredProblemLogReasonCode(string problemLogReasonCode, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "ml";
		//Test Parameters
		subject.ProblemLogReasonCode = problemLogReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "rX";
			subject.ReferenceNumber = "D";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "X";
			subject.EquipmentNumber = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rX", "D", true)]
	[InlineData("rX", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "ml";
		subject.ProblemLogReasonCode = "tO";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "X";
			subject.EquipmentNumber = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "E", true)]
	[InlineData("X", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new BGP_BeginningSegmentForProblemLogInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "ml";
		subject.ProblemLogReasonCode = "tO";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "rX";
			subject.ReferenceNumber = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
