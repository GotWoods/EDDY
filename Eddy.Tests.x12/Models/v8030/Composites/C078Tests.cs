using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v8030;
using Eddy.x12.Models.v8030.Composites;

namespace Eddy.x12.Tests.Models.v8030.Composites;

public class C078Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "0*y*g";

		var expected = new C078_CompositeDangerousGoodsSubsidiaryClassificationCodes()
		{
			SubsidiaryClassificationCode = "0",
			SubsidiaryClassificationCode2 = "y",
			SubsidiaryClassificationCode3 = "g",
		};

		var actual = Map.MapObject<C078_CompositeDangerousGoodsSubsidiaryClassificationCodes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredSubsidiaryClassificationCode(string subsidiaryClassificationCode, bool isValidExpected)
	{
		var subject = new C078_CompositeDangerousGoodsSubsidiaryClassificationCodes();
		//Required fields
		//Test Parameters
		subject.SubsidiaryClassificationCode = subsidiaryClassificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "y", true)]
	[InlineData("g", "", false)]
	[InlineData("", "y", true)]
	public void Validation_ARequiresBSubsidiaryClassificationCode3(string subsidiaryClassificationCode3, string subsidiaryClassificationCode2, bool isValidExpected)
	{
		var subject = new C078_CompositeDangerousGoodsSubsidiaryClassificationCodes();
		//Required fields
		subject.SubsidiaryClassificationCode = "0";
		//Test Parameters
		subject.SubsidiaryClassificationCode3 = subsidiaryClassificationCode3;
		subject.SubsidiaryClassificationCode2 = subsidiaryClassificationCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
