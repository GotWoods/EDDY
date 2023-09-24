using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SG*f*SKd*sq*Ac6fC4gV*0V8g*Pn";

		var expected = new SG_ShipmentStatus()
		{
			ShipmentStatusCode = "f",
			StatusReasonCode = "SKd",
			BillOfLadingDispositionCode = "sq",
			Date = "Ac6fC4gV",
			Time = "0V8g",
			TimeCode = "Pn",
		};

		var actual = Map.MapObject<SG_ShipmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Pn", "0V8g", true)]
	[InlineData("Pn", "", false)]
	[InlineData("", "0V8g", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new SG_ShipmentStatus();
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
