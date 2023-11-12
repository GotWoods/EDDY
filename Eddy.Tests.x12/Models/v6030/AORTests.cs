using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class AORTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AOR*q*y*C*U*F*D*D*5*xF*3*Zl*8*qU";

		var expected = new AOR_AnimalObservationResult()
		{
			ObservationDistribution = "q",
			ObservationSeverity = "y",
			NeoplasmCode = "C",
			YesNoConditionOrResponseCode = "U",
			LinkageIdentifier = "F",
			LinkageIdentifier2 = "D",
			YesNoConditionOrResponseCode2 = "D",
			TestPeriodOrIntervalValue = 5,
			UnitOfTimePeriodOrIntervalCode = "xF",
			TestPeriodOrIntervalValue2 = 3,
			UnitOfTimePeriodOrIntervalCode2 = "Zl",
			TestPeriodOrIntervalValue3 = 8,
			UnitOfTimePeriodOrIntervalCode3 = "qU",
		};

		var actual = Map.MapObject<AOR_AnimalObservationResult>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "xF", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "xF", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new AOR_AnimalObservationResult();
		//Required fields
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 3;
			subject.UnitOfTimePeriodOrIntervalCode2 = "Zl";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 8;
			subject.UnitOfTimePeriodOrIntervalCode3 = "qU";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Zl", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Zl", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrIntervalCode2, bool isValidExpected)
	{
		var subject = new AOR_AnimalObservationResult();
		//Required fields
		//Test Parameters
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrIntervalCode2 = unitOfTimePeriodOrIntervalCode2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 5;
			subject.UnitOfTimePeriodOrIntervalCode = "xF";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 8;
			subject.UnitOfTimePeriodOrIntervalCode3 = "qU";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "qU", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "qU", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrIntervalCode3, bool isValidExpected)
	{
		var subject = new AOR_AnimalObservationResult();
		//Required fields
		//Test Parameters
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		subject.UnitOfTimePeriodOrIntervalCode3 = unitOfTimePeriodOrIntervalCode3;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 5;
			subject.UnitOfTimePeriodOrIntervalCode = "xF";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 3;
			subject.UnitOfTimePeriodOrIntervalCode2 = "Zl";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
