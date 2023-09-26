using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class IV1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IV1*r*6*6*L*ve";

		var expected = new IV1_LaneEstimates()
		{
			VolumeUnitQualifier = "r",
			Volume = 6,
			Number = 6,
			TransportationMethodTypeCode = "L",
			UnitOfTimePeriodOrIntervalCode = "ve",
		};

		var actual = Map.MapObject<IV1_LaneEstimates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("r", 6, true)]
	[InlineData("r", 0, false)]
	[InlineData("", 6, false)]
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
	[InlineData("ve", 6, true)]
	[InlineData("ve", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, decimal volume, bool isValidExpected)
	{
		var subject = new IV1_LaneEstimates();
		//Required fields
		//Test Parameters
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		if (volume > 0) 
			subject.Volume = volume;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "r";
			subject.Volume = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
