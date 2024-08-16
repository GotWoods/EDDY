using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C280Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "2:j:p";

		var expected = new C280_Range()
		{
			MeasureUnitQualifier = "2",
			RangeMinimum = "j",
			RangeMaximum = "p",
		};

		var actual = Map.MapComposite<C280_Range>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredMeasureUnitQualifier(string measureUnitQualifier, bool isValidExpected)
	{
		var subject = new C280_Range();
		//Required fields
		//Test Parameters
		subject.MeasureUnitQualifier = measureUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
