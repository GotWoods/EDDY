using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class EMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EMS*A*z1*udbP*yP*Md*B*B*zl*j*8V*3*s7*Z*kA*gu";

		var expected = new EMS_EmploymentPosition()
		{
			Description = "A",
			EmploymentClassCode = "z1",
			OccupationCode = "udbP",
			EmploymentStatusCode = "yP",
			ReferenceIdentificationQualifier = "Md",
			ReferenceIdentification = "B",
			ReferenceIdentification2 = "B",
			ReferenceIdentificationQualifier2 = "zl",
			IdentificationCodeQualifier = "j",
			IdentificationCode = "8V",
			PercentDecimalFormat = 3,
			EmploymentStatusCode2 = "s7",
			IdentificationCodeQualifier2 = "Z",
			IdentificationCode2 = "kA",
			EmploymentClassCode2 = "gu",
		};

		var actual = Map.MapObject<EMS_EmploymentPosition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Md", "B", true)]
	[InlineData("", "B", false)]
	[InlineData("Md", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new EMS_EmploymentPosition();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("B", "zl", true)]
	[InlineData("", "zl", false)]
	[InlineData("B", "", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string referenceIdentificationQualifier2, bool isValidExpected)
	{
		var subject = new EMS_EmploymentPosition();
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("j", "8V", true)]
	[InlineData("", "8V", false)]
	[InlineData("j", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new EMS_EmploymentPosition();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Z", "kA", true)]
	[InlineData("", "kA", false)]
	[InlineData("Z", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new EMS_EmploymentPosition();
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
