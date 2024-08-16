using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A.Composites;

public class C270Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "1:p:Z";

		var expected = new C270_Control()
		{
			ControlTotalTypeCodeQualifier = "1",
			ControlTotalQuantity = "p",
			MeasurementUnitCode = "Z",
		};

		var actual = Map.MapComposite<C270_Control>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredControlTotalTypeCodeQualifier(string controlTotalTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C270_Control();
		//Required fields
		subject.ControlTotalQuantity = "p";
		//Test Parameters
		subject.ControlTotalTypeCodeQualifier = controlTotalTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredControlTotalQuantity(string controlTotalQuantity, bool isValidExpected)
	{
		var subject = new C270_Control();
		//Required fields
		subject.ControlTotalTypeCodeQualifier = "1";
		//Test Parameters
		subject.ControlTotalQuantity = controlTotalQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
