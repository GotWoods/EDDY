using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G63Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G63*N*2*U*U";

		var expected = new G63_Period()
		{
			TimePeriodQualifier = "N",
			NumberOfPeriods = 2,
			TariffApplicationCode = "U",
			Description = "U",
		};

		var actual = Map.MapObject<G63_Period>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredTimePeriodQualifier(string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new G63_Period();
		subject.NumberOfPeriods = 2;
		subject.TimePeriodQualifier = timePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredNumberOfPeriods(int numberOfPeriods, bool isValidExpected)
	{
		var subject = new G63_Period();
		subject.TimePeriodQualifier = "N";
		if (numberOfPeriods > 0)
		subject.NumberOfPeriods = numberOfPeriods;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
