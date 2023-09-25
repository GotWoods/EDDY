using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class DDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DD*V*n*8f*9*5*Y*1*1*T*Y";

		var expected = new DD_DemandDetail()
		{
			IndustryCode = "V",
			CodeListQualifierCode = "n",
			ReferenceIdentificationQualifier = "8f",
			ReferenceIdentification = "9",
			IndustryCode2 = "5",
			CodeListQualifierCode2 = "Y",
			Quantity = 1,
			YesNoConditionOrResponseCode = "1",
			IndustryCode3 = "T",
			CodeListQualifierCode3 = "Y",
		};

		var actual = Map.MapObject<DD_DemandDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "V", true)]
	[InlineData("n", "", false)]
	[InlineData("", "V", true)]
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
	[InlineData("Y", "5", true)]
	[InlineData("Y", "", false)]
	[InlineData("", "5", true)]
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
	[InlineData("Y", "T", true)]
	[InlineData("Y", "", false)]
	[InlineData("", "T", true)]
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
