using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class S010Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "i:o";

		var expected = new S010_StatusOfTheTransfer()
		{
			SequenceOfTransfers = "i",
			FirstAndLastTransfer = "o",
		};

		var actual = Map.MapComposite<S010_StatusOfTheTransfer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredSequenceOfTransfers(string sequenceOfTransfers, bool isValidExpected)
	{
		var subject = new S010_StatusOfTheTransfer();
		//Required fields
		//Test Parameters
		subject.SequenceOfTransfers = sequenceOfTransfers;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
