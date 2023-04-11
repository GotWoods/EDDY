using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DDI*P";

		var expected = new DDI_Explanation()
		{
			Description = "P",
		};

		var actual = Map.MapObject<DDI_Explanation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validatation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new DDI_Explanation();
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
