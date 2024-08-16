using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class E010Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "M:Z";

		var expected = new E010_SelectionDetailsInformation()
		{
			OptionCoded = "M",
			AssociatedOptionInformation = "Z",
		};

		var actual = Map.MapComposite<E010_SelectionDetailsInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredOptionCoded(string optionCoded, bool isValidExpected)
	{
		var subject = new E010_SelectionDetailsInformation();
		//Required fields
		//Test Parameters
		subject.OptionCoded = optionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
