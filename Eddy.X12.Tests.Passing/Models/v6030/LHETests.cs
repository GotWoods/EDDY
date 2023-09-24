using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class LHETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LHE*8*YUhrWJntELvdlX*6y*6*1h";

		var expected = new LHE_EmptyEquipmentHazardousMaterialInformation()
		{
			HazardousMaterialShippingName = "8",
			HazardousPlacardNotationCode = "YUhrWJntELvdlX",
			ReferenceIdentificationQualifier = "6y",
			ReferenceIdentification = "6",
			ReportableQuantityCode = "1h",
		};

		var actual = Map.MapObject<LHE_EmptyEquipmentHazardousMaterialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredHazardousMaterialShippingName(string hazardousMaterialShippingName, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousPlacardNotationCode = "YUhrWJntELvdlX";
		subject.ReferenceIdentificationQualifier = "6y";
		subject.ReferenceIdentification = "6";
		subject.HazardousMaterialShippingName = hazardousMaterialShippingName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YUhrWJntELvdlX", true)]
	public void Validation_RequiredHazardousPlacardNotationCode(string hazardousPlacardNotationCode, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "8";
		subject.ReferenceIdentificationQualifier = "6y";
		subject.ReferenceIdentification = "6";
		subject.HazardousPlacardNotationCode = hazardousPlacardNotationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6y", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "8";
		subject.HazardousPlacardNotationCode = "YUhrWJntELvdlX";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "8";
		subject.HazardousPlacardNotationCode = "YUhrWJntELvdlX";
		subject.ReferenceIdentificationQualifier = "6y";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
