using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class RDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDD*Ck*u*Ip*I*3";

		var expected = new RDD_RouteDescriptionDetail()
		{
			StandardCarrierAlphaCode = "Ck",
			Rule260JunctionCode = "u",
			StandardCarrierAlphaCode2 = "Ip",
			Rule260JunctionCode2 = "I",
			AssignedNumber = 3,
		};

		var actual = Map.MapObject<RDD_RouteDescriptionDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ck", true)]
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
	[InlineData("I", "Ip", true)]
	[InlineData("I", "", false)]
	[InlineData("", "Ip", true)]
	public void Validation_ARequiresBRule260JunctionCode2(string rule260JunctionCode2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new RDD_RouteDescriptionDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "Ck";
		//Test Parameters
		subject.Rule260JunctionCode2 = rule260JunctionCode2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
