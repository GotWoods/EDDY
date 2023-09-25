using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W03*8*4*Te*3*kK*8*kN";

		var expected = new W03_TotalShipmentInformation()
		{
			NumberOfUnitsShipped = 8,
			Weight = 4,
			UnitOfMeasurementCode = "Te",
			Volume = 3,
			UnitOfMeasurementCode2 = "kK",
			LadingQuantity = 8,
			UnitOfMeasurementCode3 = "kN",
		};

		var actual = Map.MapObject<W03_TotalShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.Weight = 4;
		subject.UnitOfMeasurementCode = "Te";
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Volume = 3;
			subject.UnitOfMeasurementCode2 = "kK";
		}
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.LadingQuantity = 8;
			subject.UnitOfMeasurementCode3 = "kN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOfMeasurementCode = "Te";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Volume = 3;
			subject.UnitOfMeasurementCode2 = "kK";
		}
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.LadingQuantity = 8;
			subject.UnitOfMeasurementCode3 = "kN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Te", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 8;
		subject.Weight = 4;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Volume = 3;
			subject.UnitOfMeasurementCode2 = "kK";
		}
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.LadingQuantity = 8;
			subject.UnitOfMeasurementCode3 = "kN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "kK", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "kK", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 8;
		subject.Weight = 4;
		subject.UnitOfMeasurementCode = "Te";
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one filled, all required
		if(subject.LadingQuantity > 0 || subject.LadingQuantity > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.LadingQuantity = 8;
			subject.UnitOfMeasurementCode3 = "kN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "kN", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "kN", false)]
	public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 8;
		subject.Weight = 4;
		subject.UnitOfMeasurementCode = "Te";
		//Test Parameters
		if (ladingQuantity > 0) 
			subject.LadingQuantity = ladingQuantity;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Volume = 3;
			subject.UnitOfMeasurementCode2 = "kK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
