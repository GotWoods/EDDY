using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BTCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTC*xq*4*3*H*j*U*a*5*3*id*Yknu5sQ*V";

		var expected = new BTC_BeginningSegmentForParameterTraceRegistration()
		{
			TransactionSetPurposeCode = "xq",
			ParameterTraceRegistrationTypeCode = "4",
			ParameterTraceTypeCode = "3",
			OutputEventSelectionCode = "H",
			ReferenceIdentification = "j",
			YesNoConditionOrResponseCode = "U",
			YesNoConditionOrResponseCode2 = "a",
			YesNoConditionOrResponseCode3 = "5",
			Count = 3,
			IdentificationCode = "id",
			AssociationOfAmericanRailroadsAARPoolCode = "Yknu5sQ",
			IndustryCode = "V",
		};

		var actual = Map.MapObject<BTC_BeginningSegmentForParameterTraceRegistration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xq", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.ParameterTraceRegistrationTypeCode = "4";
		subject.ParameterTraceTypeCode = "3";
		subject.OutputEventSelectionCode = "H";
		subject.ReferenceIdentification = "j";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredParameterTraceRegistrationTypeCode(string parameterTraceRegistrationTypeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "xq";
		subject.ParameterTraceTypeCode = "3";
		subject.OutputEventSelectionCode = "H";
		subject.ReferenceIdentification = "j";
		//Test Parameters
		subject.ParameterTraceRegistrationTypeCode = parameterTraceRegistrationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredParameterTraceTypeCode(string parameterTraceTypeCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "xq";
		subject.ParameterTraceRegistrationTypeCode = "4";
		subject.OutputEventSelectionCode = "H";
		subject.ReferenceIdentification = "j";
		//Test Parameters
		subject.ParameterTraceTypeCode = parameterTraceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredOutputEventSelectionCode(string outputEventSelectionCode, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "xq";
		subject.ParameterTraceRegistrationTypeCode = "4";
		subject.ParameterTraceTypeCode = "3";
		subject.ReferenceIdentification = "j";
		//Test Parameters
		subject.OutputEventSelectionCode = outputEventSelectionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTC_BeginningSegmentForParameterTraceRegistration();
		//Required fields
		subject.TransactionSetPurposeCode = "xq";
		subject.ParameterTraceRegistrationTypeCode = "4";
		subject.ParameterTraceTypeCode = "3";
		subject.OutputEventSelectionCode = "H";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
