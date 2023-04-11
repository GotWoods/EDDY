using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BTCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTC*iL*s*D*q*7*P*1*M*1*Uy*JjMCVTM*f";

		var expected = new BTC_BeginningSegmentForParameterTraceRegistration()
		{
			TransactionSetPurposeCode = "iL",
			ParameterTraceRegistrationTypeCode = "s",
			ParameterTraceTypeCode = "D",
			OutputEventSelectionCode = "q",
			ReferenceIdentification = "7",
			YesNoConditionOrResponseCode = "P",
			YesNoConditionOrResponseCode2 = "1",
			YesNoConditionOrResponseCode3 = "M",
			Count = 1,
			IdentificationCode = "Uy",
			AssociationOfAmericanRailroadsAARPoolCode = "JjMCVTM",
			IndustryCode = "f",
		};

		var actual = Map.MapObject<BTC_BeginningSegmentForParameterTraceRegistration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iL", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		subject.ParameterTraceRegistrationTypeCode = "s";
		subject.ParameterTraceTypeCode = "D";
		subject.OutputEventSelectionCode = "q";
		subject.ReferenceIdentification = "7";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredParameterTraceRegistrationTypeCode(string parameterTraceRegistrationTypeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		subject.TransactionSetPurposeCode = "iL";
		subject.ParameterTraceTypeCode = "D";
		subject.OutputEventSelectionCode = "q";
		subject.ReferenceIdentification = "7";
		subject.ParameterTraceRegistrationTypeCode = parameterTraceRegistrationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredParameterTraceTypeCode(string parameterTraceTypeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		subject.TransactionSetPurposeCode = "iL";
		subject.ParameterTraceRegistrationTypeCode = "s";
		subject.OutputEventSelectionCode = "q";
		subject.ReferenceIdentification = "7";
		subject.ParameterTraceTypeCode = parameterTraceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredOutputEventSelectionCode(string outputEventSelectionCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		subject.TransactionSetPurposeCode = "iL";
		subject.ParameterTraceRegistrationTypeCode = "s";
		subject.ParameterTraceTypeCode = "D";
		subject.ReferenceIdentification = "7";
		subject.OutputEventSelectionCode = outputEventSelectionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		subject.TransactionSetPurposeCode = "iL";
		subject.ParameterTraceRegistrationTypeCode = "s";
		subject.ParameterTraceTypeCode = "D";
		subject.OutputEventSelectionCode = "q";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
