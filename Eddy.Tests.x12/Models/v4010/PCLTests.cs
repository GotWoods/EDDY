using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCL*2*Ff*QH*K*zLy*s*z";

		var expected = new PCL_PreviousCollege()
		{
			IdentificationCodeQualifier = "2",
			IdentificationCode = "Ff",
			DateTimePeriodFormatQualifier = "QH",
			DateTimePeriod = "K",
			AcademicDegreeCode = "zLy",
			DateTimePeriod2 = "s",
			Description = "z",
		};

		var actual = Map.MapObject<PCL_PreviousCollege>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "Ff", true)]
	[InlineData("2", "", false)]
	[InlineData("", "Ff", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "QH";
			subject.DateTimePeriod = "K";
		}

        subject.Description = "A";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("2", "z", true)]
	[InlineData("2", "", true)]
	[InlineData("", "z", true)]
	public void Validation_AtLeastOneIdentificationCodeQualifier(string identificationCodeQualifier, string description, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "QH";
			subject.DateTimePeriod = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QH", "K", true)]
	[InlineData("QH", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//At Least one
		subject.IdentificationCodeQualifier = "2";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "2";
			subject.IdentificationCode = "Ff";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "zLy", true)]
	[InlineData("s", "", false)]
	[InlineData("", "zLy", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string academicDegreeCode, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		//Required fields
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.AcademicDegreeCode = academicDegreeCode;
		//At Least one
		subject.IdentificationCodeQualifier = "2";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "2";
			subject.IdentificationCode = "Ff";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "QH";
			subject.DateTimePeriod = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
