using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SG*j*pG3*SF*OcvP87*F0Ck*nT";

		var expected = new SG_ShipmentStatus()
		{
			StatusCode = "j",
			StatusReasonCode = "pG3",
			DispositionCode = "SF",
			Date = "OcvP87",
			Time = "F0Ck",
			TimeCode = "nT",
		};

		var actual = Map.MapObject<SG_ShipmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nT", "F0Ck", true)]
	[InlineData("nT", "", false)]
	[InlineData("", "F0Ck", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new SG_ShipmentStatus();
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
