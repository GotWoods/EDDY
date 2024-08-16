using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class GISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GIS+";

		var expected = new GIS_GeneralIndicator()
		{
			ProcessingIndicator = null,
		};

		var actual = Map.MapObject<GIS_GeneralIndicator>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredProcessingIndicator(string processingIndicator, bool isValidExpected)
	{
		var subject = new GIS_GeneralIndicator();
		//Required fields
		//Test Parameters
		if (processingIndicator != "") 
			subject.ProcessingIndicator = new C529_ProcessingIndicator();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
