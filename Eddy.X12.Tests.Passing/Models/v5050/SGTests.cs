using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class SGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SG*T*Iic*a3*eMl93bmR*IJYz*br";

		var expected = new SG_ShipmentStatus()
		{
			ShipmentStatusCode = "T",
			StatusReasonCode = "Iic",
			BillOfLadingDispositionCode = "a3",
			Date = "eMl93bmR",
			Time = "IJYz",
			TimeCode = "br",
		};

		var actual = Map.MapObject<SG_ShipmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("br", "IJYz", true)]
	[InlineData("br", "", false)]
	[InlineData("", "IJYz", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new SG_ShipmentStatus();
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
