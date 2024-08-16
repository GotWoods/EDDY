using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C526Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "H:H:P";

		var expected = new C526_FrequencyDetails()
		{
			FrequencyCodeQualifier = "H",
			FrequencyValue = "H",
			MeasurementUnitCode = "P",
		};

		var actual = Map.MapComposite<C526_FrequencyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredFrequencyCodeQualifier(string frequencyCodeQualifier, bool isValidExpected)
	{
		var subject = new C526_FrequencyDetails();
		//Required fields
		//Test Parameters
		subject.FrequencyCodeQualifier = frequencyCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
