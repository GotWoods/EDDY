using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class F10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F10*x19j87pA*h*Z*Uk";

		var expected = new F10_IdentificationOfClaimTracer()
		{
			Date = "x19j87pA",
			ReferenceIdentification = "h",
			ReferenceIdentification2 = "Z",
			ReferenceIdentificationQualifier = "Uk",
		};

		var actual = Map.MapObject<F10_IdentificationOfClaimTracer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x19j87pA", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.ReferenceIdentification = "h";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "Z";
			subject.ReferenceIdentificationQualifier = "Uk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.Date = "x19j87pA";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "Z";
			subject.ReferenceIdentificationQualifier = "Uk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z", "Uk", true)]
	[InlineData("Z", "", false)]
	[InlineData("", "Uk", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.Date = "x19j87pA";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
