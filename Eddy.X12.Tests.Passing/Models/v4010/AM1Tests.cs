using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class AM1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AM1*Bz*35*F*9*7*5";

		var expected = new AM1_InformationalValues()
		{
			CodeCategory = "Bz",
			ProductServiceIDQualifier = "35",
			ProductServiceID = "F",
			MonetaryAmount = 9,
			Quantity = 7,
			Percent = 5,
		};

		var actual = Map.MapObject<AM1_InformationalValues>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bz", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new AM1_InformationalValues();
		//Required fields
		subject.ProductServiceIDQualifier = "35";
		subject.ProductServiceID = "F";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("35", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new AM1_InformationalValues();
		//Required fields
		subject.CodeCategory = "Bz";
		subject.ProductServiceID = "F";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new AM1_InformationalValues();
		//Required fields
		subject.CodeCategory = "Bz";
		subject.ProductServiceIDQualifier = "35";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
