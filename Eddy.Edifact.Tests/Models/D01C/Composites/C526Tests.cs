using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class C526Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:T:K";

		var expected = new C526_FrequencyDetails()
		{
			FrequencyCodeQualifier = "9",
			FrequencyRate = "T",
			MeasurementUnitCode = "K",
		};

		var actual = Map.MapComposite<C526_FrequencyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredFrequencyCodeQualifier(string frequencyCodeQualifier, bool isValidExpected)
	{
		var subject = new C526_FrequencyDetails();
		//Required fields
		//Test Parameters
		subject.FrequencyCodeQualifier = frequencyCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
