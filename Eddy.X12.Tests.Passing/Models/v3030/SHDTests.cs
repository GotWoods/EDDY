using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SHDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHD*8*8*GH*6*Sy*8*4w*1*g*5*w9*Ji*YR*l";

		var expected = new SHD_ShipmentDetail()
		{
			NumberOfUnitsShipped = 8,
			QuantityReceived = 8,
			UnitOrBasisForMeasurementCode = "GH",
			Weight = 6,
			UnitOrBasisForMeasurementCode2 = "Sy",
			Volume = 8,
			UnitOrBasisForMeasurementCode3 = "4w",
			EquivalentWeight = 1,
			PriceBracketIdentifier = "g",
			TransportationMethodTypeCode = "5",
			StandardCarrierAlphaCode = "w9",
			ShipmentOrderStatusCode = "Ji",
			ReferenceNumberQualifier = "YR",
			ReferenceNumber = "l",
		};

		var actual = Map.MapObject<SHD_ShipmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(8, "GH", true)]
	[InlineData(0, "GH", true)]
	public void Validation_ARequiresBNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;

        if (subject.NumberOfUnitsShipped == null)
        {
            subject.QuantityReceived = 1;
         //   subject.UnitOrBasisForMeasurementCode = "AB";
        }

        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(8, 8, true)]
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
		//A Requires B
		if (quantityReceived > 0)
			subject.UnitOrBasisForMeasurementCode = "GH";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(8, "GH", true)]
	[InlineData(0, "GH", true)]
	public void Validation_ARequiresBQuantityReceived(decimal quantityReceived, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		//At Least one
		subject.NumberOfUnitsShipped = 8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(6, "Sy", true)]
	[InlineData(0, "Sy", true)]
	public void Validation_ARequiresBWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//At Least one
		subject.NumberOfUnitsShipped = 8;
        subject.UnitOrBasisForMeasurementCode = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "4w", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "4w", true)]
	public void Validation_ARequiresBVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//At Least one
		subject.NumberOfUnitsShipped = 8;
        subject.UnitOrBasisForMeasurementCode = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("YR", "l", true)]
	[InlineData("YR", "", false)]
	[InlineData("", "l", true)]
	public void Validation_ARequiresBReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//At Least one
		subject.NumberOfUnitsShipped = 8;

        subject.UnitOrBasisForMeasurementCode = "AB";
        if (subject.NumberOfUnitsShipped == null)
        {
            subject.QuantityReceived = 1;
          
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
