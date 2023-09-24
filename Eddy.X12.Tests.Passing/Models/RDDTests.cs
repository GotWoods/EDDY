using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDD*ho*i*Qm*O*4";

		var expected = new RDD_RouteDescriptionDetail()
		{
			StandardCarrierAlphaCode = "ho",
			Rule260JunctionCode = "i",
			StandardCarrierAlphaCode2 = "Qm",
			Rule260JunctionCode2 = "O",
			AssignedNumber = 4,
		};

		var actual = Map.MapObject<RDD_RouteDescriptionDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ho", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new RDD_RouteDescriptionDetail();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Qm", true)]
	[InlineData("O", "", false)]
	public void Validation_ARequiresBRule260JunctionCode2(string rule260JunctionCode2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new RDD_RouteDescriptionDetail();
		subject.StandardCarrierAlphaCode = "ho";
		subject.Rule260JunctionCode2 = rule260JunctionCode2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
