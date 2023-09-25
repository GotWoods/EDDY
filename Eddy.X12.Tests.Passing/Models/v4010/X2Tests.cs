using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class X2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X2*wyzL8N*reUDe8w2*spSknlL4*QurPFj*3adPwqAp*oYKoOlLf";

		var expected = new X2_ImportLicense()
		{
			ImportLicenseNumber = "wyzL8N",
			Date = "reUDe8w2",
			Date2 = "spSknlL4",
			ImportLicenseNumber2 = "QurPFj",
			Date3 = "3adPwqAp",
			Date4 = "oYKoOlLf",
		};

		var actual = Map.MapObject<X2_ImportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wyzL8N", true)]
	public void Validation_RequiredImportLicenseNumber(string importLicenseNumber, bool isValidExpected)
	{
		var subject = new X2_ImportLicense();
		//Required fields
		//Test Parameters
		subject.ImportLicenseNumber = importLicenseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3adPwqAp", "QurPFj", true)]
	[InlineData("3adPwqAp", "", false)]
	[InlineData("", "QurPFj", true)]
	public void Validation_ARequiresBDate3(string date3, string importLicenseNumber2, bool isValidExpected)
	{
		var subject = new X2_ImportLicense();
		//Required fields
		subject.ImportLicenseNumber = "wyzL8N";
		//Test Parameters
		subject.Date3 = date3;
		subject.ImportLicenseNumber2 = importLicenseNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oYKoOlLf", "QurPFj", true)]
	[InlineData("oYKoOlLf", "", false)]
	[InlineData("", "QurPFj", true)]
	public void Validation_ARequiresBDate4(string date4, string importLicenseNumber2, bool isValidExpected)
	{
		var subject = new X2_ImportLicense();
		//Required fields
		subject.ImportLicenseNumber = "wyzL8N";
		//Test Parameters
		subject.Date4 = date4;
		subject.ImportLicenseNumber2 = importLicenseNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
