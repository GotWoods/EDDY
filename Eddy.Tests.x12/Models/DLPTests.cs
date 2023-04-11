using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DLPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DLP*uy*Pq*2R*3";

		var expected = new DLP_DeliveryParameter()
		{
			DeliveryTimeMeasurementTypeCode = "uy",
			AppointmentTimeBasisCode = "Pq",
			UnitOrBasisForMeasurementCode = "2R",
			Quantity = 3,
		};

		var actual = Map.MapObject<DLP_DeliveryParameter>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uy", true)]
	public void Validation_RequiredDeliveryTimeMeasurementTypeCode(string deliveryTimeMeasurementTypeCode, bool isValidExpected)
	{
		var subject = new DLP_DeliveryParameter();
		subject.AppointmentTimeBasisCode = "Pq";
		subject.DeliveryTimeMeasurementTypeCode = deliveryTimeMeasurementTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pq", true)]
	public void Validation_RequiredAppointmentTimeBasisCode(string appointmentTimeBasisCode, bool isValidExpected)
	{
		var subject = new DLP_DeliveryParameter();
		subject.DeliveryTimeMeasurementTypeCode = "uy";
		subject.AppointmentTimeBasisCode = appointmentTimeBasisCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("2R", 3, true)]
	[InlineData("", 3, false)]
	[InlineData("2R", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new DLP_DeliveryParameter();
		subject.DeliveryTimeMeasurementTypeCode = "uy";
		subject.AppointmentTimeBasisCode = "Pq";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
