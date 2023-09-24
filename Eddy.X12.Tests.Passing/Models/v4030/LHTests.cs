using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH*6*6h*1*9a*ih*O";

		var expected = new LH_MixedHazardousCommodities()
		{
			LadingLineItemNumber = 6,
			HazardousMnemonicCode = "6h",
			ReferenceIdentification = "1",
			ReferenceIdentificationQualifier = "9a",
			ReportableQuantityCode = "ih",
			LimitedQuantityIndicationCode = "O",
		};

		var actual = Map.MapObject<LH_MixedHazardousCommodities>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredLadingLineItemNumber(int ladingLineItemNumber, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.HazardousMnemonicCode = "6h";
		subject.ReferenceIdentification = "1";
		subject.ReferenceIdentificationQualifier = "9a";
		if (ladingLineItemNumber > 0)
			subject.LadingLineItemNumber = ladingLineItemNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6h", true)]
	public void Validation_RequiredHazardousMnemonicCode(string hazardousMnemonicCode, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 6;
		subject.ReferenceIdentification = "1";
		subject.ReferenceIdentificationQualifier = "9a";
		subject.HazardousMnemonicCode = hazardousMnemonicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 6;
		subject.HazardousMnemonicCode = "6h";
		subject.ReferenceIdentificationQualifier = "9a";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9a", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 6;
		subject.HazardousMnemonicCode = "6h";
		subject.ReferenceIdentification = "1";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
