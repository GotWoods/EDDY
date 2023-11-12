using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v8030;
using Eddy.x12.Models.v8030.Composites;

namespace Eddy.x12.Tests.Models.v8030.Composites;

public class C030Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "8*9*6";

		var expected = new C030_PositionInSegment()
		{
			DataElementPositionInSegment = 8,
			ComponentDataElementPositionInComposite = 9,
			RepeatingDataElementPosition = 6,
		};

		var actual = Map.MapObject<C030_PositionInSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredDataElementPositionInSegment(int dataElementPositionInSegment, bool isValidExpected)
	{
		var subject = new C030_PositionInSegment();
		//Required fields
		//Test Parameters
		if (dataElementPositionInSegment > 0) 
			subject.DataElementPositionInSegment = dataElementPositionInSegment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
