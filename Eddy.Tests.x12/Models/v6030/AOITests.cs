using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class AOITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AOI*i*q*U*li*2*xE*gT*2*3J*b*L3hvj9yI*2*G2";

		var expected = new AOI_AnimalOffspringFetusIdentification()
		{
			YesNoConditionOrResponseCode = "i",
			ReferenceIdentification = "q",
			GenderCode = "U",
			OffspringFetusStatusCode = "li",
			TestPeriodOrIntervalValue = 2,
			UnitOfTimePeriodOrIntervalCode = "xE",
			AnimalDispositionCode = "gT",
			TestPeriodOrIntervalValue2 = 2,
			UnitOfTimePeriodOrIntervalCode2 = "3J",
			ReferenceIdentification2 = "b",
			Date = "L3hvj9yI",
			TestPeriodOrIntervalValue3 = 2,
			UnitOfTimePeriodOrIntervalCode3 = "G2",
		};

		var actual = Map.MapObject<AOI_AnimalOffspringFetusIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.ReferenceIdentification = "q";
		subject.GenderCode = "U";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "gT";
			subject.TestPeriodOrIntervalValue2 = 2;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrIntervalCode2 = "3J";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 2;
			subject.UnitOfTimePeriodOrIntervalCode3 = "G2";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "b";
			subject.Date = "L3hvj9yI";
			subject.TestPeriodOrIntervalValue3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "i";
		subject.GenderCode = "U";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "gT";
			subject.TestPeriodOrIntervalValue2 = 2;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrIntervalCode2 = "3J";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 2;
			subject.UnitOfTimePeriodOrIntervalCode3 = "G2";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "b";
			subject.Date = "L3hvj9yI";
			subject.TestPeriodOrIntervalValue3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredGenderCode(string genderCode, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "i";
		subject.ReferenceIdentification = "q";
		//Test Parameters
		subject.GenderCode = genderCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "gT";
			subject.TestPeriodOrIntervalValue2 = 2;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrIntervalCode2 = "3J";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 2;
			subject.UnitOfTimePeriodOrIntervalCode3 = "G2";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "b";
			subject.Date = "L3hvj9yI";
			subject.TestPeriodOrIntervalValue3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("gT", 2, true)]
	[InlineData("gT", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredAnimalDispositionCode(string animalDispositionCode, int testPeriodOrIntervalValue2, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "i";
		subject.ReferenceIdentification = "q";
		subject.GenderCode = "U";
		//Test Parameters
		subject.AnimalDispositionCode = animalDispositionCode;
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrIntervalCode2 = "3J";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 2;
			subject.UnitOfTimePeriodOrIntervalCode3 = "G2";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "b";
			subject.Date = "L3hvj9yI";
			subject.TestPeriodOrIntervalValue3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "3J", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "3J", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrIntervalCode2, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "i";
		subject.ReferenceIdentification = "q";
		subject.GenderCode = "U";
		//Test Parameters
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrIntervalCode2 = unitOfTimePeriodOrIntervalCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "gT";
			subject.TestPeriodOrIntervalValue2 = 2;
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 2;
			subject.UnitOfTimePeriodOrIntervalCode3 = "G2";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "b";
			subject.Date = "L3hvj9yI";
			subject.TestPeriodOrIntervalValue3 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("b", "L3hvj9yI", 2, true)]
	[InlineData("b", "", 0, false)]
	[InlineData("", "L3hvj9yI", 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ReferenceIdentification2(string referenceIdentification2, string date, int testPeriodOrIntervalValue3, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "i";
		subject.ReferenceIdentification = "q";
		subject.GenderCode = "U";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.Date = date;
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "gT";
			subject.TestPeriodOrIntervalValue2 = 2;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrIntervalCode2 = "3J";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 2;
			subject.UnitOfTimePeriodOrIntervalCode3 = "G2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "G2", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "G2", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrIntervalCode3, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "i";
		subject.ReferenceIdentification = "q";
		subject.GenderCode = "U";
		//Test Parameters
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		subject.UnitOfTimePeriodOrIntervalCode3 = unitOfTimePeriodOrIntervalCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "gT";
			subject.TestPeriodOrIntervalValue2 = 2;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrIntervalCode2 = "3J";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ReferenceIdentification2 = "b";
			subject.Date = "L3hvj9yI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
