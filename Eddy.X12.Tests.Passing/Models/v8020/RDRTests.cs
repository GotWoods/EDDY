using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class RDRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDR*wW*Ox*lO*v*c";

		var expected = new RDR_ReturnDispositionReason()
		{
			ReturnsDispositionCode = "wW",
			ReturnRequestReasonCode = "Ox",
			ReturnResponseReasonCode = "lO",
			Description = "v",
			YesNoConditionOrResponseCode = "c",
		};

		var actual = Map.MapObject<RDR_ReturnDispositionReason>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ox", "lO", false)]
	[InlineData("Ox", "", true)]
	[InlineData("", "lO", true)]
	public void Validation_OnlyOneOfReturnRequestReasonCode(string returnRequestReasonCode, string returnResponseReasonCode, bool isValidExpected)
	{
		var subject = new RDR_ReturnDispositionReason();
		//Required fields
		//Test Parameters
		subject.ReturnRequestReasonCode = returnRequestReasonCode;
		subject.ReturnResponseReasonCode = returnResponseReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
