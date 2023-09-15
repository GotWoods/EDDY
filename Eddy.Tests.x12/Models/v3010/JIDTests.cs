using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class JIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JID*pp*q*9*R4*Nw*4";

		var expected = new JID_EquipmentDetail()
		{
			ProductServiceIDQualifier = "pp",
			ProductServiceID = "q",
			Quantity = 9,
			UnitOfMeasurementCode = "R4",
			ProductServiceConditionCode = "Nw",
			MonetaryAmount = 4,
		};

		var actual = Map.MapObject<JID_EquipmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pp", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new JID_EquipmentDetail();
		subject.ProductServiceID = "q";
		subject.Quantity = 9;
		subject.UnitOfMeasurementCode = "R4";
		subject.ProductServiceConditionCode = "Nw";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new JID_EquipmentDetail();
		subject.ProductServiceIDQualifier = "pp";
		subject.Quantity = 9;
		subject.UnitOfMeasurementCode = "R4";
		subject.ProductServiceConditionCode = "Nw";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new JID_EquipmentDetail();
		subject.ProductServiceIDQualifier = "pp";
		subject.ProductServiceID = "q";
		subject.UnitOfMeasurementCode = "R4";
		subject.ProductServiceConditionCode = "Nw";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R4", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new JID_EquipmentDetail();
		subject.ProductServiceIDQualifier = "pp";
		subject.ProductServiceID = "q";
		subject.Quantity = 9;
		subject.ProductServiceConditionCode = "Nw";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nw", true)]
	public void Validation_RequiredProductServiceConditionCode(string productServiceConditionCode, bool isValidExpected)
	{
		var subject = new JID_EquipmentDetail();
		subject.ProductServiceIDQualifier = "pp";
		subject.ProductServiceID = "q";
		subject.Quantity = 9;
		subject.UnitOfMeasurementCode = "R4";
		subject.ProductServiceConditionCode = productServiceConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
