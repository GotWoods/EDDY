using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRT*og***3s*W*H*P5*sQ*3*Zf";

		var expected = new CRT_ContractorReportType()
		{
			ReportTypeCode = "og",
			CompositeUnitOfMeasure = null,
			CompositeUnitOfMeasure2 = null,
			BreakdownStructureDetailCode = "3s",
			ActionCode = "W",
			RateOrValueTypeCode = "H",
			ContractActionCode = "P5",
			ProgramTypeCode = "sQ",
			FreeFormDescription = "3",
			SecurityLevelCode = "Zf",
		};

		var actual = Map.MapObject<CRT_ContractorReportType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("og", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new CRT_ContractorReportType();
		//Required fields
		//Test Parameters
		subject.ReportTypeCode = reportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
