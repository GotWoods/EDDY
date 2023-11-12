using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class POCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "POC*a*YX*9*9*zz*8*GG*qv*a*BV*H*NL*j*r4*g*Kr*c*MH*J*Hc*e*LC*o*LR*p*bY*B";

		var expected = new POC_LineItemChange()
		{
			AssignedIdentification = "a",
			ChangeOrResponseTypeCode = "YX",
			QuantityOrdered = 9,
			QuantityLeftToReceive = 9,
			UnitOrBasisForMeasurementCode = "zz",
			UnitPrice = 8,
			BasisOfUnitPriceCode = "GG",
			ProductServiceIDQualifier = "qv",
			ProductServiceID = "a",
			ProductServiceIDQualifier2 = "BV",
			ProductServiceID2 = "H",
			ProductServiceIDQualifier3 = "NL",
			ProductServiceID3 = "j",
			ProductServiceIDQualifier4 = "r4",
			ProductServiceID4 = "g",
			ProductServiceIDQualifier5 = "Kr",
			ProductServiceID5 = "c",
			ProductServiceIDQualifier6 = "MH",
			ProductServiceID6 = "J",
			ProductServiceIDQualifier7 = "Hc",
			ProductServiceID7 = "e",
			ProductServiceIDQualifier8 = "LC",
			ProductServiceID8 = "o",
			ProductServiceIDQualifier9 = "LR",
			ProductServiceID9 = "p",
			ProductServiceIDQualifier10 = "bY",
			ProductServiceID10 = "B",
		};

		var actual = Map.MapObject<POC_LineItemChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YX", true)]
	public void Validation_RequiredChangeOrResponseTypeCode(string changeOrResponseTypeCode, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		//Test Parameters
		subject.ChangeOrResponseTypeCode = changeOrResponseTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("GG", 8, true)]
	[InlineData("GG", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "YX";
		//Test Parameters
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qv", "a", true)]
	[InlineData("qv", "", false)]
	[InlineData("", "a", true)]
	public void Validation_ARequiresBProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "YX";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BV", "H", true)]
	[InlineData("BV", "", false)]
	[InlineData("", "H", true)]
	public void Validation_ARequiresBProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "YX";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("NL", "j", true)]
	[InlineData("NL", "", false)]
	[InlineData("", "j", true)]
	public void Validation_ARequiresBProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "YX";
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r4", "g", true)]
	[InlineData("r4", "", false)]
	[InlineData("", "g", true)]
	public void Validation_ARequiresBProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "YX";
		//Test Parameters
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Kr", "c", true)]
	[InlineData("Kr", "", false)]
	[InlineData("", "c", true)]
	public void Validation_ARequiresBProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "YX";
		//Test Parameters
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MH", "J", true)]
	[InlineData("MH", "", false)]
	[InlineData("", "J", true)]
	public void Validation_ARequiresBProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "YX";
		//Test Parameters
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Hc", "e", true)]
	[InlineData("Hc", "", false)]
	[InlineData("", "e", true)]
	public void Validation_ARequiresBProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "YX";
		//Test Parameters
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LC", "o", true)]
	[InlineData("LC", "", false)]
	[InlineData("", "o", true)]
	public void Validation_ARequiresBProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "YX";
		//Test Parameters
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LR", "p", true)]
	[InlineData("LR", "", false)]
	[InlineData("", "p", true)]
	public void Validation_ARequiresBProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "YX";
		//Test Parameters
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bY", "B", true)]
	[InlineData("bY", "", false)]
	[InlineData("", "B", true)]
	public void Validation_ARequiresBProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "YX";
		//Test Parameters
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
