using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class DDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DD*M*F*VX*1*w*j*2*E*n*o";

		var expected = new DD_DemandDetail()
		{
			IndustryCode = "M",
			CodeListQualifierCode = "F",
			ReferenceIdentificationQualifier = "VX",
			ReferenceIdentification = "1",
			IndustryCode2 = "w",
			CodeListQualifierCode2 = "j",
			Quantity = 2,
			YesNoConditionOrResponseCode = "E",
			IndustryCode3 = "n",
			CodeListQualifierCode3 = "o",
		};

		var actual = Map.MapObject<DD_DemandDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F", "M", true)]
	[InlineData("F", "", false)]
	[InlineData("", "M", true)]
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
	[InlineData("j", "w", true)]
	[InlineData("j", "", false)]
	[InlineData("", "w", true)]
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
	[InlineData("o", "n", true)]
	[InlineData("o", "", false)]
	[InlineData("", "n", true)]
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
