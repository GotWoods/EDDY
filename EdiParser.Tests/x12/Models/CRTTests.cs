using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRT*Hx***e3*6*D*jQ*g7*d*PZ";

		var expected = new CRT_ContractorReportType()
		{
			ReportTypeCode = "Hx",
			CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure(),
			CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure(),
			BreakdownStructureDetailCode = "e3",
			ActionCode = "6",
			RateOrValueTypeCode = "D",
			ContractActionCode = "jQ",
			ProgramTypeCode = "g7",
			FreeFormDescription = "d",
			SecurityLevelCode = "PZ",
		};

		var actual = Map.MapObject<CRT_ContractorReportType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hx", true)]
	public void Validatation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new CRT_ContractorReportType();
		subject.ReportTypeCode = reportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
