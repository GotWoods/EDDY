using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class V9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V9*GQV*q*7RtgFiAw*kbBD*tH*9X*XZ*0cL*DhUSSM*5*ej*F*D7*9*mPdP3g*4*2*8*1*6";

		var expected = new V9_EventDetail()
		{
			EventCode = "GQV",
			Event = "q",
			Date = "7RtgFiAw",
			Time = "kbBD",
			CityName = "tH",
			StateOrProvinceCode = "9X",
			CountryCode = "XZ",
			StatusReasonCode = "0cL",
			StandardPointLocationCode = "DhUSSM",
			Quantity = 5,
			TrainDelayReasonCode = "ej",
			FreeFormMessage = "F",
			TimeCode = "D7",
			Quantity2 = 9,
			StandardPointLocationCode2 = "mPdP3g",
			TotalEquipment = 4,
			TotalEquipment2 = 2,
			TotalEquipment3 = 8,
			Weight = 1,
			Length = 6,
		};

		var actual = Map.MapObject<V9_EventDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GQV", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		//Test Parameters
		subject.EventCode = eventCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 5;
			subject.TrainDelayReasonCode = "ej";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9X", "tH", true)]
	[InlineData("9X", "", false)]
	[InlineData("", "tH", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "GQV";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 5;
			subject.TrainDelayReasonCode = "ej";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "ej", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "ej", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string trainDelayReasonCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "GQV";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.TrainDelayReasonCode = trainDelayReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D7", "kbBD", true)]
	[InlineData("D7", "", false)]
	[InlineData("", "kbBD", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "GQV";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 5;
			subject.TrainDelayReasonCode = "ej";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mPdP3g", "DhUSSM", true)]
	[InlineData("mPdP3g", "", false)]
	[InlineData("", "DhUSSM", true)]
	public void Validation_ARequiresBStandardPointLocationCode2(string standardPointLocationCode2, string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "GQV";
		//Test Parameters
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		subject.StandardPointLocationCode = standardPointLocationCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 5;
			subject.TrainDelayReasonCode = "ej";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
