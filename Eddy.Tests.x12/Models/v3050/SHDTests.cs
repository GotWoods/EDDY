using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SHDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHD*9*4*sA*3*JX*3*Y5*4*q*g*LU*fW*9C*o";

		var expected = new SHD_ShipmentDetail()
		{
			NumberOfUnitsShipped = 9,
			QuantityReceived = 4,
			UnitOrBasisForMeasurementCode = "sA",
			Weight = 3,
			UnitOrBasisForMeasurementCode2 = "JX",
			Volume = 3,
			UnitOrBasisForMeasurementCode3 = "Y5",
			EquivalentWeight = 4,
			PriceBracketIdentifier = "q",
			TransportationMethodTypeCode = "g",
			StandardCarrierAlphaCode = "LU",
			ShipmentOrderStatusCode = "fW",
			ReferenceNumberQualifier = "9C",
			ReferenceNumber = "o",
		};

		var actual = Map.MapObject<SHD_ShipmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "sA", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "sA", true)]
	public void Validation_ARequiresBNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 3;
			subject.UnitOrBasisForMeasurementCode2 = "JX";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Y5";
		}

        if (subject.NumberOfUnitsShipped == null)
        {
            subject.QuantityReceived = 1;
            subject.UnitOrBasisForMeasurementCode = "JX";
        }
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(9, 4, true)]
	[InlineData(9, 0, true)]
	[InlineData(0, 4, true)]
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
			subject.UnitOrBasisForMeasurementCode = "sA";
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 3;
			subject.UnitOrBasisForMeasurementCode2 = "JX";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Y5";
		}

        subject.UnitOrBasisForMeasurementCode = "JX";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "sA", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "sA", true)]
	public void Validation_ARequiresBQuantityReceived(decimal quantityReceived, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.NumberOfUnitsShipped = 9;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 3;
			subject.UnitOrBasisForMeasurementCode2 = "JX";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Y5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "JX", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "JX", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//At Least one
		subject.NumberOfUnitsShipped = 9;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Y5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Y5", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Y5", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//At Least one
		subject.NumberOfUnitsShipped = 9;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
        if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 3;
			subject.UnitOrBasisForMeasurementCode2 = "JX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9C", "o", true)]
	[InlineData("9C", "", false)]
	[InlineData("", "o", true)]
	public void Validation_ARequiresBReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//At Least one
		subject.NumberOfUnitsShipped = 9;
        subject.UnitOrBasisForMeasurementCode = "JX";
        //If one filled, all required
		if (subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 3;
			subject.UnitOrBasisForMeasurementCode2 = "JX";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "Y5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
