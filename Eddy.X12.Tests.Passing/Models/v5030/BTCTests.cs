using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BTCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTC*Lu*Y*1*K*N*e*p*l*1*hM*nqjEVdR*l";

		var expected = new BTC_BeginningSegmentForParameterTraceRegistration()
		{
			TransactionSetPurposeCode = "Lu",
			ParameterTraceRegistrationTypeCode = "Y",
			ParameterTraceTypeCode = "1",
			OutputEventSelectionCode = "K",
			ReferenceIdentification = "N",
			YesNoConditionOrResponseCode = "e",
			YesNoConditionOrResponseCode2 = "p",
			YesNoConditionOrResponseCode3 = "l",
			Count = 1,
			IdentificationCode = "hM",
			AssociationOfAmericanRailroadsAARPoolCode = "nqjEVdR",
			IndustryCode = "l",
		};

		var actual = Map.MapObject<BTC_BeginningSegmentForParameterTraceRegistration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lu", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.ParameterTraceRegistrationTypeCode = "Y";
		subject.ParameterTraceTypeCode = "1";
		subject.OutputEventSelectionCode = "K";
		subject.ReferenceIdentification = "N";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredParameterTraceRegistrationTypeCode(string parameterTraceRegistrationTypeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "Lu";
		subject.ParameterTraceTypeCode = "1";
		subject.OutputEventSelectionCode = "K";
		subject.ReferenceIdentification = "N";
		//Test Parameters
		subject.ParameterTraceRegistrationTypeCode = parameterTraceRegistrationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredParameterTraceTypeCode(string parameterTraceTypeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "Lu";
		subject.ParameterTraceRegistrationTypeCode = "Y";
		subject.OutputEventSelectionCode = "K";
		subject.ReferenceIdentification = "N";
		//Test Parameters
		subject.ParameterTraceTypeCode = parameterTraceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredOutputEventSelectionCode(string outputEventSelectionCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "Lu";
		subject.ParameterTraceRegistrationTypeCode = "Y";
		subject.ParameterTraceTypeCode = "1";
		subject.ReferenceIdentification = "N";
		//Test Parameters
		subject.OutputEventSelectionCode = outputEventSelectionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "Lu";
		subject.ParameterTraceRegistrationTypeCode = "Y";
		subject.ParameterTraceTypeCode = "1";
		subject.OutputEventSelectionCode = "K";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
