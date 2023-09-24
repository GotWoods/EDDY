using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class V9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V9*3mi*L*NVtHsduV*IjYQ*Nq*FN*hV*3JL*UMX72G*1*qj*u*r8*9*FYKdAs*1*7*6*2*6";

		var expected = new V9_EventDetail()
		{
			EventCode = "3mi",
			Event = "L",
			Date = "NVtHsduV",
			Time = "IjYQ",
			CityName = "Nq",
			StateOrProvinceCode = "FN",
			CountryCode = "hV",
			StatusReasonCode = "3JL",
			StandardPointLocationCode = "UMX72G",
			Quantity = 1,
			TrainDelayReasonCode = "qj",
			FreeFormMessage = "u",
			TimeCode = "r8",
			Quantity2 = 9,
			StandardPointLocationCode2 = "FYKdAs",
			TotalEquipment = 1,
			TotalEquipment2 = 7,
			TotalEquipment3 = 6,
			Weight = 2,
			Length = 6,
		};

		var actual = Map.MapObject<V9_EventDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3mi", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		//Test Parameters
		subject.EventCode = eventCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 1;
			subject.TrainDelayReasonCode = "qj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "qj", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "qj", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string trainDelayReasonCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "3mi";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.TrainDelayReasonCode = trainDelayReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r8", "IjYQ", true)]
	[InlineData("r8", "", false)]
	[InlineData("", "IjYQ", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "3mi";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 1;
			subject.TrainDelayReasonCode = "qj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("FYKdAs", "UMX72G", true)]
	[InlineData("FYKdAs", "", false)]
	[InlineData("", "UMX72G", true)]
	public void Validation_ARequiresBStandardPointLocationCode2(string standardPointLocationCode2, string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new V9_EventDetail();
		//Required fields
		subject.EventCode = "3mi";
		//Test Parameters
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		subject.StandardPointLocationCode = standardPointLocationCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.TrainDelayReasonCode))
		{
			subject.Quantity = 1;
			subject.TrainDelayReasonCode = "qj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
