using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class V9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V9*XAy*N*tPklOQ5D*pLEf*eD*cS*Cr*pe2*rCYaSZ*4*tQ*0*QB*2*IZX0mR*6*2*3*6*3";

		var expected = new V9_EventDetail()
		{
			EventCode = "XAy",
			Event = "N",
			Date = "tPklOQ5D",
			Time = "pLEf",
			CityName = "eD",
			StateOrProvinceCode = "cS",
			CountryCode = "Cr",
			StatusReasonCode = "pe2",
			StandardPointLocationCode = "rCYaSZ",
			Quantity = 4,
			TrainDelayReasonCode = "tQ",
			FreeFormInformation = "0",
			TimeCode = "QB",
			Quantity2 = 2,
			StandardPointLocationCode2 = "IZX0mR",
			TotalEquipment = 6,
			TotalEquipment2 = 2,
			TotalEquipment3 = 3,
			Weight = 6,
			Length = 3,
		};

		var actual = Map.MapObject<V9_EventDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XAy", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "eD", true)]
	[InlineData("cS", "", false)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		subject.EventCode = "XAy";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "tQ", true)]
	[InlineData(0, "tQ", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string trainDelayReasonCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		subject.EventCode = "XAy";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.TrainDelayReasonCode = trainDelayReasonCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "pLEf", true)]
	[InlineData("QB", "", false)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		subject.EventCode = "XAy";
		subject.TimeCode = timeCode;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "rCYaSZ", true)]
	[InlineData("IZX0mR", "", false)]
	public void Validation_ARequiresBStandardPointLocationCode2(string standardPointLocationCode2, string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		subject.EventCode = "XAy";
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		subject.StandardPointLocationCode = standardPointLocationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
