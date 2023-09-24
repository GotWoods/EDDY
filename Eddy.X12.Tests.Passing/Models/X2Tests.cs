using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class X2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X2*5PyGJ2*75tnMKlw*b7el7v4z*LhPHtt*q08Fs74p*eRf9rmvF";

		var expected = new X2_ImportLicense()
		{
			ImportLicenseNumber = "5PyGJ2",
			Date = "75tnMKlw",
			Date2 = "b7el7v4z",
			ImportLicenseNumber2 = "LhPHtt",
			Date3 = "q08Fs74p",
			Date4 = "eRf9rmvF",
		};

		var actual = Map.MapObject<X2_ImportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5PyGJ2", true)]
	public void Validation_RequiredImportLicenseNumber(string importLicenseNumber, bool isValidExpected)
	{
		var subject = new X2_ImportLicense();
		subject.ImportLicenseNumber = importLicenseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "LhPHtt", true)]
	[InlineData("q08Fs74p", "", false)]
	public void Validation_ARequiresBDate3(string date3, string importLicenseNumber2, bool isValidExpected)
	{
		var subject = new X2_ImportLicense();
		subject.ImportLicenseNumber = "5PyGJ2";
		subject.Date3 = date3;
		subject.ImportLicenseNumber2 = importLicenseNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "LhPHtt", true)]
	[InlineData("eRf9rmvF", "", false)]
	public void Validation_ARequiresBDate4(string date4, string importLicenseNumber2, bool isValidExpected)
	{
		var subject = new X2_ImportLicense();
		subject.ImportLicenseNumber = "5PyGJ2";
		subject.Date4 = date4;
		subject.ImportLicenseNumber2 = importLicenseNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
