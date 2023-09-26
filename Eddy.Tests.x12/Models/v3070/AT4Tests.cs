using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AT4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT4*C";

		var expected = new AT4_BillOfLadingDescription()
		{
			LadingDescription = "C",
		};

		var actual = Map.MapObject<AT4_BillOfLadingDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredLadingDescription(string ladingDescription, bool isValidExpected)
	{
		var subject = new AT4_BillOfLadingDescription();
		//Required fields
		//Test Parameters
		subject.LadingDescription = ladingDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
