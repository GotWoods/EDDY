using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class PWKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PWK*QS*6*4*aR*E*Z6*H**S*l*9";

		var expected = new PWK_Paperwork()
		{
			ReportTypeCode = "QS",
			ReportTransmissionCode = "6",
			ReportCopiesNeeded = 4,
			EntityIdentifierCode = "aR",
			IdentificationCodeQualifier = "E",
			IdentificationCode = "Z6",
			Description = "H",
			ActionsIndicated = null,
			RequestCategoryCode = "S",
			CodeListQualifierCode = "l",
			IndustryCode = "9",
		};

		var actual = Map.MapObject<PWK_Paperwork>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QS", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new PWK_Paperwork();
		subject.ReportTypeCode = reportTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "E";
			subject.IdentificationCode = "Z6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "l";
			subject.IndustryCode = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "Z6", true)]
	[InlineData("E", "", false)]
	[InlineData("", "Z6", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PWK_Paperwork();
		subject.ReportTypeCode = "QS";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "l";
			subject.IndustryCode = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "9", true)]
	[InlineData("l", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new PWK_Paperwork();
		subject.ReportTypeCode = "QS";
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "E";
			subject.IdentificationCode = "Z6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
