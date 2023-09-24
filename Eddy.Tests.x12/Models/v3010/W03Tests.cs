using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W03*8*6*Fm*9*iZ*2*0e";

		var expected = new W03_TotalShipmentInformation()
		{
			NumberOfUnitsShipped = 8,
			Weight = 6,
			UnitOfMeasurementCode = "Fm",
			Volume = 9,
			UnitOfMeasurementCode2 = "iZ",
			LadingQuantity = 2,
			UnitOfMeasurementCode3 = "0e",
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
		subject.Weight = 6;
		subject.UnitOfMeasurementCode = "Fm";
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOfMeasurementCode = "Fm";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fm", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W03_TotalShipmentInformation();
		//Required fields
		subject.NumberOfUnitsShipped = 8;
		subject.Weight = 6;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
