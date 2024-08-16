using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C850Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:Z";

		var expected = new C850_StatusOfInstruction()
		{
			StatusCoded = "M",
			PartyName = "Z",
		};

		var actual = Map.MapComposite<C850_StatusOfInstruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredStatusCoded(string statusCoded, bool isValidExpected)
	{
		var subject = new C850_StatusOfInstruction();
		//Required fields
		//Test Parameters
		subject.StatusCoded = statusCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
