using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CR1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR1*K1*6*I*X*LU*2*a*p*8*S";

		var expected = new CR1_AmbulanceCertification()
		{
			UnitOrBasisForMeasurementCode = "K1",
			Weight = 6,
			AmbulanceTransportCode = "I",
			AmbulanceTransportReasonCode = "X",
			UnitOrBasisForMeasurementCode2 = "LU",
			Quantity = 2,
			AddressInformation = "a",
			AddressInformation2 = "p",
			Description = "8",
			Description2 = "S",
		};

		var actual = Map.MapObject<CR1_AmbulanceCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("K1", 6, true)]
	[InlineData("K1", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal weight, bool isValidExpected)
	{
		var subject = new CR1_AmbulanceCertification();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "LU";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("LU", 2, true)]
	[InlineData("LU", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity, bool isValidExpected)
	{
		var subject = new CR1_AmbulanceCertification();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "K1";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
