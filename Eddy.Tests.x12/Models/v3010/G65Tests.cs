using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G65Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G65*4*5*6*8*8*J*8*Y";

		var expected = new G65_AverageAgreementTotal()
		{
			NumberOfDays = 4,
			NumberOfDays2 = 5,
			Charge = "6",
			NumberOfDays3 = 8,
			Rate = 8,
			Amount = "J",
			Amount2 = "8",
			Amount3 = "Y",
		};

		var actual = Map.MapObject<G65_AverageAgreementTotal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredNumberOfDays(int numberOfDays, bool isValidExpected)
	{
		var subject = new G65_AverageAgreementTotal();
		subject.NumberOfDays2 = 5;
		subject.Charge = "6";
		if (numberOfDays > 0)
			subject.NumberOfDays = numberOfDays;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredNumberOfDays2(int numberOfDays2, bool isValidExpected)
	{
		var subject = new G65_AverageAgreementTotal();
		subject.NumberOfDays = 4;
		subject.Charge = "6";
		if (numberOfDays2 > 0)
			subject.NumberOfDays2 = numberOfDays2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new G65_AverageAgreementTotal();
		subject.NumberOfDays = 4;
		subject.NumberOfDays2 = 5;
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
