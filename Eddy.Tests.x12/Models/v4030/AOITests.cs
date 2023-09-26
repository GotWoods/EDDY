using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class AOITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AOI*I*5*f*Bd*2*je*so*3*97*A*z6x5g3qp*2*pk";

		var expected = new AOI_AnimalOffspringFetusIdentification()
		{
			YesNoConditionOrResponseCode = "I",
			ReferenceIdentification = "5",
			GenderCode = "f",
			OffspringFetusStatusCode = "Bd",
			TestPeriodOrIntervalValue = 2,
			UnitOfTimePeriodOrInterval = "je",
			AnimalDispositionCode = "so",
			TestPeriodOrIntervalValue2 = 3,
			UnitOfTimePeriodOrInterval2 = "97",
			ReferenceIdentification2 = "A",
			Date = "z6x5g3qp",
			TestPeriodOrIntervalValue3 = 2,
			UnitOfTimePeriodOrInterval3 = "pk",
		};

		var actual = Map.MapObject<AOI_AnimalOffspringFetusIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.ReferenceIdentification = "5";
		subject.GenderCode = "f";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "so";
			subject.TestPeriodOrIntervalValue2 = 3;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 3;
			subject.UnitOfTimePeriodOrInterval2 = "97";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 2;
			subject.UnitOfTimePeriodOrInterval3 = "pk";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "A";
			subject.Date = "z6x5g3qp";
			subject.TestPeriodOrIntervalValue3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "I";
		subject.GenderCode = "f";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "so";
			subject.TestPeriodOrIntervalValue2 = 3;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 3;
			subject.UnitOfTimePeriodOrInterval2 = "97";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 2;
			subject.UnitOfTimePeriodOrInterval3 = "pk";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "A";
			subject.Date = "z6x5g3qp";
			subject.TestPeriodOrIntervalValue3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredGenderCode(string genderCode, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "I";
		subject.ReferenceIdentification = "5";
		//Test Parameters
		subject.GenderCode = genderCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "so";
			subject.TestPeriodOrIntervalValue2 = 3;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 3;
			subject.UnitOfTimePeriodOrInterval2 = "97";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 2;
			subject.UnitOfTimePeriodOrInterval3 = "pk";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "A";
			subject.Date = "z6x5g3qp";
			subject.TestPeriodOrIntervalValue3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("so", 3, true)]
	[InlineData("so", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredAnimalDispositionCode(string animalDispositionCode, int testPeriodOrIntervalValue2, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "I";
		subject.ReferenceIdentification = "5";
		subject.GenderCode = "f";
		//Test Parameters
		subject.AnimalDispositionCode = animalDispositionCode;
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 3;
			subject.UnitOfTimePeriodOrInterval2 = "97";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 2;
			subject.UnitOfTimePeriodOrInterval3 = "pk";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "A";
			subject.Date = "z6x5g3qp";
			subject.TestPeriodOrIntervalValue3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "97", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "97", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrInterval2, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "I";
		subject.ReferenceIdentification = "5";
		subject.GenderCode = "f";
		//Test Parameters
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrInterval2 = unitOfTimePeriodOrInterval2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "so";
			subject.TestPeriodOrIntervalValue2 = 3;
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 2;
			subject.UnitOfTimePeriodOrInterval3 = "pk";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "A";
			subject.Date = "z6x5g3qp";
			subject.TestPeriodOrIntervalValue3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("A", "z6x5g3qp", 2, true)]
	[InlineData("A", "", 0, false)]
	[InlineData("", "z6x5g3qp", 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ReferenceIdentification2(string referenceIdentification2, string date, int testPeriodOrIntervalValue3, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "I";
		subject.ReferenceIdentification = "5";
		subject.GenderCode = "f";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.Date = date;
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "so";
			subject.TestPeriodOrIntervalValue2 = 3;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 3;
			subject.UnitOfTimePeriodOrInterval2 = "97";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 2;
			subject.UnitOfTimePeriodOrInterval3 = "pk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "pk", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "pk", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrInterval3, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "I";
		subject.ReferenceIdentification = "5";
		subject.GenderCode = "f";
		//Test Parameters
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		subject.UnitOfTimePeriodOrInterval3 = unitOfTimePeriodOrInterval3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "so";
			subject.TestPeriodOrIntervalValue2 = 3;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 3;
			subject.UnitOfTimePeriodOrInterval2 = "97";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ReferenceIdentification2 = "A";
			subject.Date = "z6x5g3qp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
