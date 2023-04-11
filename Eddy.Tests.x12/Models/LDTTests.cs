using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LDT*b5*6*AK*BJSI9oJS";

		var expected = new LDT_LeadTime()
		{
			LeadTimeCode = "b5",
			Quantity = 6,
			UnitOfTimePeriodOrIntervalCode = "AK",
			Date = "BJSI9oJS",
		};

		var actual = Map.MapObject<LDT_LeadTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b5", true)]
	public void Validation_RequiredLeadTimeCode(string leadTimeCode, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.Quantity = 6;
		subject.UnitOfTimePeriodOrIntervalCode = "AK";
		subject.LeadTimeCode = leadTimeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.LeadTimeCode = "b5";
		subject.UnitOfTimePeriodOrIntervalCode = "AK";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AK", true)]
	public void Validation_RequiredUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.LeadTimeCode = "b5";
		subject.Quantity = 6;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
