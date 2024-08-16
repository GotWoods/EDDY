using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S011Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "g:O:O";

		var expected = new S011_DataElementIdentification()
		{
			ErroneousDataElementPositionInSegment = "g",
			ErroneousComponentDataElementPosition = "O",
			ErroneousDataElementOccurrence = "O",
		};

		var actual = Map.MapComposite<S011_DataElementIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredErroneousDataElementPositionInSegment(string erroneousDataElementPositionInSegment, bool isValidExpected)
	{
		var subject = new S011_DataElementIdentification();
		//Required fields
		//Test Parameters
		subject.ErroneousDataElementPositionInSegment = erroneousDataElementPositionInSegment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
