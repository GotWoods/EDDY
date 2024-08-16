using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class FRQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FRQ+";

		var expected = new FRQ_Frequency()
		{
			Frequency = null,
		};

		var actual = Map.MapObject<FRQ_Frequency>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredFrequency(string frequency, bool isValidExpected)
	{
		var subject = new FRQ_Frequency();
		//Required fields
		//Test Parameters
		if (frequency != "") 
			subject.Frequency = new E520_Frequency();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
