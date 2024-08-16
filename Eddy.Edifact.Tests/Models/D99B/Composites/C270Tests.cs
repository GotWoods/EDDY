using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C270Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "8:9:7";

		var expected = new C270_Control()
		{
			ControlTotalTypeCodeQualifier = "8",
			ControlValue = "9",
			MeasurementUnitCode = "7",
		};

		var actual = Map.MapComposite<C270_Control>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredControlTotalTypeCodeQualifier(string controlTotalTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C270_Control();
		//Required fields
		subject.ControlValue = "9";
		//Test Parameters
		subject.ControlTotalTypeCodeQualifier = controlTotalTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredControlValue(string controlValue, bool isValidExpected)
	{
		var subject = new C270_Control();
		//Required fields
		subject.ControlTotalTypeCodeQualifier = "8";
		//Test Parameters
		subject.ControlValue = controlValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
