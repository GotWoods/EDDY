using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIC*T3*mT*m*x*Ra*s*ci*U";

		var expected = new LIC_LicenseInformation()
		{
			StateOrProvinceCode = "T3",
			ProductServiceIDQualifier = "mT",
			ProductServiceID = "m",
			YesNoConditionOrResponseCode = "x",
			StatusCode = "Ra",
			ReferenceIdentification = "s",
			StateOrProvinceCode2 = "ci",
			ReferenceIdentification2 = "U",
		};

		var actual = Map.MapObject<LIC_LicenseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T3", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.ProductServiceIDQualifier = "mT";
		subject.ProductServiceID = "m";
		subject.YesNoConditionOrResponseCode = "x";
		subject.StatusCode = "Ra";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mT", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "T3";
		subject.ProductServiceID = "m";
		subject.YesNoConditionOrResponseCode = "x";
		subject.StatusCode = "Ra";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "T3";
		subject.ProductServiceIDQualifier = "mT";
		subject.YesNoConditionOrResponseCode = "x";
		subject.StatusCode = "Ra";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "T3";
		subject.ProductServiceIDQualifier = "mT";
		subject.ProductServiceID = "m";
		subject.StatusCode = "Ra";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ra", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "T3";
		subject.ProductServiceIDQualifier = "mT";
		subject.ProductServiceID = "m";
		subject.YesNoConditionOrResponseCode = "x";
		//Test Parameters
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "ci", true)]
	[InlineData("U", "", false)]
	[InlineData("", "ci", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "T3";
		subject.ProductServiceIDQualifier = "mT";
		subject.ProductServiceID = "m";
		subject.YesNoConditionOrResponseCode = "x";
		subject.StatusCode = "Ra";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
