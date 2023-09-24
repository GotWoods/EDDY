using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class G21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G21*O*3G4vHwrd*FLdsorcH7RjD*7jMajdCcXuZr*8*6*gq*3*6*6F";

		var expected = new G21_ProductInformation()
		{
			AuthorizeDeAuthorizeCode = "O",
			Date = "3G4vHwrd",
			UPCEANConsumerPackageCode = "FLdsorcH7RjD",
			UPCCaseCode = "7jMajdCcXuZr",
			Pack = 8,
			UnitPrice = 6,
			ProductServiceIDQualifier = "gq",
			ProductServiceID = "3",
			InnerPack = 6,
			ItemDistributionCode = "6F",
		};

		var actual = Map.MapObject<G21_ProductInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredAuthorizeDeAuthorizeCode(string authorizeDeAuthorizeCode, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.Date = "3G4vHwrd";
		subject.UPCEANConsumerPackageCode = "FLdsorcH7RjD";
		subject.AuthorizeDeAuthorizeCode = authorizeDeAuthorizeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gq";
			subject.ProductServiceID = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3G4vHwrd", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "O";
		subject.UPCEANConsumerPackageCode = "FLdsorcH7RjD";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gq";
			subject.ProductServiceID = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FLdsorcH7RjD", true)]
	public void Validation_RequiredUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "O";
		subject.Date = "3G4vHwrd";
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "gq";
			subject.ProductServiceID = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gq", "3", true)]
	[InlineData("gq", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "O";
		subject.Date = "3G4vHwrd";
		subject.UPCEANConsumerPackageCode = "FLdsorcH7RjD";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
