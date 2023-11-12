using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class V9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V9*Wii*W*aULK0v3o*9Wm4*Cd*8y*2f*9Nb*6ABMMx*2*gd*y*1i*2*rrtU2g*4*6*9*1*1";

		var expected = new V9_EventDetail()
		{
			EventCode = "Wii",
			Event = "W",
			Date = "aULK0v3o",
			Time = "9Wm4",
			CityName = "Cd",
			StateOrProvinceCode = "8y",
			CountryCode = "2f",
			StatusReasonCode = "9Nb",
			StandardPointLocationCode = "6ABMMx",
			Quantity = 2,
			TrainDelayReasonCode = "gd",
			FreeFormInformation = "y",
			TimeCode = "1i",
			Quantity2 = 2,
			StandardPointLocationCode2 = "rrtU2g",
			TotalEquipment = 4,
			TotalEquipment2 = 6,
			TotalEquipment3 = 9,
			Weight = 1,
			Length = 1,
		};

		var actual = Map.MapObject<V9_EventDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wii", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		//Test Parameters
		subject.EventCode = eventCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 2;
			subject.TrainDelayReasonCode = "gd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8y", "Cd", true)]
	[InlineData("8y", "", false)]
	[InlineData("", "Cd", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "Wii";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 2;
			subject.TrainDelayReasonCode = "gd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "gd", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "gd", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string trainDelayReasonCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "Wii";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.TrainDelayReasonCode = trainDelayReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1i", "9Wm4", true)]
	[InlineData("1i", "", false)]
	[InlineData("", "9Wm4", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "Wii";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 2;
			subject.TrainDelayReasonCode = "gd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rrtU2g", "6ABMMx", true)]
	[InlineData("rrtU2g", "", false)]
	[InlineData("", "6ABMMx", true)]
	public void Validation_ARequiresBStandardPointLocationCode2(string standardPointLocationCode2, string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "Wii";
		//Test Parameters
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		subject.StandardPointLocationCode = standardPointLocationCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 2;
			subject.TrainDelayReasonCode = "gd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
