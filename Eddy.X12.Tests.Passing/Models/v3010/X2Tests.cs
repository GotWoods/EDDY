using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class X2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X2*hA8CgY*dRDxbr*D1zwq3";

		var expected = new X2_ImportLicense()
		{
			ImportLicenseNumber = "hA8CgY",
			ImportLicenseIssueDate = "dRDxbr",
			ImportLicenseExpirationDate = "D1zwq3",
		};

		var actual = Map.MapObject<X2_ImportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hA8CgY", true)]
	public void Validation_RequiredImportLicenseNumber(string importLicenseNumber, bool isValidExpected)
	{
		var subject = new X2_ImportLicense();
		//Required fields
		subject.ImportLicenseIssueDate = "dRDxbr";
		//Test Parameters
		subject.ImportLicenseNumber = importLicenseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dRDxbr", true)]
	public void Validation_RequiredImportLicenseIssueDate(string importLicenseIssueDate, bool isValidExpected)
	{
		var subject = new X2_ImportLicense();
		//Required fields
		subject.ImportLicenseNumber = "hA8CgY";
		//Test Parameters
		subject.ImportLicenseIssueDate = importLicenseIssueDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
