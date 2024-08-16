using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C270Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "h:e:2";

		var expected = new C270_Control()
		{
			ControlQualifier = "h",
			ControlValue = "e",
			MeasureUnitQualifier = "2",
		};

		var actual = Map.MapComposite<C270_Control>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredControlQualifier(string controlQualifier, bool isValidExpected)
	{
		var subject = new C270_Control();
		//Required fields
		subject.ControlValue = "e";
		//Test Parameters
		subject.ControlQualifier = controlQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredControlValue(string controlValue, bool isValidExpected)
	{
		var subject = new C270_Control();
		//Required fields
		subject.ControlQualifier = "h";
		//Test Parameters
		subject.ControlValue = controlValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
