using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH*7*eh*s*PK*if*d";

		var expected = new LH_MixedHazardousCommodities()
		{
			LadingLineItemNumber = 7,
			HazardousMnemonicCode = "eh",
			ReferenceIdentification = "s",
			ReferenceIdentificationQualifier = "PK",
			ReportableQuantityCode = "if",
			LimitedQuantityIndicationCode = "d",
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
		subject.HazardousMnemonicCode = "eh";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier = "PK";
		if (ladingLineItemNumber > 0)
			subject.LadingLineItemNumber = ladingLineItemNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eh", true)]
	public void Validation_RequiredHazardousMnemonicCode(string hazardousMnemonicCode, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 7;
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier = "PK";
		subject.HazardousMnemonicCode = hazardousMnemonicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 7;
		subject.HazardousMnemonicCode = "eh";
		subject.ReferenceIdentificationQualifier = "PK";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PK", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 7;
		subject.HazardousMnemonicCode = "eh";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
