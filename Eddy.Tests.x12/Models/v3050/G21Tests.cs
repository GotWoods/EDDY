using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G21*1*YgxyQc*UgLoimu9raMM*sGHHDjZ9S19a*8*3*A7*G";

		var expected = new G21_ProductInformation()
		{
			AuthorizeDeAuthorizeCode = "1",
			Date = "YgxyQc",
			UPCEANConsumerPackageCode = "UgLoimu9raMM",
			UPCCaseCode = "sGHHDjZ9S19a",
			Pack = 8,
			UnitPrice = 3,
			ProductServiceIDQualifier = "A7",
			ProductServiceID = "G",
		};

		var actual = Map.MapObject<G21_ProductInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredAuthorizeDeAuthorizeCode(string authorizeDeAuthorizeCode, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.Date = "YgxyQc";
		subject.UPCEANConsumerPackageCode = "UgLoimu9raMM";
		subject.AuthorizeDeAuthorizeCode = authorizeDeAuthorizeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "A7";
			subject.ProductServiceID = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YgxyQc", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "1";
		subject.UPCEANConsumerPackageCode = "UgLoimu9raMM";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "A7";
			subject.ProductServiceID = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UgLoimu9raMM", true)]
	public void Validation_RequiredUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "1";
		subject.Date = "YgxyQc";
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "A7";
			subject.ProductServiceID = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A7", "G", true)]
	[InlineData("A7", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "1";
		subject.Date = "YgxyQc";
		subject.UPCEANConsumerPackageCode = "UgLoimu9raMM";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
