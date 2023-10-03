using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6050.Composites;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.Tests.Models.v6050;

public class CTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTX**Ek*3*9**";

		var expected = new CTX_Context()
		{
			ContextIdentification = null,
			SegmentIDCode = "Ek",
			SegmentPositionInTransactionSet = 3,
			LoopIdentifierCode = "9",
			PositionInSegment = null,
			ReferenceInSegment = null,
		};

		var actual = Map.MapObject<CTX_Context>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredContextIdentification(string contextIdentification, bool isValidExpected)
	{
		var subject = new CTX_Context();
		//Required fields
		//Test Parameters
		if (contextIdentification != "") 
			subject.ContextIdentification = new C998_ContextIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
