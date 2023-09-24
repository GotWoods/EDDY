using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PWKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PWK*4U*qH*3*wR*j*G1*v*c";

		var expected = new PWK_Paperwork()
		{
			ReportTypeCode = "4U",
			ReportTransmissionCode = "qH",
			ReportCopiesNeeded = 3,
			EntityIdentifierCode = "wR",
			IdentificationCodeQualifier = "j",
			IdentificationCode = "G1",
			Description = "v",
			PaperworkReportActionCode = "c",
		};

		var actual = Map.MapObject<PWK_Paperwork>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4U", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new PWK_Paperwork();
		subject.ReportTypeCode = reportTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "j";
			subject.IdentificationCode = "G1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "G1", true)]
	[InlineData("j", "", false)]
	[InlineData("", "G1", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PWK_Paperwork();
		subject.ReportTypeCode = "4U";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
