using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CFTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CFT*iC*tS*bh*v5K*gw4dtn*pi2*TGcT56*5t";

		var expected = new CFT_CostReportingFormatType()
		{
			ReportTypeCode = "iC",
			UnitOrBasisForMeasurementCode = "tS",
			ContractingFundingCode = "bh",
			DateTimeQualifier = "v5K",
			Date = "gw4dtn",
			DateTimeQualifier2 = "pi2",
			Date2 = "TGcT56",
			AppropriationCode = "5t",
		};

		var actual = Map.MapObject<CFT_CostReportingFormatType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iC", true)]
	public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
	{
		var subject = new CFT_CostReportingFormatType();
		//Required fields
		//Test Parameters
		subject.ReportTypeCode = reportTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
