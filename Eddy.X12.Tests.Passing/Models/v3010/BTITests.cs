using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTI*Do*C*n*vr*ieeL8U";

		var expected = new BTI_BeginningTaxInformation()
		{
			ReferenceNumberQualifier = "Do",
			ReferenceNumber = "C",
			IdentificationCodeQualifier = "n",
			IdentificationCode = "vr",
			Date = "ieeL8U",
		};

		var actual = Map.MapObject<BTI_BeginningTaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Do", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceNumber = "C";
		subject.IdentificationCodeQualifier = "n";
		subject.IdentificationCode = "vr";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceNumberQualifier = "Do";
		subject.IdentificationCodeQualifier = "n";
		subject.IdentificationCode = "vr";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceNumberQualifier = "Do";
		subject.ReferenceNumber = "C";
		subject.IdentificationCode = "vr";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vr", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BTI_BeginningTaxInformation();
		subject.ReferenceNumberQualifier = "Do";
		subject.ReferenceNumber = "C";
		subject.IdentificationCodeQualifier = "n";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
