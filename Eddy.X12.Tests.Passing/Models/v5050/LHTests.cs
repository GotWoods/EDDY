using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class LHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH*9*zJ*p*3S*Wi*a";

		var expected = new LH_MixedHazardousCommodities()
		{
			LadingLineItemNumber = 9,
			HazardousMnemonicCode = "zJ",
			ReferenceIdentification = "p",
			ReferenceIdentificationQualifier = "3S",
			ReportableQuantityCode = "Wi",
			LimitedQuantityIndicationCode = "a",
		};

		var actual = Map.MapObject<LH_MixedHazardousCommodities>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredLadingLineItemNumber(int ladingLineItemNumber, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.HazardousMnemonicCode = "zJ";
		subject.ReferenceIdentification = "p";
		subject.ReferenceIdentificationQualifier = "3S";
		if (ladingLineItemNumber > 0)
			subject.LadingLineItemNumber = ladingLineItemNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zJ", true)]
	public void Validation_RequiredHazardousMnemonicCode(string hazardousMnemonicCode, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 9;
		subject.ReferenceIdentification = "p";
		subject.ReferenceIdentificationQualifier = "3S";
		subject.HazardousMnemonicCode = hazardousMnemonicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 9;
		subject.HazardousMnemonicCode = "zJ";
		subject.ReferenceIdentificationQualifier = "3S";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3S", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 9;
		subject.HazardousMnemonicCode = "zJ";
		subject.ReferenceIdentification = "p";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
