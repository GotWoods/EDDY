using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C526Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:K:6";

		var expected = new C526_FrequencyDetails()
		{
			FrequencyQualifier = "M",
			FrequencyValue = "K",
			MeasurementUnitCode = "6",
		};

		var actual = Map.MapComposite<C526_FrequencyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredFrequencyQualifier(string frequencyQualifier, bool isValidExpected)
	{
		var subject = new C526_FrequencyDetails();
		//Required fields
		//Test Parameters
		subject.FrequencyQualifier = frequencyQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
