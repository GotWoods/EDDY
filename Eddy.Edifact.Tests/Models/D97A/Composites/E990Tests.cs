using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E990Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "r:H:D:o:p:m:R:f:i";

		var expected = new E990_SequenceNumberDetails()
		{
			SequenceNumber = "r",
			SequenceNumber2 = "H",
			SequenceNumber3 = "D",
			SequenceNumber4 = "o",
			SequenceNumber5 = "p",
			SequenceNumber6 = "m",
			SequenceNumber7 = "R",
			SequenceNumber8 = "f",
			SequenceNumber9 = "i",
		};

		var actual = Map.MapComposite<E990_SequenceNumberDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredSequenceNumber(string sequenceNumber, bool isValidExpected)
	{
		var subject = new E990_SequenceNumberDetails();
		//Required fields
		//Test Parameters
		subject.SequenceNumber = sequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
