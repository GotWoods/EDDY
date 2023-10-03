using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6040;
using Eddy.x12.Models.v6040.Composites;

namespace Eddy.x12.Tests.Models.v6040;

public class IK4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IK4**h*I*K";

		var expected = new IK4_ImplementationDataElementNote()
		{
			PositionInSegment = null,
			DataElementReferenceCode = "h",
			ImplementationDataElementSyntaxErrorCode = "I",
			CopyOfBadDataElement = "K",
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
		subject.ImplementationDataElementSyntaxErrorCode = "I";
		//Test Parameters
		if (positionInSegment != "") 
			subject.PositionInSegment = new C030_PositionInSegment();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
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
