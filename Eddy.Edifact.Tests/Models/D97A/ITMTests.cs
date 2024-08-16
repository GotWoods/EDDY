using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class ITMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ITM+";

		var expected = new ITM_ItemNumber()
		{
			ItemNumberIdentification = null,
		};

		var actual = Map.MapObject<ITM_ItemNumber>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredItemNumberIdentification(string itemNumberIdentification, bool isValidExpected)
	{
		var subject = new ITM_ItemNumber();
		//Required fields
		//Test Parameters
		if (itemNumberIdentification != "") 
			subject.ItemNumberIdentification = new E212_ItemNumberIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
