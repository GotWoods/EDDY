using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class AM1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AM1*ce*Im*l*3*2";

		var expected = new AM1_InformationalValues()
		{
			CodeCategory = "ce",
			ProductServiceIDQualifier = "Im",
			ProductServiceID = "l",
			MonetaryAmount = 3,
			Quantity = 2,
		};

		var actual = Map.MapObject<AM1_InformationalValues>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ce", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new AM1_InformationalValues();
		//Required fields
		subject.ProductServiceIDQualifier = "Im";
		subject.ProductServiceID = "l";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Im", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new AM1_InformationalValues();
		//Required fields
		subject.CodeCategory = "ce";
		subject.ProductServiceID = "l";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new AM1_InformationalValues();
		//Required fields
		subject.CodeCategory = "ce";
		subject.ProductServiceIDQualifier = "Im";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
