using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SLNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLN*n*C*Y*5*WP*7*1I*e*Ad*r*uk*V*qL*S*X6*X*Ak*v*QQ*p*Nt*M*2i*q*3G*1*QU*X";

		var expected = new SLN_SublineItemDetail()
		{
			AssignedIdentification = "n",
			AssignedIdentification2 = "C",
			ConfigurationCode = "Y",
			Quantity = 5,
			UnitOfMeasurementCode = "WP",
			UnitPrice = 7,
			BasisOfUnitPriceCode = "1I",
			SublinePriceChangeCodeID = "e",
			ProductServiceIDQualifier = "Ad",
			ProductServiceID = "r",
			ProductServiceIDQualifier2 = "uk",
			ProductServiceID2 = "V",
			ProductServiceIDQualifier3 = "qL",
			ProductServiceID3 = "S",
			ProductServiceIDQualifier4 = "X6",
			ProductServiceID4 = "X",
			ProductServiceIDQualifier5 = "Ak",
			ProductServiceID5 = "v",
			ProductServiceIDQualifier6 = "QQ",
			ProductServiceID6 = "p",
			ProductServiceIDQualifier7 = "Nt",
			ProductServiceID7 = "M",
			ProductServiceIDQualifier8 = "2i",
			ProductServiceID8 = "q",
			ProductServiceIDQualifier9 = "3G",
			ProductServiceID9 = "1",
			ProductServiceIDQualifier10 = "QU",
			ProductServiceID10 = "X",
		};

		var actual = Map.MapObject<SLN_SublineItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredConfigurationCode(string configurationCode, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.ConfigurationCode = configurationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WP", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("1I", 7, true)]
	[InlineData("1I", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("e", 7, true)]
	[InlineData("e", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBSublinePriceChangeCodeID(string sublinePriceChangeCodeID, decimal unitPrice, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.SublinePriceChangeCodeID = sublinePriceChangeCodeID;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ad", "r", true)]
	[InlineData("Ad", "", false)]
	[InlineData("", "r", true)]
	public void Validation_ARequiresBProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uk", "V", true)]
	[InlineData("uk", "", false)]
	[InlineData("", "V", true)]
	public void Validation_ARequiresBProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qL", "S", true)]
	[InlineData("qL", "", false)]
	[InlineData("", "S", true)]
	public void Validation_ARequiresBProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X6", "X", true)]
	[InlineData("X6", "", false)]
	[InlineData("", "X", true)]
	public void Validation_ARequiresBProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ak", "v", true)]
	[InlineData("Ak", "", false)]
	[InlineData("", "v", true)]
	public void Validation_ARequiresBProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QQ", "p", true)]
	[InlineData("QQ", "", false)]
	[InlineData("", "p", true)]
	public void Validation_ARequiresBProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Nt", "M", true)]
	[InlineData("Nt", "", false)]
	[InlineData("", "M", true)]
	public void Validation_ARequiresBProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2i", "q", true)]
	[InlineData("2i", "", false)]
	[InlineData("", "q", true)]
	public void Validation_ARequiresBProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3G", "1", true)]
	[InlineData("3G", "", false)]
	[InlineData("", "1", true)]
	public void Validation_ARequiresBProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QU", "X", true)]
	[InlineData("QU", "", false)]
	[InlineData("", "X", true)]
	public void Validation_ARequiresBProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "n";
		subject.ConfigurationCode = "Y";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "WP";
		//Test Parameters
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
