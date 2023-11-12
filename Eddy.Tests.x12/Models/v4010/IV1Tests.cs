using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class IV1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IV1*g*7*7*q*cc";

		var expected = new IV1_LaneEstimates()
		{
			VolumeUnitQualifier = "g",
			Volume = 7,
			Number = 7,
			TransportationMethodTypeCode = "q",
			UnitOfTimePeriodOrInterval = "cc",
		};

		var actual = Map.MapObject<IV1_LaneEstimates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("g", 7, true)]
	[InlineData("g", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new IV1_LaneEstimates();
		//Required fields
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("cc", 7, true)]
	[InlineData("cc", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, decimal volume, bool isValidExpected)
	{
		var subject = new IV1_LaneEstimates();
		//Required fields
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		if (volume > 0) 
			subject.Volume = volume;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "g";
			subject.Volume = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
