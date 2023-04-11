using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IT8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT8*3*d*d*L*djz6WRYJ*Fa*t*h7*r*Ec*1*sw*s*8A*B*oQ*f*zR*N*vJ*v*Ef*F*Js*T*ha*o";

		var expected = new IT8_ConditionsOfSale()
		{
			SalesRequirementCode = "3",
			ActionCode = "d",
			Amount = "d",
			AccountNumber = "L",
			Date = "djz6WRYJ",
			AgencyQualifierCode = "Fa",
			ProductServiceSubstitutionCode = "t",
			ProductServiceIDQualifier = "h7",
			ProductServiceID = "r",
			ProductServiceIDQualifier2 = "Ec",
			ProductServiceID2 = "1",
			ProductServiceIDQualifier3 = "sw",
			ProductServiceID3 = "s",
			ProductServiceIDQualifier4 = "8A",
			ProductServiceID4 = "B",
			ProductServiceIDQualifier5 = "oQ",
			ProductServiceID5 = "f",
			ProductServiceIDQualifier6 = "zR",
			ProductServiceID6 = "N",
			ProductServiceIDQualifier7 = "vJ",
			ProductServiceID7 = "v",
			ProductServiceIDQualifier8 = "Ef",
			ProductServiceID8 = "F",
			ProductServiceIDQualifier9 = "Js",
			ProductServiceID9 = "T",
			ProductServiceIDQualifier10 = "ha",
			ProductServiceID10 = "o",
		};

		var actual = Map.MapObject<IT8_ConditionsOfSale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("h7", "r", true)]
	[InlineData("", "r", false)]
	[InlineData("h7", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ec", "1", true)]
	[InlineData("", "1", false)]
	[InlineData("Ec", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("sw", "s", true)]
	[InlineData("", "s", false)]
	[InlineData("sw", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("8A", "B", true)]
	[InlineData("", "B", false)]
	[InlineData("8A", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("oQ", "f", true)]
	[InlineData("", "f", false)]
	[InlineData("oQ", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("zR", "N", true)]
	[InlineData("", "N", false)]
	[InlineData("zR", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("vJ", "v", true)]
	[InlineData("", "v", false)]
	[InlineData("vJ", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ef", "F", true)]
	[InlineData("", "F", false)]
	[InlineData("Ef", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Js", "T", true)]
	[InlineData("", "T", false)]
	[InlineData("Js", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ha", "o", true)]
	[InlineData("", "o", false)]
	[InlineData("ha", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new IT8_ConditionsOfSale();
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
