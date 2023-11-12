using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class AOITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AOI*U*t*A*UY*5*lX*Fp*5*4w*t*lxwCfwZh*4*c1";

		var expected = new AOI_AnimalOffspringFetusIdentification()
		{
			YesNoConditionOrResponseCode = "U",
			ReferenceIdentification = "t",
			GenderCode = "A",
			OffspringFetusStatusCode = "UY",
			TestPeriodOrIntervalValue = 5,
			UnitOfTimePeriodOrInterval = "lX",
			AnimalDispositionCode = "Fp",
			TestPeriodOrIntervalValue2 = 5,
			UnitOfTimePeriodOrInterval2 = "4w",
			ReferenceIdentification2 = "t",
			Date = "lxwCfwZh",
			TestPeriodOrIntervalValue3 = 4,
			UnitOfTimePeriodOrInterval3 = "c1",
		};

		var actual = Map.MapObject<AOI_AnimalOffspringFetusIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.ReferenceIdentification = "t";
		subject.GenderCode = "A";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "Fp";
			subject.TestPeriodOrIntervalValue2 = 5;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 5;
			subject.UnitOfTimePeriodOrInterval2 = "4w";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 4;
			subject.UnitOfTimePeriodOrInterval3 = "c1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "t";
			subject.Date = "lxwCfwZh";
			subject.TestPeriodOrIntervalValue3 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "U";
		subject.GenderCode = "A";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "Fp";
			subject.TestPeriodOrIntervalValue2 = 5;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 5;
			subject.UnitOfTimePeriodOrInterval2 = "4w";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 4;
			subject.UnitOfTimePeriodOrInterval3 = "c1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "t";
			subject.Date = "lxwCfwZh";
			subject.TestPeriodOrIntervalValue3 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredGenderCode(string genderCode, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "U";
		subject.ReferenceIdentification = "t";
		//Test Parameters
		subject.GenderCode = genderCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "Fp";
			subject.TestPeriodOrIntervalValue2 = 5;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 5;
			subject.UnitOfTimePeriodOrInterval2 = "4w";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 4;
			subject.UnitOfTimePeriodOrInterval3 = "c1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "t";
			subject.Date = "lxwCfwZh";
			subject.TestPeriodOrIntervalValue3 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Fp", 5, true)]
	[InlineData("Fp", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredAnimalDispositionCode(string animalDispositionCode, int testPeriodOrIntervalValue2, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "U";
		subject.ReferenceIdentification = "t";
		subject.GenderCode = "A";
		//Test Parameters
		subject.AnimalDispositionCode = animalDispositionCode;
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 5;
			subject.UnitOfTimePeriodOrInterval2 = "4w";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 4;
			subject.UnitOfTimePeriodOrInterval3 = "c1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "t";
			subject.Date = "lxwCfwZh";
			subject.TestPeriodOrIntervalValue3 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "4w", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "4w", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrInterval2, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "U";
		subject.ReferenceIdentification = "t";
		subject.GenderCode = "A";
		//Test Parameters
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrInterval2 = unitOfTimePeriodOrInterval2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "Fp";
			subject.TestPeriodOrIntervalValue2 = 5;
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 4;
			subject.UnitOfTimePeriodOrInterval3 = "c1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "t";
			subject.Date = "lxwCfwZh";
			subject.TestPeriodOrIntervalValue3 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("t", "lxwCfwZh", 4, true)]
	[InlineData("t", "", 0, false)]
	[InlineData("", "lxwCfwZh", 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ReferenceIdentification2(string referenceIdentification2, string date, int testPeriodOrIntervalValue3, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "U";
		subject.ReferenceIdentification = "t";
		subject.GenderCode = "A";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.Date = date;
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "Fp";
			subject.TestPeriodOrIntervalValue2 = 5;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 5;
			subject.UnitOfTimePeriodOrInterval2 = "4w";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 4;
			subject.UnitOfTimePeriodOrInterval3 = "c1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "c1", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "c1", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrInterval3, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "U";
		subject.ReferenceIdentification = "t";
		subject.GenderCode = "A";
		//Test Parameters
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		subject.UnitOfTimePeriodOrInterval3 = unitOfTimePeriodOrInterval3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "Fp";
			subject.TestPeriodOrIntervalValue2 = 5;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 5;
			subject.UnitOfTimePeriodOrInterval2 = "4w";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ReferenceIdentification2 = "t";
			subject.Date = "lxwCfwZh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
