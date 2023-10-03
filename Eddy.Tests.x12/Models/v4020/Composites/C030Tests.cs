using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4020;
using Eddy.x12.Models.v4020.Composites;

namespace Eddy.x12.Tests.Models.v4020.Composites;

public class C030Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "1*8*8";

		var expected = new C030_PositionInSegment()
		{
			ElementPositionInSegment = 1,
			ComponentDataElementPositionInComposite = 8,
			RepeatingDataElementPosition = 8,
		};

		var actual = Map.MapObject<C030_PositionInSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredElementPositionInSegment(int elementPositionInSegment, bool isValidExpected)
	{
		var subject = new C030_PositionInSegment();
		//Required fields
		//Test Parameters
		if (elementPositionInSegment > 0) 
			subject.ElementPositionInSegment = elementPositionInSegment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
