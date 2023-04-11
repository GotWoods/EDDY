using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SG*D*3Qr*8y*ss9hglxs*yzRi*kY";

		var expected = new SG_ShipmentStatus()
		{
			ShipmentStatusCode = "D",
			StatusReasonCode = "3Qr",
			BillOfLadingDispositionCode = "8y",
			Date = "ss9hglxs",
			Time = "yzRi",
			TimeCode = "kY",
		};

		var actual = Map.MapObject<SG_ShipmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "yzRi", true)]
	[InlineData("kY", "", false)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new SG_ShipmentStatus();
		subject.TimeCode = timeCode;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
