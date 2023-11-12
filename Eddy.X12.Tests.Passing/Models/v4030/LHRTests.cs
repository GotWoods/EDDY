using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LHRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LHR*L0*P*B9ZgJTwd";

		var expected = new LHR_HazardousMaterialIdentifyingReferenceNumbers()
		{
			ReferenceIdentificationQualifier = "L0",
			ReferenceIdentification = "P",
			Date = "B9ZgJTwd",
		};

		var actual = Map.MapObject<LHR_HazardousMaterialIdentifyingReferenceNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L0", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LHR_HazardousMaterialIdentifyingReferenceNumbers();
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LHR_HazardousMaterialIdentifyingReferenceNumbers();
		subject.ReferenceIdentificationQualifier = "L0";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
