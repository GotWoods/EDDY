using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class X2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X2*IOjl0u*9spNWK*1uGmKt*tNZBku*QiJRbJ*Joc9Vx";

		var expected = new X2_ImportLicense()
		{
			ImportLicenseNumber = "IOjl0u",
			ImportLicenseIssueDate = "9spNWK",
			ImportLicenseExpirationDate = "1uGmKt",
			ImportLicenseNumber2 = "tNZBku",
			ImportLicenseIssueDate2 = "QiJRbJ",
			ImportLicenseExpirationDate2 = "Joc9Vx",
		};

		var actual = Map.MapObject<X2_ImportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IOjl0u", true)]
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
	[InlineData("QiJRbJ", "tNZBku", true)]
	[InlineData("QiJRbJ", "", false)]
	[InlineData("", "tNZBku", true)]
	public void Validation_ARequiresBImportLicenseIssueDate2(string importLicenseIssueDate2, string importLicenseNumber2, bool isValidExpected)
	{
		var subject = new X2_ImportLicense();
		//Required fields
		subject.ImportLicenseNumber = "IOjl0u";
		//Test Parameters
		subject.ImportLicenseIssueDate2 = importLicenseIssueDate2;
		subject.ImportLicenseNumber2 = importLicenseNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Joc9Vx", "tNZBku", true)]
	[InlineData("Joc9Vx", "", false)]
	[InlineData("", "tNZBku", true)]
	public void Validation_ARequiresBImportLicenseExpirationDate2(string importLicenseExpirationDate2, string importLicenseNumber2, bool isValidExpected)
	{
		var subject = new X2_ImportLicense();
		//Required fields
		subject.ImportLicenseNumber = "IOjl0u";
		//Test Parameters
		subject.ImportLicenseExpirationDate2 = importLicenseExpirationDate2;
		subject.ImportLicenseNumber2 = importLicenseNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
