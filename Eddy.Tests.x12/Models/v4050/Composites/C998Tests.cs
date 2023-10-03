using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4050;
using Eddy.x12.Models.v4050.Composites;

namespace Eddy.x12.Tests.Models.v4050.Composites;

public class C998Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "t*c";

		var expected = new C998_ContextIdentification()
		{
			ContextName = "t",
			ContextReference = "c",
		};

		var actual = Map.MapObject<C998_ContextIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredContextName(string contextName, bool isValidExpected)
	{
		var subject = new C998_ContextIdentification();
		//Required fields
		//Test Parameters
		subject.ContextName = contextName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
