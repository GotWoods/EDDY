using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ERPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ERP*04*70M*T*Sa*B";

		var expected = new ERP_EducationalRecordPurpose()
		{
			TransactionTypeCode = "04",
			StatusReasonCode = "70M",
			ActionCode = "T",
			DateTimePeriodFormatQualifier = "Sa",
			DateTimePeriod = "B",
		};

		var actual = Map.MapObject<ERP_EducationalRecordPurpose>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("04", true)]
	public void Validatation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new ERP_EducationalRecordPurpose();
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Sa", "B", true)]
	[InlineData("", "B", false)]
	[InlineData("Sa", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ERP_EducationalRecordPurpose();
		subject.TransactionTypeCode = "04";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
