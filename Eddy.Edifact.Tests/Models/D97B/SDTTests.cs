using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class SDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SDT+";

		var expected = new SDT_SelectionDetails()
		{
			SelectionDetailsInformation = null,
		};

		var actual = Map.MapObject<SDT_SelectionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredSelectionDetailsInformation(string selectionDetailsInformation, bool isValidExpected)
	{
		var subject = new SDT_SelectionDetails();
		//Required fields
		//Test Parameters
		if (selectionDetailsInformation != "") 
			subject.SelectionDetailsInformation = new E010_SelectionDetailsInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
