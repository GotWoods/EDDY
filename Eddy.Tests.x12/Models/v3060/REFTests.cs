using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class REFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REF*RL*k*h*";

		var expected = new REF_ReferenceIdentification()
		{
			ReferenceIdentificationQualifier = "RL",
			ReferenceIdentification = "k",
			Description = "h",
			ReferenceIdentifier = null,
		};

		var actual = Map.MapObject<REF_ReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RL", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new REF_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
			subject.ReferenceIdentification = "k";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("k", "h", true)]
	[InlineData("k", "", true)]
	[InlineData("", "h", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string description, bool isValidExpected)
	{
		var subject = new REF_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = "RL";
		subject.ReferenceIdentification = referenceIdentification;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
