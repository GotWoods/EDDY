using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C174Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "j:S:1:4:U";

		var expected = new C174_ValueRange()
		{
			MeasureUnitQualifier = "j",
			MeasurementValue = "S",
			RangeMinimum = "1",
			RangeMaximum = "4",
			SignificantDigits = "U",
		};

		var actual = Map.MapComposite<C174_ValueRange>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredMeasureUnitQualifier(string measureUnitQualifier, bool isValidExpected)
	{
		var subject = new C174_ValueRange();
		//Required fields
		//Test Parameters
		subject.MeasureUnitQualifier = measureUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
