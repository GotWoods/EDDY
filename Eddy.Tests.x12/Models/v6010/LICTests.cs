using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class LICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIC*l3*jH*N*B*cU*X*vW*S";

		var expected = new LIC_LicenseInformation()
		{
			StateOrProvinceCode = "l3",
			ProductServiceIDQualifier = "jH",
			ProductServiceID = "N",
			YesNoConditionOrResponseCode = "B",
			StatusCode = "cU",
			ReferenceIdentification = "X",
			StateOrProvinceCode2 = "vW",
			ReferenceIdentification2 = "S",
		};

		var actual = Map.MapObject<LIC_LicenseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l3", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.ProductServiceIDQualifier = "jH";
		subject.ProductServiceID = "N";
		subject.YesNoConditionOrResponseCode = "B";
		subject.StatusCode = "cU";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jH", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "l3";
		subject.ProductServiceID = "N";
		subject.YesNoConditionOrResponseCode = "B";
		subject.StatusCode = "cU";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "l3";
		subject.ProductServiceIDQualifier = "jH";
		subject.YesNoConditionOrResponseCode = "B";
		subject.StatusCode = "cU";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "l3";
		subject.ProductServiceIDQualifier = "jH";
		subject.ProductServiceID = "N";
		subject.StatusCode = "cU";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cU", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "l3";
		subject.ProductServiceIDQualifier = "jH";
		subject.ProductServiceID = "N";
		subject.YesNoConditionOrResponseCode = "B";
		//Test Parameters
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "vW", true)]
	[InlineData("S", "", false)]
	[InlineData("", "vW", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "l3";
		subject.ProductServiceIDQualifier = "jH";
		subject.ProductServiceID = "N";
		subject.YesNoConditionOrResponseCode = "B";
		subject.StatusCode = "cU";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
