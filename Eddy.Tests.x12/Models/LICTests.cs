using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIC*oQ*kb*U*J*mt*d*nE*J";

		var expected = new LIC_LicenseInformation()
		{
			StateOrProvinceCode = "oQ",
			ProductServiceIDQualifier = "kb",
			ProductServiceID = "U",
			YesNoConditionOrResponseCode = "J",
			StatusCode = "mt",
			ReferenceIdentification = "d",
			StateOrProvinceCode2 = "nE",
			ReferenceIdentification2 = "J",
		};

		var actual = Map.MapObject<LIC_LicenseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oQ", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		subject.ProductServiceIDQualifier = "kb";
		subject.ProductServiceID = "U";
		subject.YesNoConditionOrResponseCode = "J";
		subject.StatusCode = "mt";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kb", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		subject.StateOrProvinceCode = "oQ";
		subject.ProductServiceID = "U";
		subject.YesNoConditionOrResponseCode = "J";
		subject.StatusCode = "mt";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		subject.StateOrProvinceCode = "oQ";
		subject.ProductServiceIDQualifier = "kb";
		subject.YesNoConditionOrResponseCode = "J";
		subject.StatusCode = "mt";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		subject.StateOrProvinceCode = "oQ";
		subject.ProductServiceIDQualifier = "kb";
		subject.ProductServiceID = "U";
		subject.StatusCode = "mt";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mt", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		subject.StateOrProvinceCode = "oQ";
		subject.ProductServiceIDQualifier = "kb";
		subject.ProductServiceID = "U";
		subject.YesNoConditionOrResponseCode = "J";
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "nE", true)]
	[InlineData("J", "", false)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		subject.StateOrProvinceCode = "oQ";
		subject.ProductServiceIDQualifier = "kb";
		subject.ProductServiceID = "U";
		subject.YesNoConditionOrResponseCode = "J";
		subject.StatusCode = "mt";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
