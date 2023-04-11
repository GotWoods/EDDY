using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FGS*8*lb*U";

		var expected = new FGS_FormGroup()
		{
			AssignedIdentification = "8",
			ReferenceIdentificationQualifier = "lb",
			ReferenceIdentification = "U",
		};

		var actual = Map.MapObject<FGS_FormGroup>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new FGS_FormGroup();
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("lb", "U", true)]
	[InlineData("", "U", false)]
	[InlineData("lb", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new FGS_FormGroup();
		subject.AssignedIdentification = "8";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
