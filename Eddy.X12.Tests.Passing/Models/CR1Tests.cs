using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CR1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR1*cT*1*9*7*kd*9*7*E*x*C";

		var expected = new CR1_AmbulanceCertification()
		{
			UnitOrBasisForMeasurementCode = "cT",
			Weight = 1,
			AmbulanceTransportCode = "9",
			AmbulanceTransportReasonCode = "7",
			UnitOrBasisForMeasurementCode2 = "kd",
			Quantity = 9,
			AddressInformation = "7",
			AddressInformation2 = "E",
			Description = "x",
			Description2 = "C",
		};

		var actual = Map.MapObject<CR1_AmbulanceCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("cT", 1, true)]
	[InlineData("", 1, false)]
	[InlineData("cT", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal weight, bool isValidExpected)
	{
		var subject = new CR1_AmbulanceCertification();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (weight > 0)
		subject.Weight = weight;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("kd", 9, true)]
	[InlineData("", 9, false)]
	[InlineData("kd", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity, bool isValidExpected)
	{
		var subject = new CR1_AmbulanceCertification();
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
