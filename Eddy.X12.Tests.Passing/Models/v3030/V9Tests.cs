using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class V9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V9*z3r*s*BBe9um*cZPY*XL*yF*uK*P9u*da7HTW*71PY*3O*l";

		var expected = new V9_EventDetail()
		{
			EventCode = "z3r",
			Event = "s",
			Date = "BBe9um",
			Time = "cZPY",
			CityName = "XL",
			StateOrProvinceCode = "yF",
			CountryCode = "uK",
			StatusReasonCode = "P9u",
			StandardPointLocationCode = "da7HTW",
			Time2 = "71PY",
			TrainDelayReasonCode = "3O",
			FreeFormMessage = "l",
		};

		var actual = Map.MapObject<V9_EventDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z3r", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
