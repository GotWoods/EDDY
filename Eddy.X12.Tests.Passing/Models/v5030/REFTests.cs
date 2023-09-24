using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class REFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REF*S1*Y*s*";

		var expected = new REF_ReferenceInformation()
		{
			ReferenceIdentificationQualifier = "S1",
			ReferenceIdentification = "Y",
			Description = "s",
			ReferenceIdentifier = null,
		};

		var actual = Map.MapObject<REF_ReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S1", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new REF_ReferenceInformation();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
			subject.ReferenceIdentification = "Y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Y", "s", true)]
	[InlineData("Y", "", true)]
	[InlineData("", "s", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string description, bool isValidExpected)
	{
		var subject = new REF_ReferenceInformation();
		subject.ReferenceIdentificationQualifier = "S1";
		subject.ReferenceIdentification = referenceIdentification;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
