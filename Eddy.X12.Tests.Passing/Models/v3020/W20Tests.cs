using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W20*8*3*ys*4*z*9*4*2*vs*L";

		var expected = new W20_LineItemDetailMiscellaneous()
		{
			Pack = 8,
			Size = 3,
			UnitOfMeasurementCode = "ys",
			Weight = 4,
			WeightQualifier = "z",
			WeightUnitQualifier = "9",
			UnitWeight = 4,
			Volume = 2,
			UnitOfMeasurementCode2 = "vs",
			Color = "L",
		};

		var actual = Map.MapObject<W20_LineItemDetailMiscellaneous>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "ys", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "ys", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W20_LineItemDetailMiscellaneous();
		//Required fields
		//Test Parameters
		if (size > 0) 
			subject.Size = size;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Volume = 2;
			subject.UnitOfMeasurementCode2 = "vs";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "vs", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "vs", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new W20_LineItemDetailMiscellaneous();
		//Required fields
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOfMeasurementCode = "ys";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
