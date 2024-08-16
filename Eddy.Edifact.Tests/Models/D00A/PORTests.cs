using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PORTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "POR++++G+C";

		var expected = new POR_LocationAndOrRelatedTimeInformation()
		{
			LocationIdentification = null,
			RelatedTimeInformation = null,
			Position = null,
			LocationFunctionCodeQualifier = "G",
			SequencePositionIdentifier = "C",
		};

		var actual = Map.MapObject<POR_LocationAndOrRelatedTimeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredLocationIdentification(string locationIdentification, bool isValidExpected)
	{
		var subject = new POR_LocationAndOrRelatedTimeInformation();
		//Required fields
		//Test Parameters
		if (locationIdentification != "") 
			subject.LocationIdentification = new E517_LocationIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
