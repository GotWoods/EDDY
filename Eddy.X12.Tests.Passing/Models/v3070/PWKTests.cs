using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PWKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PWK*lN*S*4*Hd*T*04*d**c";

		var expected = new PWK_Paperwork()
		{
			ReportTypeCode = "lN",
			ReportTransmissionCode = "S",
			ReportCopiesNeeded = 4,
			EntityIdentifierCode = "Hd",
			IdentificationCodeQualifier = "T",
			IdentificationCode = "04",
			Description = "d",
			ActionsIndicated = null,
			RequestCategoryCode = "c",
		};

		var actual = Map.MapObject<PWK_Paperwork>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lN", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new PWK_Paperwork();
		subject.ReportTypeCode = reportTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "T";
			subject.IdentificationCode = "04";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "04", true)]
	[InlineData("T", "", false)]
	[InlineData("", "04", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PWK_Paperwork();
		subject.ReportTypeCode = "lN";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
