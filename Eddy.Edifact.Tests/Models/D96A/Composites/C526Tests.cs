using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C526Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:n:G";

		var expected = new C526_FrequencyDetails()
		{
			FrequencyQualifier = "M",
			FrequencyValue = "n",
			MeasureUnitQualifier = "G",
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
