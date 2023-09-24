using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class V9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V9*f12*3*hshFmXC6*yBQ0*gp*yb*0f*jPV*UIOTOu*3*0t*Q*ni*6*YDcCn2*9*3*8*5*5";

		var expected = new V9_EventDetail()
		{
			EventCode = "f12",
			Event = "3",
			Date = "hshFmXC6",
			Time = "yBQ0",
			CityName = "gp",
			StateOrProvinceCode = "yb",
			CountryCode = "0f",
			StatusReasonCode = "jPV",
			StandardPointLocationCode = "UIOTOu",
			Quantity = 3,
			TrainDelayReasonCode = "0t",
			FreeFormMessage = "Q",
			TimeCode = "ni",
			Quantity2 = 6,
			StandardPointLocationCode2 = "YDcCn2",
			TotalEquipment = 9,
			TotalEquipment2 = 3,
			TotalEquipment3 = 8,
			Weight = 5,
			Length = 5,
		};

		var actual = Map.MapObject<V9_EventDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f12", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		//Test Parameters
		subject.EventCode = eventCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 3;
			subject.TrainDelayReasonCode = "0t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yb", "gp", true)]
	[InlineData("yb", "", false)]
	[InlineData("", "gp", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "f12";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 3;
			subject.TrainDelayReasonCode = "0t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "0t", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "0t", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string trainDelayReasonCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "f12";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.TrainDelayReasonCode = trainDelayReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ni", "yBQ0", true)]
	[InlineData("ni", "", false)]
	[InlineData("", "yBQ0", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "f12";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 3;
			subject.TrainDelayReasonCode = "0t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("YDcCn2", "UIOTOu", true)]
	[InlineData("YDcCn2", "", false)]
	[InlineData("", "UIOTOu", true)]
	public void Validation_ARequiresBStandardPointLocationCode2(string standardPointLocationCode2, string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "f12";
		//Test Parameters
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		subject.StandardPointLocationCode = standardPointLocationCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 3;
			subject.TrainDelayReasonCode = "0t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
