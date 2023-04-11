using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ORITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ORI*B";

		var expected = new ORI_ObjectReferenceIdentification()
		{
			AssociatedObjectReferenceIdentification = "B",
		};

		var actual = Map.MapObject<ORI_ObjectReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredAssociatedObjectReferenceIdentification(string associatedObjectReferenceIdentification, bool isValidExpected)
	{
		var subject = new ORI_ObjectReferenceIdentification();
		subject.AssociatedObjectReferenceIdentification = associatedObjectReferenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
