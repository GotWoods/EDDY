using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AOITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AOI*K*S*6*pb*5*dH*xU*2*xS*G*3zIRsJ*7*0T";

		var expected = new AOI_AnimalOffspringFetusIdentification()
		{
			YesNoConditionOrResponseCode = "K",
			ReferenceIdentification = "S",
			GenderCode = "6",
			OffspringFetusStatusCode = "pb",
			TestPeriodOrIntervalValue = 5,
			UnitOfTimePeriodOrInterval = "dH",
			AnimalDispositionCode = "xU",
			TestPeriodOrIntervalValue2 = 2,
			UnitOfTimePeriodOrInterval2 = "xS",
			ReferenceIdentification2 = "G",
			Date = "3zIRsJ",
			TestPeriodOrIntervalValue3 = 7,
			UnitOfTimePeriodOrInterval3 = "0T",
		};

		var actual = Map.MapObject<AOI_AnimalOffspringFetusIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.ReferenceIdentification = "S";
		subject.GenderCode = "6";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "xU";
			subject.TestPeriodOrIntervalValue2 = 2;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrInterval2 = "xS";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 7;
			subject.UnitOfTimePeriodOrInterval3 = "0T";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "G";
			subject.Date = "3zIRsJ";
			subject.TestPeriodOrIntervalValue3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "K";
		subject.GenderCode = "6";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "xU";
			subject.TestPeriodOrIntervalValue2 = 2;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrInterval2 = "xS";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 7;
			subject.UnitOfTimePeriodOrInterval3 = "0T";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "G";
			subject.Date = "3zIRsJ";
			subject.TestPeriodOrIntervalValue3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredGenderCode(string genderCode, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "K";
		subject.ReferenceIdentification = "S";
		//Test Parameters
		subject.GenderCode = genderCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "xU";
			subject.TestPeriodOrIntervalValue2 = 2;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrInterval2 = "xS";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 7;
			subject.UnitOfTimePeriodOrInterval3 = "0T";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "G";
			subject.Date = "3zIRsJ";
			subject.TestPeriodOrIntervalValue3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("xU", 2, true)]
	[InlineData("xU", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredAnimalDispositionCode(string animalDispositionCode, int testPeriodOrIntervalValue2, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "K";
		subject.ReferenceIdentification = "S";
		subject.GenderCode = "6";
		//Test Parameters
		subject.AnimalDispositionCode = animalDispositionCode;
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrInterval2 = "xS";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 7;
			subject.UnitOfTimePeriodOrInterval3 = "0T";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "G";
			subject.Date = "3zIRsJ";
			subject.TestPeriodOrIntervalValue3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "xS", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "xS", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrInterval2, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "K";
		subject.ReferenceIdentification = "S";
		subject.GenderCode = "6";
		//Test Parameters
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrInterval2 = unitOfTimePeriodOrInterval2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "xU";
			subject.TestPeriodOrIntervalValue2 = 2;
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 7;
			subject.UnitOfTimePeriodOrInterval3 = "0T";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "G";
			subject.Date = "3zIRsJ";
			subject.TestPeriodOrIntervalValue3 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("G", "3zIRsJ", 7, true)]
	[InlineData("G", "", 0, false)]
	[InlineData("", "3zIRsJ", 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ReferenceIdentification2(string referenceIdentification2, string date, int testPeriodOrIntervalValue3, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "K";
		subject.ReferenceIdentification = "S";
		subject.GenderCode = "6";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.Date = date;
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "xU";
			subject.TestPeriodOrIntervalValue2 = 2;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrInterval2 = "xS";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 7;
			subject.UnitOfTimePeriodOrInterval3 = "0T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "0T", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "0T", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrInterval3, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "K";
		subject.ReferenceIdentification = "S";
		subject.GenderCode = "6";
		//Test Parameters
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		subject.UnitOfTimePeriodOrInterval3 = unitOfTimePeriodOrInterval3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "xU";
			subject.TestPeriodOrIntervalValue2 = 2;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrInterval2 = "xS";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ReferenceIdentification2 = "G";
			subject.Date = "3zIRsJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
