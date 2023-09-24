using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class G21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G21*z*8aw7sU*0QIn7gKVUsvm*n4nQSVG9mWLt*1*9*fb*O";

		var expected = new G21_ProductInformation()
		{
			AuthorizeDeAuthorizeCode = "z",
			Date = "8aw7sU",
			UPCEANConsumerPackageCode = "0QIn7gKVUsvm",
			UPCCaseCode = "n4nQSVG9mWLt",
			Pack = 1,
			UnitPrice = 9,
			ProductServiceIDQualifier = "fb",
			ProductServiceID = "O",
		};

		var actual = Map.MapObject<G21_ProductInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredAuthorizeDeAuthorizeCode(string authorizeDeAuthorizeCode, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.Date = "8aw7sU";
		subject.UPCEANConsumerPackageCode = "0QIn7gKVUsvm";
		subject.AuthorizeDeAuthorizeCode = authorizeDeAuthorizeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fb";
			subject.ProductServiceID = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8aw7sU", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "z";
		subject.UPCEANConsumerPackageCode = "0QIn7gKVUsvm";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fb";
			subject.ProductServiceID = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0QIn7gKVUsvm", true)]
	public void Validation_RequiredUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "z";
		subject.Date = "8aw7sU";
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fb";
			subject.ProductServiceID = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fb", "O", true)]
	[InlineData("fb", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "z";
		subject.Date = "8aw7sU";
		subject.UPCEANConsumerPackageCode = "0QIn7gKVUsvm";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
