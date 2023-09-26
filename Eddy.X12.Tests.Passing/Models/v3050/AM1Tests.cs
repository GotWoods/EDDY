using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class AM1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AM1*ER*hd*M*2*8";

		var expected = new AM1_InformationalValues()
		{
			CodeCategory = "ER",
			ProductServiceIDQualifier = "hd",
			ProductServiceID = "M",
			MonetaryAmount = 2,
			Quantity = 8,
		};

		var actual = Map.MapObject<AM1_InformationalValues>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ER", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new AM1_InformationalValues();
		//Required fields
		subject.ProductServiceIDQualifier = "hd";
		subject.ProductServiceID = "M";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hd", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new AM1_InformationalValues();
		//Required fields
		subject.CodeCategory = "ER";
		subject.ProductServiceID = "M";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new AM1_InformationalValues();
		//Required fields
		subject.CodeCategory = "ER";
		subject.ProductServiceIDQualifier = "hd";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
