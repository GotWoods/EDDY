using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class TFSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TFS*Gn*k*Gq*2*V*h0*nGev9cOG*W";

		var expected = new TFS_TaxForm()
		{
			ReferenceIdentificationQualifier = "Gn",
			ReferenceIdentification = "k",
			ReferenceIdentificationQualifier2 = "Gq",
			ReferenceIdentification2 = "2",
			IdentificationCodeQualifier = "V",
			IdentificationCode = "h0",
			Date = "nGev9cOG",
			NameControlIdentifier = "W",
		};

		var actual = Map.MapObject<TFS_TaxForm>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gn", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceIdentification = "k";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Gq";
			subject.ReferenceIdentification2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "V";
			subject.IdentificationCode = "h0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceIdentificationQualifier = "Gn";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Gq";
			subject.ReferenceIdentification2 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "V";
			subject.IdentificationCode = "h0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Gq", "2", true)]
	[InlineData("Gq", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceIdentificationQualifier = "Gn";
		subject.ReferenceIdentification = "k";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "V";
			subject.IdentificationCode = "h0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "h0", true)]
	[InlineData("V", "", false)]
	[InlineData("", "h0", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceIdentificationQualifier = "Gn";
		subject.ReferenceIdentification = "k";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Gq";
			subject.ReferenceIdentification2 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
