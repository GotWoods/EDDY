using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class C270Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "o:C:s";

		var expected = new C270_Control()
		{
			ControlTotalTypeCodeQualifier = "o",
			ControlTotalQuantity = "C",
			MeasurementUnitCode = "s",
		};

		var actual = Map.MapComposite<C270_Control>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredControlTotalTypeCodeQualifier(string controlTotalTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C270_Control();
		//Required fields
		subject.ControlTotalQuantity = "C";
		//Test Parameters
		subject.ControlTotalTypeCodeQualifier = controlTotalTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredControlTotalQuantity(string controlTotalQuantity, bool isValidExpected)
	{
		var subject = new C270_Control();
		//Required fields
		subject.ControlTotalTypeCodeQualifier = "o";
		//Test Parameters
		subject.ControlTotalQuantity = controlTotalQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
