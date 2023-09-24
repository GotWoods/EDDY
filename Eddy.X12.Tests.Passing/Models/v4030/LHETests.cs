using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LHETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LHE*N*BYRM9AoWSN869n*GD*C*kM";

		var expected = new LHE_EmptyEquipmentHazardousMaterialInformation()
		{
			HazardousMaterialShippingName = "N",
			HazardousPlacardNotation = "BYRM9AoWSN869n",
			ReferenceIdentificationQualifier = "GD",
			ReferenceIdentification = "C",
			ReportableQuantityCode = "kM",
		};

		var actual = Map.MapObject<LHE_EmptyEquipmentHazardousMaterialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredHazardousMaterialShippingName(string hazardousMaterialShippingName, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousPlacardNotation = "BYRM9AoWSN869n";
		subject.ReferenceIdentificationQualifier = "GD";
		subject.ReferenceIdentification = "C";
		subject.HazardousMaterialShippingName = hazardousMaterialShippingName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BYRM9AoWSN869n", true)]
	public void Validation_RequiredHazardousPlacardNotation(string hazardousPlacardNotation, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "N";
		subject.ReferenceIdentificationQualifier = "GD";
		subject.ReferenceIdentification = "C";
		subject.HazardousPlacardNotation = hazardousPlacardNotation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GD", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "N";
		subject.HazardousPlacardNotation = "BYRM9AoWSN869n";
		subject.ReferenceIdentification = "C";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "N";
		subject.HazardousPlacardNotation = "BYRM9AoWSN869n";
		subject.ReferenceIdentificationQualifier = "GD";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
