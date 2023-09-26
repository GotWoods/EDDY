using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class RSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RSC*F*e*dY*0";

		var expected = new RSC_Resource()
		{
			ResourceCodeOrIdentifier = "F",
			Description = "e",
			ResourceTypeCode = "dY",
			ActionCode = "0",
		};

		var actual = Map.MapObject<RSC_Resource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredResourceCodeOrIdentifier(string resourceCodeOrIdentifier, bool isValidExpected)
	{
		var subject = new RSC_Resource();
		//Required fields
		//Test Parameters
		subject.ResourceCodeOrIdentifier = resourceCodeOrIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
