using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class F10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F10*JtswMKky*Y*E*Ci";

		var expected = new F10_IdentificationOfClaimTracer()
		{
			Date = "JtswMKky",
			ReferenceIdentification = "Y",
			ReferenceIdentification2 = "E",
			ReferenceIdentificationQualifier = "Ci",
		};

		var actual = Map.MapObject<F10_IdentificationOfClaimTracer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JtswMKky", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.ReferenceIdentification = "Y";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "E";
			subject.ReferenceIdentificationQualifier = "Ci";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.Date = "JtswMKky";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "E";
			subject.ReferenceIdentificationQualifier = "Ci";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "Ci", true)]
	[InlineData("E", "", false)]
	[InlineData("", "Ci", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.Date = "JtswMKky";
		subject.ReferenceIdentification = "Y";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
