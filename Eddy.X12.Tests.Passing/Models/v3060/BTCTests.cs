using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BTCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTC*dl*n*O*S*k*N*E*e*9*JK*5Dk0BC4*E";

		var expected = new BTC_BeginningSegmentForParameterTraceRegistration()
		{
			TransactionSetPurposeCode = "dl",
			ParameterTraceRegistrationTypeCode = "n",
			ParameterTraceTypeCode = "O",
			OutputEventSelectionCode = "S",
			ReferenceIdentification = "k",
			YesNoConditionOrResponseCode = "N",
			YesNoConditionOrResponseCode2 = "E",
			YesNoConditionOrResponseCode3 = "e",
			Count = 9,
			IdentificationCode = "JK",
			AssociationOfAmericanRailroadsAARPoolCode = "5Dk0BC4",
			IndustryCode = "E",
		};

		var actual = Map.MapObject<BTC_BeginningSegmentForParameterTraceRegistration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dl", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.ParameterTraceRegistrationTypeCode = "n";
		subject.ParameterTraceTypeCode = "O";
		subject.OutputEventSelectionCode = "S";
		subject.ReferenceIdentification = "k";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredParameterTraceRegistrationTypeCode(string parameterTraceRegistrationTypeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "dl";
		subject.ParameterTraceTypeCode = "O";
		subject.OutputEventSelectionCode = "S";
		subject.ReferenceIdentification = "k";
		//Test Parameters
		subject.ParameterTraceRegistrationTypeCode = parameterTraceRegistrationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredParameterTraceTypeCode(string parameterTraceTypeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "dl";
		subject.ParameterTraceRegistrationTypeCode = "n";
		subject.OutputEventSelectionCode = "S";
		subject.ReferenceIdentification = "k";
		//Test Parameters
		subject.ParameterTraceTypeCode = parameterTraceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredOutputEventSelectionCode(string outputEventSelectionCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "dl";
		subject.ParameterTraceRegistrationTypeCode = "n";
		subject.ParameterTraceTypeCode = "O";
		subject.ReferenceIdentification = "k";
		//Test Parameters
		subject.OutputEventSelectionCode = outputEventSelectionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "dl";
		subject.ParameterTraceRegistrationTypeCode = "n";
		subject.ParameterTraceTypeCode = "O";
		subject.OutputEventSelectionCode = "S";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
