using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class X2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X2*b1Hrpk*8xhOAe*Qe2Dy5*bNp9Hc*5bLpk4*e6R87T";

		var expected = new X2_ImportLicense()
		{
			ImportLicenseNumber = "b1Hrpk",
			Date = "8xhOAe",
			Date2 = "Qe2Dy5",
			ImportLicenseNumber2 = "bNp9Hc",
			Date3 = "5bLpk4",
			Date4 = "e6R87T",
		};

		var actual = Map.MapObject<X2_ImportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b1Hrpk", true)]
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
	[InlineData("5bLpk4", "bNp9Hc", true)]
	[InlineData("5bLpk4", "", false)]
	[InlineData("", "bNp9Hc", true)]
	public void Validation_ARequiresBDate3(string date3, string importLicenseNumber2, bool isValidExpected)
	{
		var subject = new X2_ImportLicense();
		//Required fields
		subject.ImportLicenseNumber = "b1Hrpk";
		//Test Parameters
		subject.Date3 = date3;
		subject.ImportLicenseNumber2 = importLicenseNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e6R87T", "bNp9Hc", true)]
	[InlineData("e6R87T", "", false)]
	[InlineData("", "bNp9Hc", true)]
	public void Validation_ARequiresBDate4(string date4, string importLicenseNumber2, bool isValidExpected)
	{
		var subject = new X2_ImportLicense();
		//Required fields
		subject.ImportLicenseNumber = "b1Hrpk";
		//Test Parameters
		subject.Date4 = date4;
		subject.ImportLicenseNumber2 = importLicenseNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
