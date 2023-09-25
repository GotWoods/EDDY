using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class V9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V9*Qt4*3*1Cf6fF*aBnI*hM*zY*Xg*Sph*mi6uVg*C1vN*Gf*z*d1";

		var expected = new V9_EventDetail()
		{
			EventCode = "Qt4",
			Event = "3",
			Date = "1Cf6fF",
			Time = "aBnI",
			CityName = "hM",
			StateOrProvinceCode = "zY",
			CountryCode = "Xg",
			StatusReasonCode = "Sph",
			StandardPointLocationCode = "mi6uVg",
			Time2 = "C1vN",
			TrainDelayReasonCode = "Gf",
			FreeFormMessage = "z",
			TimeCode = "d1",
		};

		var actual = Map.MapObject<V9_EventDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qt4", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d1", "aBnI", true)]
	[InlineData("d1", "", false)]
	[InlineData("", "aBnI", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "Qt4";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
