using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class AOITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AOI*M*8*9*pj*3*Nq*tl*9*Ru*6*Ji5mEGrH*4*TZ";

		var expected = new AOI_AnimalOffspringFetusIdentification()
		{
			YesNoConditionOrResponseCode = "M",
			ReferenceIdentification = "8",
			GenderCode = "9",
			OffspringFetusStatusCode = "pj",
			TestPeriodOrIntervalValue = 3,
			UnitOfTimePeriodOrInterval = "Nq",
			AnimalDispositionCode = "tl",
			TestPeriodOrIntervalValue2 = 9,
			UnitOfTimePeriodOrInterval2 = "Ru",
			ReferenceIdentification2 = "6",
			Date = "Ji5mEGrH",
			TestPeriodOrIntervalValue3 = 4,
			UnitOfTimePeriodOrInterval3 = "TZ",
		};

		var actual = Map.MapObject<AOI_AnimalOffspringFetusIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.ReferenceIdentification = "8";
		subject.GenderCode = "9";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "tl";
			subject.TestPeriodOrIntervalValue2 = 9;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 9;
			subject.UnitOfTimePeriodOrInterval2 = "Ru";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 4;
			subject.UnitOfTimePeriodOrInterval3 = "TZ";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "6";
			subject.Date = "Ji5mEGrH";
			subject.TestPeriodOrIntervalValue3 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "M";
		subject.GenderCode = "9";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "tl";
			subject.TestPeriodOrIntervalValue2 = 9;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 9;
			subject.UnitOfTimePeriodOrInterval2 = "Ru";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 4;
			subject.UnitOfTimePeriodOrInterval3 = "TZ";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "6";
			subject.Date = "Ji5mEGrH";
			subject.TestPeriodOrIntervalValue3 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredGenderCode(string genderCode, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "M";
		subject.ReferenceIdentification = "8";
		//Test Parameters
		subject.GenderCode = genderCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "tl";
			subject.TestPeriodOrIntervalValue2 = 9;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 9;
			subject.UnitOfTimePeriodOrInterval2 = "Ru";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 4;
			subject.UnitOfTimePeriodOrInterval3 = "TZ";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "6";
			subject.Date = "Ji5mEGrH";
			subject.TestPeriodOrIntervalValue3 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("tl", 9, true)]
	[InlineData("tl", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredAnimalDispositionCode(string animalDispositionCode, int testPeriodOrIntervalValue2, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "M";
		subject.ReferenceIdentification = "8";
		subject.GenderCode = "9";
		//Test Parameters
		subject.AnimalDispositionCode = animalDispositionCode;
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 9;
			subject.UnitOfTimePeriodOrInterval2 = "Ru";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 4;
			subject.UnitOfTimePeriodOrInterval3 = "TZ";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "6";
			subject.Date = "Ji5mEGrH";
			subject.TestPeriodOrIntervalValue3 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "Ru", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "Ru", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrInterval2, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "M";
		subject.ReferenceIdentification = "8";
		subject.GenderCode = "9";
		//Test Parameters
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrInterval2 = unitOfTimePeriodOrInterval2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "tl";
			subject.TestPeriodOrIntervalValue2 = 9;
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 4;
			subject.UnitOfTimePeriodOrInterval3 = "TZ";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date) || subject.TestPeriodOrIntervalValue3 > 0)
		{
			subject.ReferenceIdentification2 = "6";
			subject.Date = "Ji5mEGrH";
			subject.TestPeriodOrIntervalValue3 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("6", "Ji5mEGrH", 4, true)]
	[InlineData("6", "", 0, false)]
	[InlineData("", "Ji5mEGrH", 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ReferenceIdentification2(string referenceIdentification2, string date, int testPeriodOrIntervalValue3, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "M";
		subject.ReferenceIdentification = "8";
		subject.GenderCode = "9";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.Date = date;
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "tl";
			subject.TestPeriodOrIntervalValue2 = 9;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 9;
			subject.UnitOfTimePeriodOrInterval2 = "Ru";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 4;
			subject.UnitOfTimePeriodOrInterval3 = "TZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "TZ", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "TZ", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrInterval3, bool isValidExpected)
	{
		var subject = new AOI_AnimalOffspringFetusIdentification();
		//Required fields
		subject.YesNoConditionOrResponseCode = "M";
		subject.ReferenceIdentification = "8";
		subject.GenderCode = "9";
		//Test Parameters
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		subject.UnitOfTimePeriodOrInterval3 = unitOfTimePeriodOrInterval3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AnimalDispositionCode) || !string.IsNullOrEmpty(subject.AnimalDispositionCode) || subject.TestPeriodOrIntervalValue2 > 0)
		{
			subject.AnimalDispositionCode = "tl";
			subject.TestPeriodOrIntervalValue2 = 9;
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 9;
			subject.UnitOfTimePeriodOrInterval2 = "Ru";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ReferenceIdentification2 = "6";
			subject.Date = "Ji5mEGrH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
