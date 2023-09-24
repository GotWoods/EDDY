using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G21*E*gDfXkBdG*hGI4nXyxY8nD*9E6PB2tnDBjy*6*3*b5*Y*6*q4";

		var expected = new G21_ProductInformation()
		{
			AuthorizeDeAuthorizeCode = "E",
			Date = "gDfXkBdG",
			UPCEANConsumerPackageCode = "hGI4nXyxY8nD",
			UPCCaseCode = "9E6PB2tnDBjy",
			Pack = 6,
			UnitPrice = 3,
			ProductServiceIDQualifier = "b5",
			ProductServiceID = "Y",
			InnerPack = 6,
			ItemDistributionCode = "q4",
		};

		var actual = Map.MapObject<G21_ProductInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredAuthorizeDeAuthorizeCode(string authorizeDeAuthorizeCode, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.Date = "gDfXkBdG";
		subject.UPCEANConsumerPackageCode = "hGI4nXyxY8nD";
		subject.AuthorizeDeAuthorizeCode = authorizeDeAuthorizeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gDfXkBdG", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "E";
		subject.UPCEANConsumerPackageCode = "hGI4nXyxY8nD";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hGI4nXyxY8nD", true)]
	public void Validation_RequiredUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "E";
		subject.Date = "gDfXkBdG";
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("b5", "Y", true)]
	[InlineData("", "Y", false)]
	[InlineData("b5", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "E";
		subject.Date = "gDfXkBdG";
		subject.UPCEANConsumerPackageCode = "hGI4nXyxY8nD";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
