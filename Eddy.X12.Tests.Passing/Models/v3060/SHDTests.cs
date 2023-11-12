using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SHDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHD*1*6*ej*9*im*5*vF*5*l*d*Az*ON*it*t";

		var expected = new SHD_ShipmentDetail()
		{
			NumberOfUnitsShipped = 1,
			QuantityReceived = 6,
			UnitOrBasisForMeasurementCode = "ej",
			Weight = 9,
			UnitOrBasisForMeasurementCode2 = "im",
			Volume = 5,
			UnitOrBasisForMeasurementCode3 = "vF",
			OrderSizingFactor = 5,
			PriceBracketIdentifier = "l",
			TransportationMethodTypeCode = "d",
			StandardCarrierAlphaCode = "Az",
			ShipmentOrderStatusCode = "ON",
			ReferenceIdentificationQualifier = "it",
			ReferenceIdentification = "t",
		};

		var actual = Map.MapObject<SHD_ShipmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(1, "ej", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "ej", true)]
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
			subject.Weight = 9;
			subject.UnitOrBasisForMeasurementCode2 = "im";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode3 = "vF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(1, 6, true)]
	[InlineData(1, 0, true)]
	[InlineData(0, 6, true)]
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
			subject.UnitOrBasisForMeasurementCode = "ej";
        subject.UnitOrBasisForMeasurementCode = "JX";

        //If one filled, all required
        if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 9;
			subject.UnitOrBasisForMeasurementCode2 = "im";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode3 = "vF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "ej", true)]
	[InlineData(0, "ej", true)]
	public void Validation_ARequiresBQuantityReceived(decimal quantityReceived, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.NumberOfUnitsShipped = 1;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 9;
			subject.UnitOrBasisForMeasurementCode2 = "im";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode3 = "vF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "im", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "im", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//At Least one
		subject.NumberOfUnitsShipped = 1;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode3 = "vF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "vF", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "vF", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//At Least one
		subject.NumberOfUnitsShipped = 1;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 9;
			subject.UnitOrBasisForMeasurementCode2 = "im";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("it", "t", true)]
	[InlineData("it", "", false)]
	[InlineData("", "t", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.NumberOfUnitsShipped = 1;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 9;
			subject.UnitOrBasisForMeasurementCode2 = "im";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode3 = "vF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
