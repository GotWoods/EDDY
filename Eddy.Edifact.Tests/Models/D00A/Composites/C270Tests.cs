using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C270Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:N:S";

		var expected = new C270_Control()
		{
			ControlTotalTypeCodeQualifier = "u",
			ControlTotalValue = "N",
			MeasurementUnitCode = "S",
		};

		var actual = Map.MapComposite<C270_Control>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredControlTotalTypeCodeQualifier(string controlTotalTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C270_Control();
		//Required fields
		subject.ControlTotalValue = "N";
		//Test Parameters
		subject.ControlTotalTypeCodeQualifier = controlTotalTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredControlTotalValue(string controlTotalValue, bool isValidExpected)
	{
		var subject = new C270_Control();
		//Required fields
		subject.ControlTotalTypeCodeQualifier = "u";
		//Test Parameters
		subject.ControlTotalValue = controlTotalValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
