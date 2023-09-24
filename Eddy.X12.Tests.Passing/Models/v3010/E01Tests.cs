using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E01*E*i*F*m";

		var expected = new E01_ElectronicFormMainHeading()
		{
			MaintenanceOperationCode = "E",
			ElectronicFormStandardsTypeCode = "i",
			VersionReleaseIndustryIdentifierCode = "F",
			FullOrPartialIndicator = "m",
		};

		var actual = Map.MapObject<E01_ElectronicFormMainHeading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E01_ElectronicFormMainHeading();
		subject.ElectronicFormStandardsTypeCode = "i";
		subject.VersionReleaseIndustryIdentifierCode = "F";
		subject.FullOrPartialIndicator = "m";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredElectronicFormStandardsTypeCode(string electronicFormStandardsTypeCode, bool isValidExpected)
	{
		var subject = new E01_ElectronicFormMainHeading();
		subject.MaintenanceOperationCode = "E";
		subject.VersionReleaseIndustryIdentifierCode = "F";
		subject.FullOrPartialIndicator = "m";
		subject.ElectronicFormStandardsTypeCode = electronicFormStandardsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredVersionReleaseIndustryIdentifierCode(string versionReleaseIndustryIdentifierCode, bool isValidExpected)
	{
		var subject = new E01_ElectronicFormMainHeading();
		subject.MaintenanceOperationCode = "E";
		subject.ElectronicFormStandardsTypeCode = "i";
		subject.FullOrPartialIndicator = "m";
		subject.VersionReleaseIndustryIdentifierCode = versionReleaseIndustryIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredFullOrPartialIndicator(string fullOrPartialIndicator, bool isValidExpected)
	{
		var subject = new E01_ElectronicFormMainHeading();
		subject.MaintenanceOperationCode = "E";
		subject.ElectronicFormStandardsTypeCode = "i";
		subject.VersionReleaseIndustryIdentifierCode = "F";
		subject.FullOrPartialIndicator = fullOrPartialIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
