using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class S011Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "v:v";

		var expected = new S011_DataElementIdentification()
		{
			ErroneousDataElementPositionInSegment = "v",
			ErroneousComponentDataElementPosition = "v",
		};

		var actual = Map.MapComposite<S011_DataElementIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredErroneousDataElementPositionInSegment(string erroneousDataElementPositionInSegment, bool isValidExpected)
	{
		var subject = new S011_DataElementIdentification();
		//Required fields
		//Test Parameters
		subject.ErroneousDataElementPositionInSegment = erroneousDataElementPositionInSegment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
