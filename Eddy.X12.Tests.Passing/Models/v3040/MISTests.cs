using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class MISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIS*0i*0NO*e4*l*Q8C";

		var expected = new MIS_MortgageeInformationStatus()
		{
			MortgageeInformationStatusCode = "0i",
			DateTimeQualifier = "0NO",
			DateTimePeriodFormatQualifier = "e4",
			DateTimePeriod = "l",
			JurisdictionCode = "Q8C",
		};

		var actual = Map.MapObject<MIS_MortgageeInformationStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0i", true)]
	public void Validation_RequiredMortgageeInformationStatusCode(string mortgageeInformationStatusCode, bool isValidExpected)
	{
		var subject = new MIS_MortgageeInformationStatus();
		//Required fields
		//Test Parameters
		subject.MortgageeInformationStatusCode = mortgageeInformationStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
