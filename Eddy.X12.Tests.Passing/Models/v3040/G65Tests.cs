using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class G65Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G65*2*7*t*4*6*z*2*h";

		var expected = new G65_AverageAgreementTotal()
		{
			NumberOfDays = 2,
			NumberOfDays2 = 7,
			Charge = "t",
			NumberOfDays3 = 4,
			Rate = 6,
			Amount = "z",
			Amount2 = "2",
			Amount3 = "h",
		};

		var actual = Map.MapObject<G65_AverageAgreementTotal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredNumberOfDays(int numberOfDays, bool isValidExpected)
	{
		var subject = new G65_AverageAgreementTotal();
		subject.NumberOfDays2 = 7;
		subject.Charge = "t";
		if (numberOfDays > 0)
			subject.NumberOfDays = numberOfDays;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredNumberOfDays2(int numberOfDays2, bool isValidExpected)
	{
		var subject = new G65_AverageAgreementTotal();
		subject.NumberOfDays = 2;
		subject.Charge = "t";
		if (numberOfDays2 > 0)
			subject.NumberOfDays2 = numberOfDays2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new G65_AverageAgreementTotal();
		subject.NumberOfDays = 2;
		subject.NumberOfDays2 = 7;
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
