using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4050;
using Eddy.x12.Models.v4050.Composites;

namespace Eddy.x12.Tests.Models.v4050.Composites;

public class C999Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "6*2";

		var expected = new C999_ReferenceInSegment()
		{
			DataElementReferenceNumber = 6,
			DataElementReferenceNumber2 = 2,
		};

		var actual = Map.MapObject<C999_ReferenceInSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredDataElementReferenceNumber(int dataElementReferenceNumber, bool isValidExpected)
	{
		var subject = new C999_ReferenceInSegment();
		//Required fields
		//Test Parameters
		if (dataElementReferenceNumber > 0) 
			subject.DataElementReferenceNumber = dataElementReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
