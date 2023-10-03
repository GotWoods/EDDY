using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6040.Composites;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.Tests.Models.v6040;

public class AK4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AK4**q*k*y";

		var expected = new AK4_DataElementNote()
		{
			PositionInSegment = null,
			DataElementReferenceCode = "q",
			DataElementSyntaxErrorCode = "k",
			CopyOfBadDataElement = "y",
		};

		var actual = Map.MapObject<AK4_DataElementNote>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredDataElementSyntaxErrorCode(string dataElementSyntaxErrorCode, bool isValidExpected)
	{
		var subject = new AK4_DataElementNote();
		subject.PositionInSegment = new C030_PositionInSegment();
		subject.DataElementSyntaxErrorCode = dataElementSyntaxErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
