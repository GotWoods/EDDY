using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class IK4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IK4**H*U*H";

		var expected = new IK4_ImplementationDataElementNote()
		{
			PositionInSegment = null,
			DataElementReferenceCode = "H",
			ImplementationDataElementSyntaxErrorCode = "U",
			CopyOfBadDataElement = "H",
		};

		var actual = Map.MapObject<IK4_ImplementationDataElementNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredPositionInSegment(int positionInSegment, bool isValidExpected)
	{
		var subject = new IK4_ImplementationDataElementNote();
		subject.ImplementationDataElementSyntaxErrorCode = "U";
		if (positionInSegment > 0)
		subject.PositionInSegment = new C030_PositionInSegment() { RepeatingDataElementPosition = 1 };
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredImplementationDataElementSyntaxErrorCode(string implementationDataElementSyntaxErrorCode, bool isValidExpected)
	{
		var subject = new IK4_ImplementationDataElementNote();
		subject.PositionInSegment = new C030_PositionInSegment();
		subject.ImplementationDataElementSyntaxErrorCode = implementationDataElementSyntaxErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
