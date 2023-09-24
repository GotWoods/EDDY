using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TFSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TFS*pF*U*3h*E*b*Lg*VVI9ZV*fjak";

		var expected = new TFS_TaxForm()
		{
			ReferenceNumberQualifier = "pF",
			ReferenceNumber = "U",
			ReferenceNumberQualifier2 = "3h",
			ReferenceNumber2 = "E",
			IdentificationCodeQualifier = "b",
			IdentificationCode = "Lg",
			Date = "VVI9ZV",
			NameControlIdentifier = "fjak",
		};

		var actual = Map.MapObject<TFS_TaxForm>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pF", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceNumber = "U";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "3h";
			subject.ReferenceNumber2 = "E";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "b";
			subject.IdentificationCode = "Lg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceNumberQualifier = "pF";
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "3h";
			subject.ReferenceNumber2 = "E";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "b";
			subject.IdentificationCode = "Lg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3h", "E", true)]
	[InlineData("3h", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceNumberQualifier = "pF";
		subject.ReferenceNumber = "U";
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "b";
			subject.IdentificationCode = "Lg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b", "Lg", true)]
	[InlineData("b", "", false)]
	[InlineData("", "Lg", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceNumberQualifier = "pF";
		subject.ReferenceNumber = "U";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "3h";
			subject.ReferenceNumber2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
