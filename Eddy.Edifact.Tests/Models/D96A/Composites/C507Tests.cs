using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C507Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "4:v:q";

		var expected = new C507_DateTimePeriod()
		{
			DateTimePeriodQualifier = "4",
			DateTimePeriod = "v",
			DateTimePeriodFormatQualifier = "q",
		};

		var actual = Map.MapComposite<C507_DateTimePeriod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredDateTimePeriodQualifier(string dateTimePeriodQualifier, bool isValidExpected)
	{
		var subject = new C507_DateTimePeriod();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodQualifier = dateTimePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
