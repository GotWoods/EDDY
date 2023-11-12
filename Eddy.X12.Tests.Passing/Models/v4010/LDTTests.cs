using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LDT*L8*6*TX*YENNinLx";

		var expected = new LDT_LeadTime()
		{
			LeadTimeCode = "L8",
			Quantity = 6,
			UnitOfTimePeriodOrInterval = "TX",
			Date = "YENNinLx",
		};

		var actual = Map.MapObject<LDT_LeadTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L8", true)]
	public void Validation_RequiredLeadTimeCode(string leadTimeCode, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.Quantity = 6;
		subject.UnitOfTimePeriodOrInterval = "TX";
		subject.LeadTimeCode = leadTimeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.LeadTimeCode = "L8";
		subject.UnitOfTimePeriodOrInterval = "TX";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TX", true)]
	public void Validation_RequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.LeadTimeCode = "L8";
		subject.Quantity = 6;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
