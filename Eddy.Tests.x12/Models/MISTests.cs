using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIS*9Q*KnX*Wh*t*WBF";

		var expected = new MIS_MortgageeInformationStatus()
		{
			MortgageeInformationStatusCode = "9Q",
			DateTimeQualifier = "KnX",
			DateTimePeriodFormatQualifier = "Wh",
			DateTimePeriod = "t",
			JurisdictionCode = "WBF",
		};

		var actual = Map.MapObject<MIS_MortgageeInformationStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9Q", true)]
	public void Validation_RequiredMortgageeInformationStatusCode(string mortgageeInformationStatusCode, bool isValidExpected)
	{
		var subject = new MIS_MortgageeInformationStatus();
		subject.MortgageeInformationStatusCode = mortgageeInformationStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
