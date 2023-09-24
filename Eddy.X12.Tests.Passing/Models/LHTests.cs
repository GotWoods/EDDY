using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH*7*wJ*u*KH*7O*7";

		var expected = new LH_MixedHazardousCommodities()
		{
			LadingLineItemNumber = 7,
			HazardousMnemonicCode = "wJ",
			ReferenceIdentification = "u",
			ReferenceIdentificationQualifier = "KH",
			ReportableQuantityCode = "7O",
			LimitedQuantityIndicationCode = "7",
		};

		var actual = Map.MapObject<LH_MixedHazardousCommodities>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredLadingLineItemNumber(int ladingLineItemNumber, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.HazardousMnemonicCode = "wJ";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier = "KH";
		if (ladingLineItemNumber > 0)
		subject.LadingLineItemNumber = ladingLineItemNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wJ", true)]
	public void Validation_RequiredHazardousMnemonicCode(string hazardousMnemonicCode, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 7;
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier = "KH";
		subject.HazardousMnemonicCode = hazardousMnemonicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 7;
		subject.HazardousMnemonicCode = "wJ";
		subject.ReferenceIdentificationQualifier = "KH";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KH", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 7;
		subject.HazardousMnemonicCode = "wJ";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
