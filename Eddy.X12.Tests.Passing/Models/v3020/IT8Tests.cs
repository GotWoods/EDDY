using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class IT8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT8*O*6*fh*c*1tEnXq*OU*A*9X*8*zu*4*ba*b*0H*t*gR*8*MX*r*bG*q*JD*F*wA*d*2o*i";

		var expected = new IT8_ConditionsOfSale()
		{
			SalesRequirementCode = "O",
			DoNotExceedActionCode = "6",
			DoNotExceedAmount = "fh",
			AccountNumber = "c",
			RequiredInvoiceDate = "1tEnXq",
			AgencyQualifierCode = "OU",
			ProductServiceSubstitutionCode = "A",
			ProductServiceIDQualifier = "9X",
			ProductServiceID = "8",
			ProductServiceIDQualifier2 = "zu",
			ProductServiceID2 = "4",
			ProductServiceIDQualifier3 = "ba",
			ProductServiceID3 = "b",
			ProductServiceIDQualifier4 = "0H",
			ProductServiceID4 = "t",
			ProductServiceIDQualifier5 = "gR",
			ProductServiceID5 = "8",
			ProductServiceIDQualifier6 = "MX",
			ProductServiceID6 = "r",
			ProductServiceIDQualifier7 = "bG",
			ProductServiceID7 = "q",
			ProductServiceIDQualifier8 = "JD",
			ProductServiceID8 = "F",
			ProductServiceIDQualifier9 = "wA",
			ProductServiceID9 = "d",
			ProductServiceIDQualifier10 = "2o",
			ProductServiceID10 = "i",
		};

		var actual = Map.MapObject<IT8_ConditionsOfSale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9X", "8", true)]
	[InlineData("9X", "", false)]
	[InlineData("", "8", true)]
	public void Validation_ARequiresBProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zu", "4", true)]
	[InlineData("zu", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ba", "b", true)]
	[InlineData("ba", "", false)]
	[InlineData("", "b", true)]
	public void Validation_ARequiresBProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0H", "t", true)]
	[InlineData("0H", "", false)]
	[InlineData("", "t", true)]
	public void Validation_ARequiresBProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gR", "8", true)]
	[InlineData("gR", "", false)]
	[InlineData("", "8", true)]
	public void Validation_ARequiresBProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MX", "r", true)]
	[InlineData("MX", "", false)]
	[InlineData("", "r", true)]
	public void Validation_ARequiresBProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bG", "q", true)]
	[InlineData("bG", "", false)]
	[InlineData("", "q", true)]
	public void Validation_ARequiresBProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JD", "F", true)]
	[InlineData("JD", "", false)]
	[InlineData("", "F", true)]
	public void Validation_ARequiresBProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wA", "d", true)]
	[InlineData("wA", "", false)]
	[InlineData("", "d", true)]
	public void Validation_ARequiresBProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2o", "i", true)]
	[InlineData("2o", "", false)]
	[InlineData("", "i", true)]
	public void Validation_ARequiresBProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
