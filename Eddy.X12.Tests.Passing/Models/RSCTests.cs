using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RSC*o*z*jg*O";

		var expected = new RSC_Resource()
		{
			ResourceCodeOrIdentifier = "o",
			Description = "z",
			ResourceTypeCode = "jg",
			ActionCode = "O",
		};

		var actual = Map.MapObject<RSC_Resource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredResourceCodeOrIdentifier(string resourceCodeOrIdentifier, bool isValidExpected)
	{
		var subject = new RSC_Resource();
		subject.ResourceCodeOrIdentifier = resourceCodeOrIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
