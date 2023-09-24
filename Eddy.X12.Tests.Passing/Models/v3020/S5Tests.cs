using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class S5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S5*5*q6*3*e*5*3p*5*K*u*Zu2D3A*i";

		var expected = new S5_StopOffDetails()
		{
			StopSequenceNumber = 5,
			StopReasonCode = "q6",
			Weight = 3,
			WeightUnitQualifier = "e",
			NumberOfUnitsShipped = 5,
			UnitOfMeasurementCode = "3p",
			Volume = 5,
			VolumeUnitQualifier = "K",
			Description = "u",
			StandardPointLocationCode = "Zu2D3A",
			AccomplishCode = "i",
		};

		var actual = Map.MapObject<S5_StopOffDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S5_StopOffDetails();
		subject.StopReasonCode = "q6";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitQualifier))
		{
			subject.Weight = 3;
			subject.WeightUnitQualifier = "e";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 5;
			subject.UnitOfMeasurementCode = "3p";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q6", true)]
	public void Validation_RequiredStopReasonCode(string stopReasonCode, bool isValidExpected)
	{
		var subject = new S5_StopOffDetails();
		subject.StopSequenceNumber = 5;
		subject.StopReasonCode = stopReasonCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitQualifier))
		{
			subject.Weight = 3;
			subject.WeightUnitQualifier = "e";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 5;
			subject.UnitOfMeasurementCode = "3p";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "e", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "e", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitQualifier, bool isValidExpected)
	{
		var subject = new S5_StopOffDetails();
		subject.StopSequenceNumber = 5;
		subject.StopReasonCode = "q6";
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightUnitQualifier = weightUnitQualifier;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 5;
			subject.UnitOfMeasurementCode = "3p";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "3p", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "3p", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new S5_StopOffDetails();
		subject.StopSequenceNumber = 5;
		subject.StopReasonCode = "q6";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitQualifier))
		{
			subject.Weight = 3;
			subject.WeightUnitQualifier = "e";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "K", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "K", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new S5_StopOffDetails();
		subject.StopSequenceNumber = 5;
		subject.StopReasonCode = "q6";
		if (volume > 0)
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitQualifier))
		{
			subject.Weight = 3;
			subject.WeightUnitQualifier = "e";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 5;
			subject.UnitOfMeasurementCode = "3p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
