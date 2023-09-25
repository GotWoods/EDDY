using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class AM1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AM1*Nk*kG*D*1*9*3";

		var expected = new AM1_InformationalValues()
		{
			CodeCategory = "Nk",
			ProductServiceIDQualifier = "kG",
			ProductServiceID = "D",
			MonetaryAmount = 1,
			Quantity = 9,
			PercentageAsDecimal = 3,
		};

		var actual = Map.MapObject<AM1_InformationalValues>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nk", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new AM1_InformationalValues();
		//Required fields
		subject.ProductServiceIDQualifier = "kG";
		subject.ProductServiceID = "D";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kG", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new AM1_InformationalValues();
		//Required fields
		subject.CodeCategory = "Nk";
		subject.ProductServiceID = "D";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new AM1_InformationalValues();
		//Required fields
		subject.CodeCategory = "Nk";
		subject.ProductServiceIDQualifier = "kG";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
