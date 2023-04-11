using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G73Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G73*D";

		var expected = new G73_AllowanceOrChargeDescription()
		{
			FreeFormDescription = "D",
		};

		var actual = Map.MapObject<G73_AllowanceOrChargeDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredFreeFormDescription(string freeFormDescription, bool isValidExpected)
	{
		var subject = new G73_AllowanceOrChargeDescription();
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
