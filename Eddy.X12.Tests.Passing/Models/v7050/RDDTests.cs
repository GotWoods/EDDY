using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class RDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDD*6g*r*QQ*7*6";

		var expected = new RDD_RouteDescriptionDetail()
		{
			StandardCarrierAlphaCode = "6g",
			Rule260JunctionCode = "r",
			StandardCarrierAlphaCode2 = "QQ",
			Rule260JunctionCode2 = "7",
			AssignedNumber = 6,
		};

		var actual = Map.MapObject<RDD_RouteDescriptionDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6g", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new RDD_RouteDescriptionDetail();
		//Required fields
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "QQ", true)]
	[InlineData("7", "", false)]
	[InlineData("", "QQ", true)]
	public void Validation_ARequiresBRule260JunctionCode2(string rule260JunctionCode2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new RDD_RouteDescriptionDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "6g";
		//Test Parameters
		subject.Rule260JunctionCode2 = rule260JunctionCode2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
