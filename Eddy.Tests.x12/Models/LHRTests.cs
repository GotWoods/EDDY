using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LHRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LHR*N6*g*U8Qwa4mi";

		var expected = new LHR_HazardousMaterialIdentifyingReferenceNumbers()
		{
			ReferenceIdentificationQualifier = "N6",
			ReferenceIdentification = "g",
			Date = "U8Qwa4mi",
		};

		var actual = Map.MapObject<LHR_HazardousMaterialIdentifyingReferenceNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N6", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LHR_HazardousMaterialIdentifyingReferenceNumbers();
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LHR_HazardousMaterialIdentifyingReferenceNumbers();
		subject.ReferenceIdentificationQualifier = "N6";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
