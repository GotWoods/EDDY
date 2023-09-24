using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class LHETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LHE*F*dsQSQQwG8214em*yd*7*p7";

		var expected = new LHE_EmptyEquipmentHazardousMaterialInformation()
		{
			HazardousMaterialShippingName = "F",
			HazardousPlacardNotation = "dsQSQQwG8214em",
			ReferenceIdentificationQualifier = "yd",
			ReferenceIdentification = "7",
			ReportableQuantityCode = "p7",
		};

		var actual = Map.MapObject<LHE_EmptyEquipmentHazardousMaterialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredHazardousMaterialShippingName(string hazardousMaterialShippingName, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousPlacardNotation = "dsQSQQwG8214em";
		subject.ReferenceIdentificationQualifier = "yd";
		subject.ReferenceIdentification = "7";
		subject.HazardousMaterialShippingName = hazardousMaterialShippingName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dsQSQQwG8214em", true)]
	public void Validation_RequiredHazardousPlacardNotation(string hazardousPlacardNotation, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "F";
		subject.ReferenceIdentificationQualifier = "yd";
		subject.ReferenceIdentification = "7";
		subject.HazardousPlacardNotation = hazardousPlacardNotation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yd", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "F";
		subject.HazardousPlacardNotation = "dsQSQQwG8214em";
		subject.ReferenceIdentification = "7";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "F";
		subject.HazardousPlacardNotation = "dsQSQQwG8214em";
		subject.ReferenceIdentificationQualifier = "yd";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
