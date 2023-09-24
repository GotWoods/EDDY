using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class L11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L11*2*qd*9";

		var expected = new L11_BusinessInstructions()
		{
			ReferenceIdentification = "2",
			ReferenceIdentificationQualifier = "qd",
			Description = "9",
		};

		var actual = Map.MapObject<L11_BusinessInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "qd", true)]
	[InlineData("2", "", false)]
	[InlineData("", "qd", false)]
	public void Validation_AllAreRequiredReferenceIdentification(string referenceIdentification, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new L11_BusinessInstructions();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;

        if (subject.ReferenceIdentification == "")
            subject.Description = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("2", "9", true)]
	[InlineData("2", "", true)]
	[InlineData("", "9", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string description, bool isValidExpected)
	{
		var subject = new L11_BusinessInstructions();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.Description = description;

        if (subject.ReferenceIdentification != "")
            subject.ReferenceIdentificationQualifier = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
