using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class REFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REF*nc*o*O*";

		var expected = new REF_ReferenceIdentification()
		{
			ReferenceIdentificationQualifier = "nc",
			ReferenceIdentification = "o",
			Description = "O",
			ReferenceIdentifier = null,
		};

		var actual = Map.MapObject<REF_ReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nc", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new REF_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
			subject.ReferenceIdentification = "o";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("o", "O", true)]
	[InlineData("o", "", true)]
	[InlineData("", "O", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string description, bool isValidExpected)
	{
		var subject = new REF_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = "nc";
		subject.ReferenceIdentification = referenceIdentification;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
