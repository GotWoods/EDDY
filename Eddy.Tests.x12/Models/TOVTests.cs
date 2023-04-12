using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TOVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TOV*36*nq2*1a*k*9q*3";

		var expected = new TOV_VehicleUseInformation()
		{
			HazardousVehicleTypeCode = "36",
			DateTimeQualifier = "nq2",
			DateTimePeriodFormatQualifier = "1a",
			DateTimePeriod = "k",
			QuantityQualifier = "9q",
			Quantity = 3,
		};

		var actual = Map.MapObject<TOV_VehicleUseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("36", true)]
	public void Validation_RequiredHazardousVehicleTypeCode(string hazardousVehicleTypeCode, bool isValidExpected)
	{
		var subject = new TOV_VehicleUseInformation();
		subject.HazardousVehicleTypeCode = hazardousVehicleTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("9q", 3, true)]
	[InlineData("", 3, false)]
	[InlineData("9q", 0, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new TOV_VehicleUseInformation();
		subject.HazardousVehicleTypeCode = "36";
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
