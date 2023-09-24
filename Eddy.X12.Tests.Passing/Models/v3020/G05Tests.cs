using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G05*8*kE*2*VN*5*1w*3*4V";

		var expected = new G05_TotalShipmentInformation()
		{
			NumberOfUnitsShipped = 8,
			UnitOfMeasurementCode = "kE",
			Weight = 2,
			UnitOfMeasurementCode2 = "VN",
			Volume = 5,
			UnitOfMeasurementCode3 = "1w",
			LadingQuantity = 3,
			UnitOfMeasurementCode4 = "4V",
		};

		var actual = Map.MapObject<G05_TotalShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.UnitOfMeasurementCode = "kE";
		subject.Weight = 2;
		subject.UnitOfMeasurementCode2 = "VN";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOfMeasurementCode3 = "1w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kE", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.NumberOfUnitsShipped = 8;
		subject.Weight = 2;
		subject.UnitOfMeasurementCode2 = "VN";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOfMeasurementCode3 = "1w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOfMeasurementCode = "kE";
		subject.UnitOfMeasurementCode2 = "VN";
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOfMeasurementCode3 = "1w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VN", true)]
	public void Validation_RequiredUnitOfMeasurementCode2(string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOfMeasurementCode = "kE";
		subject.Weight = 2;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOfMeasurementCode3 = "1w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "1w", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "1w", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOfMeasurementCode = "kE";
		subject.Weight = 2;
		subject.UnitOfMeasurementCode2 = "VN";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
