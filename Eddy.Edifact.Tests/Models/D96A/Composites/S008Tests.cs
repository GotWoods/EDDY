using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class S008Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "4:o:n";

		var expected = new S008_MessageVersion()
		{
			MessageVersionNumber = "4",
			MessageReleaseNumber = "o",
			AssociationAssignedCode = "n",
		};

		var actual = Map.MapComposite<S008_MessageVersion>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredMessageVersionNumber(string messageVersionNumber, bool isValidExpected)
	{
		var subject = new S008_MessageVersion();
		//Required fields
		subject.MessageReleaseNumber = "o";
		//Test Parameters
		subject.MessageVersionNumber = messageVersionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredMessageReleaseNumber(string messageReleaseNumber, bool isValidExpected)
	{
		var subject = new S008_MessageVersion();
		//Required fields
		subject.MessageVersionNumber = "4";
		//Test Parameters
		subject.MessageReleaseNumber = messageReleaseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
