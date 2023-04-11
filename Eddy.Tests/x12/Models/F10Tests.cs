using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class F10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F10*QwhG4l7t*I*z*Sp";

		var expected = new F10_IdentificationOfClaimTracer()
		{
			Date = "QwhG4l7t",
			ReferenceIdentification = "I",
			ReferenceIdentification2 = "z",
			ReferenceIdentificationQualifier = "Sp",
		};

		var actual = Map.MapObject<F10_IdentificationOfClaimTracer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QwhG4l7t", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.ReferenceIdentification = "I";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.Date = "QwhG4l7t";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("z", "Sp", true)]
	[InlineData("", "Sp", false)]
	[InlineData("z", "", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.Date = "QwhG4l7t";
		subject.ReferenceIdentification = "I";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
