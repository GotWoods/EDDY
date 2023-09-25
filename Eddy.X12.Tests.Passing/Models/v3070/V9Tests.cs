using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class V9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V9*nAX*x*DnaNI8*3N7w*lq*fq*vC*rne*qwJv7s*6*xz*v*13*7";

		var expected = new V9_EventDetail()
		{
			EventCode = "nAX",
			Event = "x",
			Date = "DnaNI8",
			Time = "3N7w",
			CityName = "lq",
			StateOrProvinceCode = "fq",
			CountryCode = "vC",
			StatusReasonCode = "rne",
			StandardPointLocationCode = "qwJv7s",
			Quantity = 6,
			TrainDelayReasonCode = "xz",
			FreeFormMessage = "v",
			TimeCode = "13",
			Quantity2 = 7,
		};

		var actual = Map.MapObject<V9_EventDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nAX", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		//Test Parameters
		subject.EventCode = eventCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 6;
			subject.TrainDelayReasonCode = "xz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "xz", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "xz", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string trainDelayReasonCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "nAX";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.TrainDelayReasonCode = trainDelayReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("13", "3N7w", true)]
	[InlineData("13", "", false)]
	[InlineData("", "3N7w", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "nAX";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 6;
			subject.TrainDelayReasonCode = "xz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
