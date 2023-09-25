using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class SHDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHD*6*8*7B*4*Z0*3*Hr*9*3*f*rO*5c*0b*e";

		var expected = new SHD_ShipmentDetail()
		{
			NumberOfUnitsShipped = 6,
			QuantityReceived = 8,
			UnitOrBasisForMeasurementCode = "7B",
			Weight = 4,
			UnitOrBasisForMeasurementCode2 = "Z0",
			Volume = 3,
			UnitOrBasisForMeasurementCode3 = "Hr",
			OrderSizingFactor = 9,
			PriceBracketIdentifier = "3",
			TransportationMethodTypeCode = "f",
			StandardCarrierAlphaCode = "rO",
			ShipmentOrderStatusCode = "5c",
			ReferenceIdentificationQualifier = "0b",
			ReferenceIdentification = "e",
		};

		var actual = Map.MapObject<SHD_ShipmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(6, "7B", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "7B", true)]
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
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "Z0";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Hr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(6, 8, true)]
	[InlineData(6, 0, true)]
	[InlineData(0, 8, true)]
	public void Validation_AtLeastOneNumberOfUnitsShipped(decimal numberOfUnitsShipped, decimal quantityReceived, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		
        subject.UnitOrBasisForMeasurementCode = "7B";
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "Z0";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Hr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "7B", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "7B", true)]
	public void Validation_ARequiresBQuantityReceived(decimal quantityReceived, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.NumberOfUnitsShipped = 6;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "Z0";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Hr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Z0", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Z0", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//At Least one
		subject.NumberOfUnitsShipped = 6;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Hr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Hr", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Hr", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//At Least one
		subject.NumberOfUnitsShipped = 6;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "Z0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0b", "e", true)]
	[InlineData("0b", "", false)]
	[InlineData("", "e", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.NumberOfUnitsShipped = 6;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "Z0";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Hr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
