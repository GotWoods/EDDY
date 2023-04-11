using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCL*o*4s*to*L*kgz*2*w";

		var expected = new PCL_PreviousCollege()
		{
			IdentificationCodeQualifier = "o",
			IdentificationCode = "4s",
			DateTimePeriodFormatQualifier = "to",
			DateTimePeriod = "L",
			AcademicDegreeCode = "kgz",
			DateTimePeriod2 = "2",
			Description = "w",
		};

		var actual = Map.MapObject<PCL_PreviousCollege>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("o", "4s", true)]
	[InlineData("", "4s", false)]
	[InlineData("o", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("o","w", true)]
	[InlineData("", "w", true)]
	[InlineData("o", "", true)]
	public void Validation_AtLeastOneIdentificationCodeQualifier(string identificationCodeQualifier, string description, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("to", "L", true)]
	[InlineData("", "L", false)]
	[InlineData("to", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "kgz", true)]
	[InlineData("2", "", false)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string academicDegreeCode, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.AcademicDegreeCode = academicDegreeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
