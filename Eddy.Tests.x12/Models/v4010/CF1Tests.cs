using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CF1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CF1*s*YP*SNZpaEp8*2*i*6CIgvbYW";

		var expected = new CF1_BeginningSegmentForSummaryFreightBillManifest()
		{
			MasterReferenceLinkNumber = "s",
			StandardCarrierAlphaCode = "YP",
			Date = "SNZpaEp8",
			Count = 2,
			Amount = "i",
			Date2 = "6CIgvbYW",
		};

		var actual = Map.MapObject<CF1_BeginningSegmentForSummaryFreightBillManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, bool isValidExpected)
	{
		var subject = new CF1_BeginningSegmentForSummaryFreightBillManifest();
		//Required fields
		subject.StandardCarrierAlphaCode = "YP";
		//Test Parameters
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YP", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CF1_BeginningSegmentForSummaryFreightBillManifest();
		//Required fields
		subject.MasterReferenceLinkNumber = "s";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
