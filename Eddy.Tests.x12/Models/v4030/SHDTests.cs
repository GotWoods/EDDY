using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class SHDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHD*7*3*4N*1*kZ*6*Cs*7*H*S*95*zy*T3*9";

		var expected = new SHD_ShipmentDetail()
		{
			NumberOfUnitsShipped = 7,
			QuantityReceived = 3,
			UnitOrBasisForMeasurementCode = "4N",
			Weight = 1,
			UnitOrBasisForMeasurementCode2 = "kZ",
			Volume = 6,
			UnitOrBasisForMeasurementCode3 = "Cs",
			OrderSizingFactor = 7,
			PriceBracketIdentifier = "H",
			TransportationMethodTypeCode = "S",
			StandardCarrierAlphaCode = "95",
			ShipmentOrderStatusCode = "zy",
			ReferenceIdentificationQualifier = "T3",
			ReferenceIdentification = "9",
		};

		var actual = Map.MapObject<SHD_ShipmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "4N", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "4N", true)]
	public void Validation_ARequiresBNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;

        if (numberOfUnitsShipped == 0)
            subject.QuantityReceived = 1;

        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "kZ";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Cs";
		}
        subject.UnitOrBasisForMeasurementCode = "JX";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(7, 3, true)]
	[InlineData(7, 0, true)]
	[InlineData(0, 3, true)]
	public void Validation_AtLeastOneNumberOfUnitsShipped(decimal numberOfUnitsShipped, decimal quantityReceived, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		//A Requires B
		if (quantityReceived > 0)
			subject.UnitOrBasisForMeasurementCode = "4N";
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "kZ";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Cs";
		}

        subject.UnitOrBasisForMeasurementCode = "JX";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "4N", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "4N", true)]
	public void Validation_ARequiresBQuantityReceived(decimal quantityReceived, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.NumberOfUnitsShipped = 7;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "kZ";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Cs";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "kZ", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "kZ", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//At Least one
		subject.NumberOfUnitsShipped = 7;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Cs";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "Cs", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "Cs", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//At Least one
		subject.NumberOfUnitsShipped = 7;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "kZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T3", "9", true)]
	[InlineData("T3", "", false)]
	[InlineData("", "9", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.NumberOfUnitsShipped = 7;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "kZ";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "Cs";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
