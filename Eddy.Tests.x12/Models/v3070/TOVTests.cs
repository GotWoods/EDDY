using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TOVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TOV*w1*Qmx*bt*l*OQ*5";

		var expected = new TOV_VehicleUseInformation()
		{
			HazardousVehicleTypeCode = "w1",
			DateTimeQualifier = "Qmx",
			DateTimePeriodFormatQualifier = "bt",
			DateTimePeriod = "l",
			QuantityQualifier = "OQ",
			Quantity = 5,
		};

		var actual = Map.MapObject<TOV_VehicleUseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w1", true)]
	public void Validation_RequiredHazardousVehicleTypeCode(string hazardousVehicleTypeCode, bool isValidExpected)
	{
		var subject = new TOV_VehicleUseInformation();
		//Required fields
		//Test Parameters
		subject.HazardousVehicleTypeCode = hazardousVehicleTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "OQ";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("OQ", 5, true)]
	[InlineData("OQ", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new TOV_VehicleUseInformation();
		//Required fields
		subject.HazardousVehicleTypeCode = "w1";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
