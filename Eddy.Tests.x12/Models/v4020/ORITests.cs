using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class ORITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ORI*i";

		var expected = new ORI_AssociatedObjectReferenceIdentification()
		{
			AssociatedObjectReferenceIdentification = "i",
		};

		var actual = Map.MapObject<ORI_AssociatedObjectReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredAssociatedObjectReferenceIdentification(string associatedObjectReferenceIdentification, bool isValidExpected)
	{
		var subject = new ORI_AssociatedObjectReferenceIdentification();
		//Required fields
		//Test Parameters
		subject.AssociatedObjectReferenceIdentification = associatedObjectReferenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
