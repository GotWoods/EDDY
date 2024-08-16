using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PRC+";

		var expected = new PRC_ProcessIdentification()
		{
			ProcessTypeAndDescription = null,
		};

		var actual = Map.MapObject<PRC_ProcessIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredProcessTypeAndDescription(string processTypeAndDescription, bool isValidExpected)
	{
		var subject = new PRC_ProcessIdentification();
		//Required fields
		//Test Parameters
		if (processTypeAndDescription != "") 
			subject.ProcessTypeAndDescription = new C242_ProcessTypeAndDescription();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
