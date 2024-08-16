using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S016Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "9:Q:a:l";

		var expected = new S016_MessageSubsetIdentification()
		{
			MessageSubsetIdentification = "9",
			MessageSubsetVersionNumber = "Q",
			MessageSubsetReleaseNumber = "a",
			ControllingAgencyCoded = "l",
		};

		var actual = Map.MapComposite<S016_MessageSubsetIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredMessageSubsetIdentification(string messageSubsetIdentification, bool isValidExpected)
	{
		var subject = new S016_MessageSubsetIdentification();
		//Required fields
		//Test Parameters
		subject.MessageSubsetIdentification = messageSubsetIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
