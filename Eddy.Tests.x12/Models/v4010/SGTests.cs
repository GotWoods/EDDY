using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SG*B*DSK*iK*YZCtwZ2f*Ar2p*TZ";

		var expected = new SG_ShipmentStatus()
		{
			ShipmentStatusCode = "B",
			StatusReasonCode = "DSK",
			DispositionCode = "iK",
			Date = "YZCtwZ2f",
			Time = "Ar2p",
			TimeCode = "TZ",
		};

		var actual = Map.MapObject<SG_ShipmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TZ", "Ar2p", true)]
	[InlineData("TZ", "", false)]
	[InlineData("", "Ar2p", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new SG_ShipmentStatus();
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
