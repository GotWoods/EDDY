using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class DLPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DLP*Sr*nR*pt*6";

		var expected = new DLP_DeliveryParameter()
		{
			DeliveryTimeMeasurementTypeCode = "Sr",
			AppointmentTimeBasisCode = "nR",
			UnitOrBasisForMeasurementCode = "pt",
			Quantity = 6,
		};

		var actual = Map.MapObject<DLP_DeliveryParameter>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sr", true)]
	public void Validation_RequiredDeliveryTimeMeasurementTypeCode(string deliveryTimeMeasurementTypeCode, bool isValidExpected)
	{
		var subject = new DLP_DeliveryParameter();
		//Required fields
		subject.AppointmentTimeBasisCode = "nR";
		//Test Parameters
		subject.DeliveryTimeMeasurementTypeCode = deliveryTimeMeasurementTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "pt";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nR", true)]
	public void Validation_RequiredAppointmentTimeBasisCode(string appointmentTimeBasisCode, bool isValidExpected)
	{
		var subject = new DLP_DeliveryParameter();
		//Required fields
		subject.DeliveryTimeMeasurementTypeCode = "Sr";
		//Test Parameters
		subject.AppointmentTimeBasisCode = appointmentTimeBasisCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "pt";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("pt", 6, true)]
	[InlineData("pt", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new DLP_DeliveryParameter();
		//Required fields
		subject.DeliveryTimeMeasurementTypeCode = "Sr";
		subject.AppointmentTimeBasisCode = "nR";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
