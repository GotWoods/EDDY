using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SHDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHD*4*6*3p*9*t6*7*2u*8*Q*N*12*RO*VR*0";

		var expected = new SHD_ShipmentDetail()
		{
			NumberOfUnitsShipped = 4,
			QuantityReceived = 6,
			UnitOrBasisForMeasurementCode = "3p",
			Weight = 9,
			UnitOrBasisForMeasurementCode2 = "t6",
			Volume = 7,
			UnitOrBasisForMeasurementCode3 = "2u",
			OrderSizingFactor = 8,
			PriceBracketIdentifier = "Q",
			TransportationMethodTypeCode = "N",
			StandardCarrierAlphaCode = "12",
			ShipmentOrderStatusCode = "RO",
			ReferenceIdentificationQualifier = "VR",
			ReferenceIdentification = "0",
		};

		var actual = Map.MapObject<SHD_ShipmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "3p", true)]
	[InlineData(4, "", false)]
	public void Validation_ARequiresBNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		if (numberOfUnitsShipped > 0)
		subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0,0, false)]
	[InlineData(4,6, true)]
	[InlineData(0, 6, true)]
	[InlineData(4, 0, true)]
	public void Validation_AtLeastOneNumberOfUnitsShipped(decimal numberOfUnitsShipped, decimal quantityReceived, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		if (numberOfUnitsShipped > 0)
		subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		if (quantityReceived > 0)
		subject.QuantityReceived = quantityReceived;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "3p", true)]
	[InlineData(6, "", false)]
	public void Validation_ARequiresBQuantityReceived(decimal quantityReceived, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		if (quantityReceived > 0)
		subject.QuantityReceived = quantityReceived;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "t6", true)]
	[InlineData(0, "t6", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		if (weight > 0)
		subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "2u", true)]
	[InlineData(0, "2u", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		if (volume > 0)
		subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "0", true)]
	[InlineData("VR", "", false)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
