using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TSPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TSP*05*N*4*Xz";

		var expected = new TSP_TestPeriodOrInterval()
		{
			TestPeriodOrIntervalQualifier = "05",
			AssignedIdentification = "N",
			TestPeriodOrIntervalValue = 4,
			UnitOfTimePeriodOrIntervalCode = "Xz",
		};

		var actual = Map.MapObject<TSP_TestPeriodOrInterval>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("05", true)]
	public void Validation_RequiredTestPeriodOrIntervalQualifier(string testPeriodOrIntervalQualifier, bool isValidExpected)
	{
		var subject = new TSP_TestPeriodOrInterval();
		subject.TestPeriodOrIntervalQualifier = testPeriodOrIntervalQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "Xz", true)]
	[InlineData(0, "Xz", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new TSP_TestPeriodOrInterval();
		subject.TestPeriodOrIntervalQualifier = "05";
		if (testPeriodOrIntervalValue > 0)
		subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
