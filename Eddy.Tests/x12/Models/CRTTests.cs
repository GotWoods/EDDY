using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class CRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRT*Hx*A1*A2*e3*6*D*jQ*g7*d*PZ";

		var expected = new CRT_ContractorReportType()
		{
			ReportTypeCode = "Hx",
			CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() {UnitOrBasisForMeasurementCode = "A1"},
			CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure() {UnitOrBasisForMeasurementCode = "A2"},
			BreakdownStructureDetailCode = "e3",
			ActionCode = "6",
			RateOrValueTypeCode = "D",
			ContractActionCode = "jQ",
			ProgramTypeCode = "g7",
			FreeFormDescription = "d",
			SecurityLevelCode = "PZ",
		};

		var actual = Map.MapObject<CRT_ContractorReportType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);

      Assert.Equivalent(expected, actual);
		
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hx", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new CRT_ContractorReportType();
		subject.ReportTypeCode = reportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
