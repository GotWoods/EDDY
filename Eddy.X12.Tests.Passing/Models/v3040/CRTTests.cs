using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRT*LF*gL*EI*tE*u*4*fk*FW*c*X2";

		var expected = new CRT_ContractorReportType()
		{
			ReportTypeCode = "LF",
			UnitOrBasisForMeasurementCode = "gL",
			UnitOrBasisForMeasurementCode2 = "EI",
			BreakdownStructureDetailCode = "tE",
			ActionCode = "u",
			RateOrValueTypeCode = "4",
			ContractActionCode = "fk",
			ProgramTypeCode = "FW",
			FreeFormDescription = "c",
			SecurityLevelCode = "X2",
		};

		var actual = Map.MapObject<CRT_ContractorReportType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LF", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new CRT_ContractorReportType();
		//Required fields
		//Test Parameters
		subject.ReportTypeCode = reportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
