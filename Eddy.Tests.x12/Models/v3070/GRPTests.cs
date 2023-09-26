using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class GRPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GRP*2*s*dKbu0n*xHK0t9";

		var expected = new GRP_GroupDosageParameters()
		{
			Number = 2,
			UnitDoseCode = "s",
			Date = "dKbu0n",
			Date2 = "xHK0t9",
		};

		var actual = Map.MapObject<GRP_GroupDosageParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new GRP_GroupDosageParameters();
		//Required fields
		subject.UnitDoseCode = "s";
		subject.Date = "dKbu0n";
		subject.Date2 = "xHK0t9";
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredUnitDoseCode(string unitDoseCode, bool isValidExpected)
	{
		var subject = new GRP_GroupDosageParameters();
		//Required fields
		subject.Number = 2;
		subject.Date = "dKbu0n";
		subject.Date2 = "xHK0t9";
		//Test Parameters
		subject.UnitDoseCode = unitDoseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dKbu0n", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new GRP_GroupDosageParameters();
		//Required fields
		subject.Number = 2;
		subject.UnitDoseCode = "s";
		subject.Date2 = "xHK0t9";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xHK0t9", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new GRP_GroupDosageParameters();
		//Required fields
		subject.Number = 2;
		subject.UnitDoseCode = "s";
		subject.Date = "dKbu0n";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
