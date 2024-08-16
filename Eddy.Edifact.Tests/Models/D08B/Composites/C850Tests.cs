using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class C850Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "5:p";

		var expected = new C850_StatusOfInstruction()
		{
			StatusDescriptionCode = "5",
			PartyName = "p",
		};

		var actual = Map.MapComposite<C850_StatusOfInstruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredStatusDescriptionCode(string statusDescriptionCode, bool isValidExpected)
	{
		var subject = new C850_StatusOfInstruction();
		//Required fields
		//Test Parameters
		subject.StatusDescriptionCode = statusDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
