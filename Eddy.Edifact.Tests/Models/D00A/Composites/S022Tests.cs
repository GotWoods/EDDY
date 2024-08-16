using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S022Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "r:G:T:O";

		var expected = new S022_StatusOfTheObject()
		{
			LengthOfObjectInOctetsOfBits = "r",
			NumberOfSegmentsBeforeObject = "G",
			SequenceOfTransfers = "T",
			FirstAndLastTransfer = "O",
		};

		var actual = Map.MapComposite<S022_StatusOfTheObject>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredLengthOfObjectInOctetsOfBits(string lengthOfObjectInOctetsOfBits, bool isValidExpected)
	{
		var subject = new S022_StatusOfTheObject();
		//Required fields
		//Test Parameters
		subject.LengthOfObjectInOctetsOfBits = lengthOfObjectInOctetsOfBits;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
