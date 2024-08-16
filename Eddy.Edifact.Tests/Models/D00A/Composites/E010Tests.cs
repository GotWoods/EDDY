using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E010Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "I:q";

		var expected = new E010_SelectionDetailsInformation()
		{
			OptionCode = "I",
			RelatedInformationDescription = "q",
		};

		var actual = Map.MapComposite<E010_SelectionDetailsInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredOptionCode(string optionCode, bool isValidExpected)
	{
		var subject = new E010_SelectionDetailsInformation();
		//Required fields
		//Test Parameters
		subject.OptionCode = optionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
