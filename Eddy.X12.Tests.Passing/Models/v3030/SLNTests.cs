using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SLNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLN*3*V*x*6*wE*7*bU*1*Un*o*1X*B*Cq*C*hl*P*g9*S*is*8*wz*L*XX*C*Pc*4*LF*S";

		var expected = new SLN_SublineItemDetail()
		{
			AssignedIdentification = "3",
			AssignedIdentification2 = "V",
			ConfigurationCode = "x",
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "wE",
			UnitPrice = 7,
			BasisOfUnitPriceCode = "bU",
			PriceRelationshipCode = "1",
			ProductServiceIDQualifier = "Un",
			ProductServiceID = "o",
			ProductServiceIDQualifier2 = "1X",
			ProductServiceID2 = "B",
			ProductServiceIDQualifier3 = "Cq",
			ProductServiceID3 = "C",
			ProductServiceIDQualifier4 = "hl",
			ProductServiceID4 = "P",
			ProductServiceIDQualifier5 = "g9",
			ProductServiceID5 = "S",
			ProductServiceIDQualifier6 = "is",
			ProductServiceID6 = "8",
			ProductServiceIDQualifier7 = "wz",
			ProductServiceID7 = "L",
			ProductServiceIDQualifier8 = "XX",
			ProductServiceID8 = "C",
			ProductServiceIDQualifier9 = "Pc",
			ProductServiceID9 = "4",
			ProductServiceIDQualifier10 = "LF",
			ProductServiceID10 = "S",
		};

		var actual = Map.MapObject<SLN_SublineItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredConfigurationCode(string configurationCode, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.ConfigurationCode = configurationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wE", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("bU", 7, true)]
	[InlineData("bU", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("1", 7, true)]
	[InlineData("1", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBPriceRelationshipCode(string priceRelationshipCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.PriceRelationshipCode = priceRelationshipCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Un", "o", true)]
	[InlineData("Un", "", false)]
	[InlineData("", "o", true)]
	public void Validation_ARequiresBProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1X", "B", true)]
	[InlineData("1X", "", false)]
	[InlineData("", "B", true)]
	public void Validation_ARequiresBProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Cq", "C", true)]
	[InlineData("Cq", "", false)]
	[InlineData("", "C", true)]
	public void Validation_ARequiresBProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hl", "P", true)]
	[InlineData("hl", "", false)]
	[InlineData("", "P", true)]
	public void Validation_ARequiresBProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g9", "S", true)]
	[InlineData("g9", "", false)]
	[InlineData("", "S", true)]
	public void Validation_ARequiresBProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("is", "8", true)]
	[InlineData("is", "", false)]
	[InlineData("", "8", true)]
	public void Validation_ARequiresBProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wz", "L", true)]
	[InlineData("wz", "", false)]
	[InlineData("", "L", true)]
	public void Validation_ARequiresBProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XX", "C", true)]
	[InlineData("XX", "", false)]
	[InlineData("", "C", true)]
	public void Validation_ARequiresBProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Pc", "4", true)]
	[InlineData("Pc", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LF", "S", true)]
	[InlineData("LF", "", false)]
	[InlineData("", "S", true)]
	public void Validation_ARequiresBProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "3";
		subject.ConfigurationCode = "x";
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "wE";
		//Test Parameters
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
