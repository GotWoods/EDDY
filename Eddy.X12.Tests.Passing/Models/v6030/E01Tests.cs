using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class E01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E01*Z*I*m*4";

		var expected = new E01_ElectronicFormMainHeading()
		{
			MaintenanceOperationCode = "Z",
			ElectronicFormStandardsTypeCode = "I",
			VersionReleaseIndustryIdentifierCode = "m",
			FullOrPartialIndicatorCode = "4",
		};

		var actual = Map.MapObject<E01_ElectronicFormMainHeading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E01_ElectronicFormMainHeading();
		subject.ElectronicFormStandardsTypeCode = "I";
		subject.VersionReleaseIndustryIdentifierCode = "m";
		subject.FullOrPartialIndicatorCode = "4";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredElectronicFormStandardsTypeCode(string electronicFormStandardsTypeCode, bool isValidExpected)
	{
		var subject = new E01_ElectronicFormMainHeading();
		subject.MaintenanceOperationCode = "Z";
		subject.VersionReleaseIndustryIdentifierCode = "m";
		subject.FullOrPartialIndicatorCode = "4";
		subject.ElectronicFormStandardsTypeCode = electronicFormStandardsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredVersionReleaseIndustryIdentifierCode(string versionReleaseIndustryIdentifierCode, bool isValidExpected)
	{
		var subject = new E01_ElectronicFormMainHeading();
		subject.MaintenanceOperationCode = "Z";
		subject.ElectronicFormStandardsTypeCode = "I";
		subject.FullOrPartialIndicatorCode = "4";
		subject.VersionReleaseIndustryIdentifierCode = versionReleaseIndustryIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredFullOrPartialIndicatorCode(string fullOrPartialIndicatorCode, bool isValidExpected)
	{
		var subject = new E01_ElectronicFormMainHeading();
		subject.MaintenanceOperationCode = "Z";
		subject.ElectronicFormStandardsTypeCode = "I";
		subject.VersionReleaseIndustryIdentifierCode = "m";
		subject.FullOrPartialIndicatorCode = fullOrPartialIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
