using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7030;
using Eddy.x12.Models.v7030.Composites;

namespace Eddy.x12.Tests.Models.v7030.Composites;

public class C064Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "C*5";

		var expected = new C064_ServiceType()
		{
			IndustryCode = "C",
			IndustryCode2 = "5",
		};

		var actual = Map.MapObject<C064_ServiceType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new C064_ServiceType();
		//Required fields
		//Test Parameters
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
