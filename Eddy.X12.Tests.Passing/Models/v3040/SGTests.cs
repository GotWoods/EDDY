using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SG*S*jJy*1D*nwRKIu*The4*CV";

		var expected = new SG_ShipmentStatus()
		{
			StatusCode = "S",
			StatusReasonCode = "jJy",
			DispositionCode = "1D",
			Date = "nwRKIu",
			Time = "The4",
			TimeCode = "CV",
		};

		var actual = Map.MapObject<SG_ShipmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CV", "The4", true)]
	[InlineData("CV", "", false)]
	[InlineData("", "The4", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new SG_ShipmentStatus();
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
