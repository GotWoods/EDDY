using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class C526Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "z:y:L";

		var expected = new C526_FrequencyDetails()
		{
			FrequencyCodeQualifier = "z",
			FrequencyRate = "y",
			MeasurementUnitCode = "L",
		};

		var actual = Map.MapComposite<C526_FrequencyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredFrequencyCodeQualifier(string frequencyCodeQualifier, bool isValidExpected)
	{
		var subject = new C526_FrequencyDetails();
		//Required fields
		//Test Parameters
		subject.FrequencyCodeQualifier = frequencyCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
