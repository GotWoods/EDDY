using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class LICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIC*YL*NM*O*A*vv*E*EQ*J";

		var expected = new LIC_LicenseInformation()
		{
			StateOrProvinceCode = "YL",
			ProductServiceIDQualifier = "NM",
			ProductServiceID = "O",
			YesNoConditionOrResponseCode = "A",
			StatusCode = "vv",
			ReferenceIdentification = "E",
			StateOrProvinceCode2 = "EQ",
			ReferenceIdentification2 = "J",
		};

		var actual = Map.MapObject<LIC_LicenseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YL", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.ProductServiceIDQualifier = "NM";
		subject.ProductServiceID = "O";
		subject.YesNoConditionOrResponseCode = "A";
		subject.StatusCode = "vv";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NM", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "YL";
		subject.ProductServiceID = "O";
		subject.YesNoConditionOrResponseCode = "A";
		subject.StatusCode = "vv";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "YL";
		subject.ProductServiceIDQualifier = "NM";
		subject.YesNoConditionOrResponseCode = "A";
		subject.StatusCode = "vv";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "YL";
		subject.ProductServiceIDQualifier = "NM";
		subject.ProductServiceID = "O";
		subject.StatusCode = "vv";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vv", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "YL";
		subject.ProductServiceIDQualifier = "NM";
		subject.ProductServiceID = "O";
		subject.YesNoConditionOrResponseCode = "A";
		//Test Parameters
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "EQ", true)]
	[InlineData("J", "", false)]
	[InlineData("", "EQ", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "YL";
		subject.ProductServiceIDQualifier = "NM";
		subject.ProductServiceID = "O";
		subject.YesNoConditionOrResponseCode = "A";
		subject.StatusCode = "vv";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
