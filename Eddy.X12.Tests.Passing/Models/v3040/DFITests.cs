using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class DFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DFI*yfa*U*K*e";

		var expected = new DFI_DefaultInformation()
		{
			StatusReasonCode = "yfa",
			ClaimFilingIndicatorCode = "U",
			YesNoConditionOrResponseCode = "K",
			YesNoConditionOrResponseCode2 = "e",
		};

		var actual = Map.MapObject<DFI_DefaultInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yfa", true)]
	public void Validation_RequiredStatusReasonCode(string statusReasonCode, bool isValidExpected)
	{
		var subject = new DFI_DefaultInformation();
		//Required fields
		//Test Parameters
		subject.StatusReasonCode = statusReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
