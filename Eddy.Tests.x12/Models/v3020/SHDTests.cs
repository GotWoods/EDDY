using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SHDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHD*5*7*MF*8*Pe*4*7d*5*5*d*2c*Fb*Lf*J";

		var expected = new SHD_ShipmentDetail()
		{
			NumberOfUnitsShipped = 5,
			QuantityReceived = 7,
			UnitOfMeasurementCode = "MF",
			Weight = 8,
			UnitOfMeasurementCode2 = "Pe",
			Volume = 4,
			UnitOfMeasurementCode3 = "7d",
			EquivalentWeight = 5,
			PriceBracketIdentifier = "5",
			TransportationMethodTypeCode = "d",
			StandardCarrierAlphaCode = "2c",
			ShipmentOrderStatusCode = "Fb",
			ReferenceNumberQualifier = "Lf",
			ReferenceNumber = "J",
		};

		var actual = Map.MapObject<SHD_ShipmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "MF", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "MF", true)]
	public void Validation_ARequiresBNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;

        if (subject.NumberOfUnitsShipped == null)
        {
            subject.QuantityReceived = 1;
            subject.UnitOfMeasurementCode = "AB";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(5, 7, true)]
	[InlineData(5, 0, true)]
	[InlineData(0, 7, true)]
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
			subject.UnitOfMeasurementCode = "MF";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "MF", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "MF", true)]
	public void Validation_ARequiresBQuantityReceived(decimal quantityReceived, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//At Least one
		subject.NumberOfUnitsShipped = 5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "Pe", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "Pe", true)]
	public void Validation_ARequiresBWeight(decimal weight, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//At Least one
		subject.NumberOfUnitsShipped = 5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "7d", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "7d", true)]
	public void Validation_ARequiresBVolume(decimal volume, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		//At Least one
		subject.NumberOfUnitsShipped = 5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Lf", "J", true)]
	[InlineData("Lf", "", false)]
	[InlineData("", "J", true)]
	public void Validation_ARequiresBReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new SHD_ShipmentDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//At Least one
		subject.NumberOfUnitsShipped = 5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
