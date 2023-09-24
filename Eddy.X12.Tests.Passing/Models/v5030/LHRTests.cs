using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class LHRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LHR*HW*0*0BINaixI";

		var expected = new LHR_HazardousMaterialIdentifyingReferenceNumbers()
		{
			ReferenceIdentificationQualifier = "HW",
			ReferenceIdentification = "0",
			Date = "0BINaixI",
		};

		var actual = Map.MapObject<LHR_HazardousMaterialIdentifyingReferenceNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HW", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LHR_HazardousMaterialIdentifyingReferenceNumbers();
		subject.ReferenceIdentification = "0";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LHR_HazardousMaterialIdentifyingReferenceNumbers();
		subject.ReferenceIdentificationQualifier = "HW";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
