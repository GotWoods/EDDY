using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5010.Composites;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class IK4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IK4**8*p*j";

		var expected = new IK4_ImplementationDataElementNote()
		{
			PositionInSegment = null,
			DataElementReferenceNumber = 8,
			ImplementationDataElementSyntaxErrorCode = "p",
			CopyOfBadDataElement = "j",
		};

		var actual = Map.MapObject<IK4_ImplementationDataElementNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPositionInSegment(string positionInSegment, bool isValidExpected)
	{
		var subject = new IK4_ImplementationDataElementNote();
		//Required fields
		subject.ImplementationDataElementSyntaxErrorCode = "p";
		//Test Parameters
		if (positionInSegment != "") 
			subject.PositionInSegment = new C030_PositionInSegment();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredImplementationDataElementSyntaxErrorCode(string implementationDataElementSyntaxErrorCode, bool isValidExpected)
	{
		var subject = new IK4_ImplementationDataElementNote();
		//Required fields
		subject.PositionInSegment = new C030_PositionInSegment();
		//Test Parameters
		subject.ImplementationDataElementSyntaxErrorCode = implementationDataElementSyntaxErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
