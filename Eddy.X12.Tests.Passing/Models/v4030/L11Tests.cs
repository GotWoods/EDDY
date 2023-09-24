using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class L11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L11*F*JL*m*tcCThJmg";

		var expected = new L11_BusinessInstructionsAndReferenceNumber()
		{
			ReferenceIdentification = "F",
			ReferenceIdentificationQualifier = "JL",
			Description = "m",
			Date = "tcCThJmg",
		};

		var actual = Map.MapObject<L11_BusinessInstructionsAndReferenceNumber>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F", "JL", true)]
	[InlineData("F", "", false)]
	[InlineData("", "JL", false)]
	public void Validation_AllAreRequiredReferenceIdentification(string referenceIdentification, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new L11_BusinessInstructionsAndReferenceNumber();
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
	[InlineData("F", "m", true)]
	[InlineData("F", "", true)]
	[InlineData("", "m", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string description, bool isValidExpected)
	{
		var subject = new L11_BusinessInstructionsAndReferenceNumber();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.Description = description;

        if (subject.ReferenceIdentification != "")
            subject.ReferenceIdentificationQualifier = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
