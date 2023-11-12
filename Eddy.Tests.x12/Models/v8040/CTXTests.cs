using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v8040.Composites;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.Tests.Models.v8040;

public class CTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTX**OO*6*Y***v";

		var expected = new CTX_Context()
		{
			ContextIdentification = null,
			SegmentIDCode = "OO",
			SegmentPositionInTransactionSet = 6,
			LoopIdentifierCode = "Y",
			PositionInSegment = null,
			ReferenceInSegment = null,
			CopyOfDataElement = "v",
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
