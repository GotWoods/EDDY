using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RDRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDR*P4*mY*Jx*6*K";

		var expected = new RDR_ReturnDispositionReason()
		{
			ReturnsDispositionCode = "P4",
			ReturnRequestReasonCode = "mY",
			ReturnResponseReasonCode = "Jx",
			Description = "6",
			YesNoConditionOrResponseCode = "K",
		};

		var actual = Map.MapObject<RDR_ReturnDispositionReason>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mY", "Jx", false)]
	[InlineData("", "Jx", true)]
	[InlineData("mY", "", true)]
	public void Validation_OnlyOneOfReturnRequestReasonCode(string returnRequestReasonCode, string returnResponseReasonCode, bool isValidExpected)
	{
		var subject = new RDR_ReturnDispositionReason();
		subject.ReturnRequestReasonCode = returnRequestReasonCode;
		subject.ReturnResponseReasonCode = returnResponseReasonCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
