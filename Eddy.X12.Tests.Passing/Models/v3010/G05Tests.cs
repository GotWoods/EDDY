using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G05Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G05*5*8B*7*wN*5*os*3*8n";

		var expected = new G05_TotalShipmentInformation()
		{
			NumberOfUnitsShipped = 5,
			UnitOfMeasurementCode = "8B",
			Weight = 7,
			UnitOfMeasurementCode2 = "wN",
			Volume = 5,
			UnitOfMeasurementCode3 = "os",
			LadingQuantity = 3,
			UnitOfMeasurementCode4 = "8n",
		};

		var actual = Map.MapObject<G05_TotalShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.UnitOfMeasurementCode = "8B";
		subject.Weight = 7;
		subject.UnitOfMeasurementCode2 = "wN";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8B", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.NumberOfUnitsShipped = 5;
		subject.Weight = 7;
		subject.UnitOfMeasurementCode2 = "wN";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.NumberOfUnitsShipped = 5;
		subject.UnitOfMeasurementCode = "8B";
		subject.UnitOfMeasurementCode2 = "wN";
		if (weight > 0)
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wN", true)]
	public void Validation_RequiredUnitOfMeasurementCode2(string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G05_TotalShipmentInformation();
		subject.NumberOfUnitsShipped = 5;
		subject.UnitOfMeasurementCode = "8B";
		subject.Weight = 7;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
