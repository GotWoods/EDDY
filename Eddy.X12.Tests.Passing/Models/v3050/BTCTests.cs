using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BTCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTC*9d*l*X*G*V*7*P*T*3*0s*WMGYtJF*l";

		var expected = new BTC_BeginningSegmentForParameterTraceRegistration()
		{
			TransactionSetPurposeCode = "9d",
			ParameterTraceRegistrationTypeCode = "l",
			ParameterTraceTypeCode = "X",
			OutputEventSelectionCode = "G",
			ReferenceNumber = "V",
			YesNoConditionOrResponseCode = "7",
			YesNoConditionOrResponseCode2 = "P",
			YesNoConditionOrResponseCode3 = "T",
			Count = 3,
			IdentificationCode = "0s",
			AssociationOfAmericanRailroadsAARPoolCode = "WMGYtJF",
			IndustryCode = "l",
		};

		var actual = Map.MapObject<BTC_BeginningSegmentForParameterTraceRegistration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9d", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.ParameterTraceRegistrationTypeCode = "l";
		subject.ParameterTraceTypeCode = "X";
		subject.OutputEventSelectionCode = "G";
		subject.ReferenceNumber = "V";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredParameterTraceRegistrationTypeCode(string parameterTraceRegistrationTypeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "9d";
		subject.ParameterTraceTypeCode = "X";
		subject.OutputEventSelectionCode = "G";
		subject.ReferenceNumber = "V";
		//Test Parameters
		subject.ParameterTraceRegistrationTypeCode = parameterTraceRegistrationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredParameterTraceTypeCode(string parameterTraceTypeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "9d";
		subject.ParameterTraceRegistrationTypeCode = "l";
		subject.OutputEventSelectionCode = "G";
		subject.ReferenceNumber = "V";
		//Test Parameters
		subject.ParameterTraceTypeCode = parameterTraceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredOutputEventSelectionCode(string outputEventSelectionCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "9d";
		subject.ParameterTraceRegistrationTypeCode = "l";
		subject.ParameterTraceTypeCode = "X";
		subject.ReferenceNumber = "V";
		//Test Parameters
		subject.OutputEventSelectionCode = outputEventSelectionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "9d";
		subject.ParameterTraceRegistrationTypeCode = "l";
		subject.ParameterTraceTypeCode = "X";
		subject.OutputEventSelectionCode = "G";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
