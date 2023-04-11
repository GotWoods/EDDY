using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FU5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FU5*Ur*N*k2*k*Gz*z*A3*R*I*h*Y*t8*d";

		var expected = new FU5_CoProductInformation()
		{
			CoProductTypeCode = "Ur",
			ProductName = "N",
			ProductServiceIDQualifier = "k2",
			ProductServiceID = "k",
			ProductServiceIDQualifier2 = "Gz",
			ProductServiceID2 = "z",
			ProductServiceIDQualifier3 = "A3",
			ProductServiceID3 = "R",
			BrandName = "I",
			ProductLabel = "h",
			Description = "Y",
			EntityIdentifierCode = "t8",
			Name = "d",
		};

		var actual = Map.MapObject<FU5_CoProductInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ur", true)]
	public void Validation_RequiredCoProductTypeCode(string coProductTypeCode, bool isValidExpected)
	{
		var subject = new FU5_CoProductInformation();
		subject.ProductName = "N";
		subject.CoProductTypeCode = coProductTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredProductName(string productName, bool isValidExpected)
	{
		var subject = new FU5_CoProductInformation();
		subject.CoProductTypeCode = "Ur";
		subject.ProductName = productName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("k2", "k", true)]
	[InlineData("", "k", false)]
	[InlineData("k2", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new FU5_CoProductInformation();
		subject.CoProductTypeCode = "Ur";
		subject.ProductName = "N";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Gz", "z", true)]
	[InlineData("", "z", false)]
	[InlineData("Gz", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new FU5_CoProductInformation();
		subject.CoProductTypeCode = "Ur";
		subject.ProductName = "N";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("A3", "R", true)]
	[InlineData("", "R", false)]
	[InlineData("A3", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new FU5_CoProductInformation();
		subject.CoProductTypeCode = "Ur";
		subject.ProductName = "N";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("t8", "d", true)]
	[InlineData("", "d", false)]
	[InlineData("t8", "", false)]
	public void Validation_AllAreRequiredEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new FU5_CoProductInformation();
		subject.CoProductTypeCode = "Ur";
		subject.ProductName = "N";
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
