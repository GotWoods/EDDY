using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT1*x*7*G5*1*Xd*Gy*x*BH*Z*UD*G*dS*j*6E*G*SB*O*pE*t*Mv*Z*pt*H*Tc*r";

		var expected = new IT1_BaselineItemDataInvoice()
		{
			AssignedIdentification = "x",
			QuantityInvoiced = 7,
			UnitOrBasisForMeasurementCode = "G5",
			UnitPrice = 1,
			BasisOfUnitPriceCode = "Xd",
			ProductServiceIDQualifier = "Gy",
			ProductServiceID = "x",
			ProductServiceIDQualifier2 = "BH",
			ProductServiceID2 = "Z",
			ProductServiceIDQualifier3 = "UD",
			ProductServiceID3 = "G",
			ProductServiceIDQualifier4 = "dS",
			ProductServiceID4 = "j",
			ProductServiceIDQualifier5 = "6E",
			ProductServiceID5 = "G",
			ProductServiceIDQualifier6 = "SB",
			ProductServiceID6 = "O",
			ProductServiceIDQualifier7 = "pE",
			ProductServiceID7 = "t",
			ProductServiceIDQualifier8 = "Mv",
			ProductServiceID8 = "Z",
			ProductServiceIDQualifier9 = "pt",
			ProductServiceID9 = "H",
			ProductServiceIDQualifier10 = "Tc",
			ProductServiceID10 = "r",
		};

		var actual = Map.MapObject<IT1_BaselineItemDataInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Gy", "x", true)]
	[InlineData("", "x", false)]
	[InlineData("Gy", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("BH", "Z", true)]
	[InlineData("", "Z", false)]
	[InlineData("BH", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("UD", "G", true)]
	[InlineData("", "G", false)]
	[InlineData("UD", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("dS", "j", true)]
	[InlineData("", "j", false)]
	[InlineData("dS", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("6E", "G", true)]
	[InlineData("", "G", false)]
	[InlineData("6E", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("SB", "O", true)]
	[InlineData("", "O", false)]
	[InlineData("SB", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("pE", "t", true)]
	[InlineData("", "t", false)]
	[InlineData("pE", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Mv", "Z", true)]
	[InlineData("", "Z", false)]
	[InlineData("Mv", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("pt", "H", true)]
	[InlineData("", "H", false)]
	[InlineData("pt", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Tc", "r", true)]
	[InlineData("", "r", false)]
	[InlineData("Tc", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
