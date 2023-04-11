using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTI*WF*d*j*BZ*r7HzrWtK*V*q*pu*S*UO*p*Gc*Jn*aj";

		var expected = new BTI_BeginningTaxInformation()
		{
			ReferenceIdentificationQualifier = "WF",
			ReferenceIdentification = "d",
			IdentificationCodeQualifier = "j",
			IdentificationCode = "BZ",
			Date = "r7HzrWtK",
			NameControlIdentifier = "V",
			IdentificationCodeQualifier2 = "q",
			IdentificationCode2 = "pu",
			IdentificationCodeQualifier3 = "S",
			IdentificationCode3 = "UO",
			IdentificationCodeQualifier4 = "p",
			IdentificationCode4 = "Gc",
			TransactionSetPurposeCode = "Jn",
			TransactionTypeCode = "aj",
		};

		var actual = Map.MapObject<BTI_BeginningTaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WF", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentification = "d";
		subject.IdentificationCodeQualifier = "j";
		subject.IdentificationCode = "BZ";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "WF";
		subject.IdentificationCodeQualifier = "j";
		subject.IdentificationCode = "BZ";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "WF";
		subject.ReferenceIdentification = "d";
		subject.IdentificationCode = "BZ";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BZ", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "WF";
		subject.ReferenceIdentification = "d";
		subject.IdentificationCodeQualifier = "j";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("q", "pu", true)]
	[InlineData("", "pu", false)]
	[InlineData("q", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "WF";
		subject.ReferenceIdentification = "d";
		subject.IdentificationCodeQualifier = "j";
		subject.IdentificationCode = "BZ";
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("S", "UO", true)]
	[InlineData("", "UO", false)]
	[InlineData("S", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier3(string identificationCodeQualifier3, string identificationCode3, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "WF";
		subject.ReferenceIdentification = "d";
		subject.IdentificationCodeQualifier = "j";
		subject.IdentificationCode = "BZ";
		subject.IdentificationCodeQualifier3 = identificationCodeQualifier3;
		subject.IdentificationCode3 = identificationCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("p", "Gc", true)]
	[InlineData("", "Gc", false)]
	[InlineData("p", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier4(string identificationCodeQualifier4, string identificationCode4, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceIdentificationQualifier = "WF";
		subject.ReferenceIdentification = "d";
		subject.IdentificationCodeQualifier = "j";
		subject.IdentificationCode = "BZ";
		subject.IdentificationCodeQualifier4 = identificationCodeQualifier4;
		subject.IdentificationCode4 = identificationCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
