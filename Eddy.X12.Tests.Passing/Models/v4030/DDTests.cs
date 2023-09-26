using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class DDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DD*s*c*9w*M*m*I*7*s*7*D";

		var expected = new DD_DemandDetail()
		{
			IndustryCode = "s",
			CodeListQualifierCode = "c",
			ReferenceIdentificationQualifier = "9w",
			ReferenceIdentification = "M",
			IndustryCode2 = "m",
			CodeListQualifierCode2 = "I",
			Quantity = 7,
			YesNoConditionOrResponseCode = "s",
			IndustryCode3 = "7",
			CodeListQualifierCode3 = "D",
		};

		var actual = Map.MapObject<DD_DemandDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "s", true)]
	[InlineData("c", "", false)]
	[InlineData("", "s", true)]
	public void Validation_ARequiresBCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new DD_DemandDetail();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "m", true)]
	[InlineData("I", "", false)]
	[InlineData("", "m", true)]
	public void Validation_ARequiresBCodeListQualifierCode2(string codeListQualifierCode2, string industryCode2, bool isValidExpected)
	{
		var subject = new DD_DemandDetail();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		subject.IndustryCode2 = industryCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "7", true)]
	[InlineData("D", "", false)]
	[InlineData("", "7", true)]
	public void Validation_ARequiresBCodeListQualifierCode3(string codeListQualifierCode3, string industryCode3, bool isValidExpected)
	{
		var subject = new DD_DemandDetail();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode3 = codeListQualifierCode3;
		subject.IndustryCode3 = industryCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
