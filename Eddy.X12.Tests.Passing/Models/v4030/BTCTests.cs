using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BTCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTC*e3*p*M*6*q*7*e*H*9*tn*TyJJwrR*u";

		var expected = new BTC_BeginningSegmentForParameterTraceRegistration()
		{
			TransactionSetPurposeCode = "e3",
			ParameterTraceRegistrationTypeCode = "p",
			ParameterTraceTypeCode = "M",
			OutputEventSelectionCode = "6",
			ReferenceIdentification = "q",
			YesNoConditionOrResponseCode = "7",
			YesNoConditionOrResponseCode2 = "e",
			YesNoConditionOrResponseCode3 = "H",
			Count = 9,
			IdentificationCode = "tn",
			AssociationOfAmericanRailroadsAARPoolCode = "TyJJwrR",
			IndustryCode = "u",
		};

		var actual = Map.MapObject<BTC_BeginningSegmentForParameterTraceRegistration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e3", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.ParameterTraceRegistrationTypeCode = "p";
		subject.ParameterTraceTypeCode = "M";
		subject.OutputEventSelectionCode = "6";
		subject.ReferenceIdentification = "q";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredParameterTraceRegistrationTypeCode(string parameterTraceRegistrationTypeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "e3";
		subject.ParameterTraceTypeCode = "M";
		subject.OutputEventSelectionCode = "6";
		subject.ReferenceIdentification = "q";
		//Test Parameters
		subject.ParameterTraceRegistrationTypeCode = parameterTraceRegistrationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredParameterTraceTypeCode(string parameterTraceTypeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "e3";
		subject.ParameterTraceRegistrationTypeCode = "p";
		subject.OutputEventSelectionCode = "6";
		subject.ReferenceIdentification = "q";
		//Test Parameters
		subject.ParameterTraceTypeCode = parameterTraceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredOutputEventSelectionCode(string outputEventSelectionCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "e3";
		subject.ParameterTraceRegistrationTypeCode = "p";
		subject.ParameterTraceTypeCode = "M";
		subject.ReferenceIdentification = "q";
		//Test Parameters
		subject.OutputEventSelectionCode = outputEventSelectionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "e3";
		subject.ParameterTraceRegistrationTypeCode = "p";
		subject.ParameterTraceTypeCode = "M";
		subject.OutputEventSelectionCode = "6";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
