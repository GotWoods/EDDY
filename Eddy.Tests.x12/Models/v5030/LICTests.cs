using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class LICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIC*XA*nE*t*Y*Kl*R*Mm*l";

		var expected = new LIC_LicenseInformation()
		{
			StateOrProvinceCode = "XA",
			ProductServiceIDQualifier = "nE",
			ProductServiceID = "t",
			YesNoConditionOrResponseCode = "Y",
			StatusCode = "Kl",
			ReferenceIdentification = "R",
			StateOrProvinceCode2 = "Mm",
			ReferenceIdentification2 = "l",
		};

		var actual = Map.MapObject<LIC_LicenseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XA", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.ProductServiceIDQualifier = "nE";
		subject.ProductServiceID = "t";
		subject.YesNoConditionOrResponseCode = "Y";
		subject.StatusCode = "Kl";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nE", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "XA";
		subject.ProductServiceID = "t";
		subject.YesNoConditionOrResponseCode = "Y";
		subject.StatusCode = "Kl";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "XA";
		subject.ProductServiceIDQualifier = "nE";
		subject.YesNoConditionOrResponseCode = "Y";
		subject.StatusCode = "Kl";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "XA";
		subject.ProductServiceIDQualifier = "nE";
		subject.ProductServiceID = "t";
		subject.StatusCode = "Kl";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kl", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "XA";
		subject.ProductServiceIDQualifier = "nE";
		subject.ProductServiceID = "t";
		subject.YesNoConditionOrResponseCode = "Y";
		//Test Parameters
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "Mm", true)]
	[InlineData("l", "", false)]
	[InlineData("", "Mm", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new LIC_LicenseInformation();
		//Required fields
		subject.StateOrProvinceCode = "XA";
		subject.ProductServiceIDQualifier = "nE";
		subject.ProductServiceID = "t";
		subject.YesNoConditionOrResponseCode = "Y";
		subject.StatusCode = "Kl";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
