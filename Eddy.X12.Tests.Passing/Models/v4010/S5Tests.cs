using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class S5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S5*4*b7*1*t*7*sl*1*s*b*9q6meN*9";

		var expected = new S5_StopOffDetails()
		{
			StopSequenceNumber = 4,
			StopReasonCode = "b7",
			Weight = 1,
			WeightUnitCode = "t",
			NumberOfUnitsShipped = 7,
			UnitOrBasisForMeasurementCode = "sl",
			Volume = 1,
			VolumeUnitQualifier = "s",
			Description = "b",
			StandardPointLocationCode = "9q6meN",
			AccomplishCode = "9",
		};

		var actual = Map.MapObject<S5_StopOffDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S5_StopOffDetails();
		subject.StopReasonCode = "b7";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "t";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode = "sl";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 1;
			subject.VolumeUnitQualifier = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b7", true)]
	public void Validation_RequiredStopReasonCode(string stopReasonCode, bool isValidExpected)
	{
		var subject = new S5_StopOffDetails();
		subject.StopSequenceNumber = 4;
		subject.StopReasonCode = stopReasonCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "t";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode = "sl";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 1;
			subject.VolumeUnitQualifier = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "t", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "t", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new S5_StopOffDetails();
		subject.StopSequenceNumber = 4;
		subject.StopReasonCode = "b7";
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode = "sl";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 1;
			subject.VolumeUnitQualifier = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "sl", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "sl", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new S5_StopOffDetails();
		subject.StopSequenceNumber = 4;
		subject.StopReasonCode = "b7";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "t";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 1;
			subject.VolumeUnitQualifier = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "s", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "s", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new S5_StopOffDetails();
		subject.StopSequenceNumber = 4;
		subject.StopReasonCode = "b7";
		if (volume > 0)
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "t";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode = "sl";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
