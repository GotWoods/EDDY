using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S021Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:3:v:U";

		var expected = new S021_ObjectTypeIdentification()
		{
			ObjectTypeQualifier = "k",
			ObjectTypeAttributeIdentification = "3",
			ObjectTypeAttribute = "v",
			ControllingAgencyCoded = "U",
		};

		var actual = Map.MapComposite<S021_ObjectTypeIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredObjectTypeQualifier(string objectTypeQualifier, bool isValidExpected)
	{
		var subject = new S021_ObjectTypeIdentification();
		//Required fields
		//Test Parameters
		subject.ObjectTypeQualifier = objectTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
