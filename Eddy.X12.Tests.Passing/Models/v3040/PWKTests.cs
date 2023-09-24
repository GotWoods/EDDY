using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PWKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PWK*AO*iH*9*tp*p*fs*Q*";

		var expected = new PWK_Paperwork()
		{
			ReportTypeCode = "AO",
			ReportTransmissionCode = "iH",
			ReportCopiesNeeded = 9,
			EntityIdentifierCode = "tp",
			IdentificationCodeQualifier = "p",
			IdentificationCode = "fs",
			Description = "Q",
			ActionsIndicated = null,
		};

		var actual = Map.MapObject<PWK_Paperwork>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AO", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new PWK_Paperwork();
		subject.ReportTypeCode = reportTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "p";
			subject.IdentificationCode = "fs";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "fs", true)]
	[InlineData("p", "", false)]
	[InlineData("", "fs", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PWK_Paperwork();
		subject.ReportTypeCode = "AO";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
