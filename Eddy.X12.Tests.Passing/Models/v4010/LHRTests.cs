using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LHRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LHR*oW*A*rgMuC4QY";

		var expected = new LHR_HazardousMaterialIdentifyingReferenceNumbers()
		{
			ReferenceIdentificationQualifier = "oW",
			ReferenceIdentification = "A",
			Date = "rgMuC4QY",
		};

		var actual = Map.MapObject<LHR_HazardousMaterialIdentifyingReferenceNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oW", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LHR_HazardousMaterialIdentifyingReferenceNumbers();
		subject.ReferenceIdentification = "A";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LHR_HazardousMaterialIdentifyingReferenceNumbers();
		subject.ReferenceIdentificationQualifier = "oW";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
