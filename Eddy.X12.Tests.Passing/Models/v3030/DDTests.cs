using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class DDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DD*G*j*sm*q*A*g*5*X*v*C";

		var expected = new DD_DemandDetail()
		{
			IndustryCode = "G",
			CodeListQualifierCode = "j",
			ReferenceNumberQualifier = "sm",
			ReferenceNumber = "q",
			IndustryCode2 = "A",
			CodeListQualifierCode2 = "g",
			Quantity = 5,
			YesNoConditionOrResponseCode = "X",
			IndustryCode3 = "v",
			CodeListQualifierCode3 = "C",
		};

		var actual = Map.MapObject<DD_DemandDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "G", true)]
	[InlineData("j", "", false)]
	[InlineData("", "G", true)]
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
	[InlineData("g", "A", true)]
	[InlineData("g", "", false)]
	[InlineData("", "A", true)]
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
	[InlineData("C", "v", true)]
	[InlineData("C", "", false)]
	[InlineData("", "v", true)]
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
