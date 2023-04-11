using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class E01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E01*P*7*4*1";

		var expected = new E01_ElectronicFormMainHeading()
		{
			MaintenanceOperationCode = "P",
			ElectronicFormStandardsTypeCode = "7",
			VersionReleaseIndustryIdentifierCode = "4",
			FullOrPartialIndicatorCode = "1",
		};

		var actual = Map.MapObject<E01_ElectronicFormMainHeading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validatation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E01_ElectronicFormMainHeading();
		subject.ElectronicFormStandardsTypeCode = "7";
		subject.VersionReleaseIndustryIdentifierCode = "4";
		subject.FullOrPartialIndicatorCode = "1";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validatation_RequiredElectronicFormStandardsTypeCode(string electronicFormStandardsTypeCode, bool isValidExpected)
	{
		var subject = new E01_ElectronicFormMainHeading();
		subject.MaintenanceOperationCode = "P";
		subject.VersionReleaseIndustryIdentifierCode = "4";
		subject.FullOrPartialIndicatorCode = "1";
		subject.ElectronicFormStandardsTypeCode = electronicFormStandardsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validatation_RequiredVersionReleaseIndustryIdentifierCode(string versionReleaseIndustryIdentifierCode, bool isValidExpected)
	{
		var subject = new E01_ElectronicFormMainHeading();
		subject.MaintenanceOperationCode = "P";
		subject.ElectronicFormStandardsTypeCode = "7";
		subject.FullOrPartialIndicatorCode = "1";
		subject.VersionReleaseIndustryIdentifierCode = versionReleaseIndustryIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validatation_RequiredFullOrPartialIndicatorCode(string fullOrPartialIndicatorCode, bool isValidExpected)
	{
		var subject = new E01_ElectronicFormMainHeading();
		subject.MaintenanceOperationCode = "P";
		subject.ElectronicFormStandardsTypeCode = "7";
		subject.VersionReleaseIndustryIdentifierCode = "4";
		subject.FullOrPartialIndicatorCode = fullOrPartialIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
