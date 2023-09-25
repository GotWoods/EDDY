using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SV5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV5*ns*4*Zd*9*3*1";

		var expected = new SV5_DurableMedicalEquipmentService()
		{
			ProductServiceIDQualifier = "ns",
			ProductServiceID = "4",
			UnitOrBasisForMeasurementCode = "Zd",
			Quantity = 9,
			MonetaryAmount = 3,
			MonetaryAmount2 = 1,
		};

		var actual = Map.MapObject<SV5_DurableMedicalEquipmentService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ns", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		//Required fields
		subject.ProductServiceID = "4";
		subject.UnitOrBasisForMeasurementCode = "Zd";
		subject.Quantity = 9;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//At Least one
		subject.MonetaryAmount = 3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		//Required fields
		subject.ProductServiceIDQualifier = "ns";
		subject.UnitOrBasisForMeasurementCode = "Zd";
		subject.Quantity = 9;
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.MonetaryAmount = 3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zd", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		//Required fields
		subject.ProductServiceIDQualifier = "ns";
		subject.ProductServiceID = "4";
		subject.Quantity = 9;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.MonetaryAmount = 3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		//Required fields
		subject.ProductServiceIDQualifier = "ns";
		subject.ProductServiceID = "4";
		subject.UnitOrBasisForMeasurementCode = "Zd";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.MonetaryAmount = 3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(3, 1, true)]
	[InlineData(3, 0, true)]
	[InlineData(0, 1, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		//Required fields
		subject.ProductServiceIDQualifier = "ns";
		subject.ProductServiceID = "4";
		subject.UnitOrBasisForMeasurementCode = "Zd";
		subject.Quantity = 9;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
