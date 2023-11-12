using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class RDRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDR*sW*jm*DE*P*O";

		var expected = new RDR_ReturnDispositionReason()
		{
			ReturnsDispositionCode = "sW",
			ReturnRequestReasonCode = "jm",
			ReturnResponseReasonCode = "DE",
			Description = "P",
			YesNoConditionOrResponseCode = "O",
		};

		var actual = Map.MapObject<RDR_ReturnDispositionReason>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jm", "DE", false)]
	[InlineData("jm", "", true)]
	[InlineData("", "DE", true)]
	public void Validation_OnlyOneOfDescription(string returnRequestReasonCode, string returnResponseReasonCode, bool isValidExpected)
	{
		var subject = new RDR_ReturnDispositionReason();
		//Required fields
		//Test Parameters
		subject.ReturnRequestReasonCode = returnRequestReasonCode;
		subject.ReturnResponseReasonCode = returnResponseReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
