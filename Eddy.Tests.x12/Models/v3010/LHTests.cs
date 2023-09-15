using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class LHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH*7*m9*t*SI*0t*o";

		var expected = new LH_MixedHazardousCommodities()
		{
			LadingLineItemNumber = 7,
			HazardousMnemonicCode = "m9",
			ReferenceNumber = "t",
			ReferenceNumberQualifier = "SI",
			ReportableQuantityCode = "0t",
			LimitedQuantityIndicationCode = "o",
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
		subject.HazardousMnemonicCode = "m9";
		subject.ReferenceNumber = "t";
		subject.ReferenceNumberQualifier = "SI";
		if (ladingLineItemNumber > 0)
			subject.LadingLineItemNumber = ladingLineItemNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m9", true)]
	public void Validation_RequiredHazardousMnemonicCode(string hazardousMnemonicCode, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 7;
		subject.ReferenceNumber = "t";
		subject.ReferenceNumberQualifier = "SI";
		subject.HazardousMnemonicCode = hazardousMnemonicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 7;
		subject.HazardousMnemonicCode = "m9";
		subject.ReferenceNumberQualifier = "SI";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SI", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new LH_MixedHazardousCommodities();
		subject.LadingLineItemNumber = 7;
		subject.HazardousMnemonicCode = "m9";
		subject.ReferenceNumber = "t";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
