using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class LHETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LHE*3*Zz6ESyddsMhOi0V1*yB*Q*9O";

		var expected = new LHE_EmptyEquipmentHazardousMaterialInformation()
		{
			HazardousMaterialShippingName = "3",
			HazardousPlacardNotation = "Zz6ESyddsMhOi0V1",
			ReferenceNumberQualifier = "yB",
			ReferenceNumber = "Q",
			ReportableQuantityCode = "9O",
		};

		var actual = Map.MapObject<LHE_EmptyEquipmentHazardousMaterialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredHazardousMaterialShippingName(string hazardousMaterialShippingName, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousPlacardNotation = "Zz6ESyddsMhOi0V1";
		subject.ReferenceNumberQualifier = "yB";
		subject.ReferenceNumber = "Q";
		subject.HazardousMaterialShippingName = hazardousMaterialShippingName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zz6ESyddsMhOi0V1", true)]
	public void Validation_RequiredHazardousPlacardNotation(string hazardousPlacardNotation, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "3";
		subject.ReferenceNumberQualifier = "yB";
		subject.ReferenceNumber = "Q";
		subject.HazardousPlacardNotation = hazardousPlacardNotation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yB", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "3";
		subject.HazardousPlacardNotation = "Zz6ESyddsMhOi0V1";
		subject.ReferenceNumber = "Q";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "3";
		subject.HazardousPlacardNotation = "Zz6ESyddsMhOi0V1";
		subject.ReferenceNumberQualifier = "yB";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
