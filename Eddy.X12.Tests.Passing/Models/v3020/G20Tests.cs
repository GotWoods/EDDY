using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G20*2*5*8p*1*35*7*QV*M";

		var expected = new G20_ItemPackingDetail()
		{
			Pack = 2,
			Size = 5,
			UnitOfMeasurementCode = "8p",
			Weight = 1,
			UnitOfMeasurementCode2 = "35",
			Volume = 7,
			UnitOfMeasurementCode3 = "QV",
			Color = "M",
		};

		var actual = Map.MapObject<G20_ItemPackingDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "8p", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "8p", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G20_ItemPackingDetail();
		if (size > 0)
			subject.Size = size;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOfMeasurementCode2 = "35";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOfMeasurementCode3 = "QV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "35", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "35", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G20_ItemPackingDetail();
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Size = 5;
			subject.UnitOfMeasurementCode = "8p";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOfMeasurementCode3 = "QV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "QV", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "QV", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new G20_ItemPackingDetail();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Size = 5;
			subject.UnitOfMeasurementCode = "8p";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOfMeasurementCode2 = "35";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
