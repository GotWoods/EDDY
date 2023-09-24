using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LHETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LHE*k*SbvbHjSmMHBhuw*6B*Z*iZ";

		var expected = new LHE_EmptyEquipmentHazardousMaterialInformation()
		{
			HazardousMaterialShippingName = "k",
			HazardousPlacardNotation = "SbvbHjSmMHBhuw",
			ReferenceNumberQualifier = "6B",
			ReferenceNumber = "Z",
			ReportableQuantityCode = "iZ",
		};

		var actual = Map.MapObject<LHE_EmptyEquipmentHazardousMaterialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredHazardousMaterialShippingName(string hazardousMaterialShippingName, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousPlacardNotation = "SbvbHjSmMHBhuw";
		subject.ReferenceNumberQualifier = "6B";
		subject.ReferenceNumber = "Z";
		subject.HazardousMaterialShippingName = hazardousMaterialShippingName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SbvbHjSmMHBhuw", true)]
	public void Validation_RequiredHazardousPlacardNotation(string hazardousPlacardNotation, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "k";
		subject.ReferenceNumberQualifier = "6B";
		subject.ReferenceNumber = "Z";
		subject.HazardousPlacardNotation = hazardousPlacardNotation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6B", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "k";
		subject.HazardousPlacardNotation = "SbvbHjSmMHBhuw";
		subject.ReferenceNumber = "Z";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new LHE_EmptyEquipmentHazardousMaterialInformation();
		subject.HazardousMaterialShippingName = "k";
		subject.HazardousPlacardNotation = "SbvbHjSmMHBhuw";
		subject.ReferenceNumberQualifier = "6B";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
