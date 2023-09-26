using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCL*q*qp*oo*1*zYV*Z*q";

		var expected = new PCL_PreviousCollege()
		{
			IdentificationCodeQualifier = "q",
			IdentificationCode = "qp",
			DateTimePeriodFormatQualifier = "oo",
			DateTimePeriod = "1",
			AcademicDegreeCode = "zYV",
			DateTimePeriod2 = "Z",
			Description = "q",
		};

		var actual = Map.MapObject<PCL_PreviousCollege>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "qp", true)]
	[InlineData("q", "", false)]
	[InlineData("", "qp", false)]
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
			subject.DateTimePeriodFormatQualifier = "oo";
			subject.DateTimePeriod = "1";
		}

        subject.Description = "A";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("q", "q", true)]
	[InlineData("q", "", true)]
	[InlineData("", "q", true)]
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
			subject.DateTimePeriodFormatQualifier = "oo";
			subject.DateTimePeriod = "1";
		}

        if (subject.IdentificationCodeQualifier != "")
            subject.IdentificationCode = "AB";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oo", "1", true)]
	[InlineData("oo", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//At Least one
		subject.IdentificationCodeQualifier = "q";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "q";
			subject.IdentificationCode = "qp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z", "zYV", true)]
	[InlineData("Z", "", false)]
	[InlineData("", "zYV", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string academicDegreeCode, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		//Required fields
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.AcademicDegreeCode = academicDegreeCode;
		//At Least one
		subject.IdentificationCodeQualifier = "q";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "q";
			subject.IdentificationCode = "qp";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "oo";
			subject.DateTimePeriod = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
