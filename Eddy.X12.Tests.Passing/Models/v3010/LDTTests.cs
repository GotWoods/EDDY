using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class LDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LDT*62*9*DQ*0ryFFO";

		var expected = new LDT_LeadTime()
		{
			LeadTimeCode = "62",
			Quantity = 9,
			UnitOfTimePeriodCode = "DQ",
			Date = "0ryFFO",
		};

		var actual = Map.MapObject<LDT_LeadTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("62", true)]
	public void Validation_RequiredLeadTimeCode(string leadTimeCode, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.Quantity = 9;
		subject.UnitOfTimePeriodCode = "DQ";
		subject.LeadTimeCode = leadTimeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.LeadTimeCode = "62";
		subject.UnitOfTimePeriodCode = "DQ";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DQ", true)]
	public void Validation_RequiredUnitOfTimePeriodCode(string unitOfTimePeriodCode, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.LeadTimeCode = "62";
		subject.Quantity = 9;
		subject.UnitOfTimePeriodCode = unitOfTimePeriodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
