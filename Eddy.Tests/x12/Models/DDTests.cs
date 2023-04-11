using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DD*p*b*lR*P*e*I*6*H*B*J";

		var expected = new DD_DemandDetail()
		{
			IndustryCode = "p",
			CodeListQualifierCode = "b",
			ReferenceIdentificationQualifier = "lR",
			ReferenceIdentification = "P",
			IndustryCode2 = "e",
			CodeListQualifierCode2 = "I",
			Quantity = 6,
			YesNoConditionOrResponseCode = "H",
			IndustryCode3 = "B",
			CodeListQualifierCode3 = "J",
		};

		var actual = Map.MapObject<DD_DemandDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "p", true)]
	[InlineData("b", "", false)]
	public void Validation_ARequiresBCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new DD_DemandDetail();
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "e", true)]
	[InlineData("I", "", false)]
	public void Validation_ARequiresBCodeListQualifierCode2(string codeListQualifierCode2, string industryCode2, bool isValidExpected)
	{
		var subject = new DD_DemandDetail();
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		subject.IndustryCode2 = industryCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "B", true)]
	[InlineData("J", "", false)]
	public void Validation_ARequiresBCodeListQualifierCode3(string codeListQualifierCode3, string industryCode3, bool isValidExpected)
	{
		var subject = new DD_DemandDetail();
		subject.CodeListQualifierCode3 = codeListQualifierCode3;
		subject.IndustryCode3 = industryCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
