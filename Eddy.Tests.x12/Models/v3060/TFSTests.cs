using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TFSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TFS*ks*J*zm*I*E*FC*mL2lXy*7KkZ";

		var expected = new TFS_TaxForm()
		{
			ReferenceIdentificationQualifier = "ks",
			ReferenceIdentification = "J",
			ReferenceIdentificationQualifier2 = "zm",
			ReferenceIdentification2 = "I",
			IdentificationCodeQualifier = "E",
			IdentificationCode = "FC",
			Date = "mL2lXy",
			NameControlIdentifier = "7KkZ",
		};

		var actual = Map.MapObject<TFS_TaxForm>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ks", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceIdentification = "J";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "zm";
			subject.ReferenceIdentification2 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "E";
			subject.IdentificationCode = "FC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceIdentificationQualifier = "ks";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "zm";
			subject.ReferenceIdentification2 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "E";
			subject.IdentificationCode = "FC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zm", "I", true)]
	[InlineData("zm", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceIdentificationQualifier = "ks";
		subject.ReferenceIdentification = "J";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "E";
			subject.IdentificationCode = "FC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "FC", true)]
	[InlineData("E", "", false)]
	[InlineData("", "FC", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceIdentificationQualifier = "ks";
		subject.ReferenceIdentification = "J";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "zm";
			subject.ReferenceIdentification2 = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
