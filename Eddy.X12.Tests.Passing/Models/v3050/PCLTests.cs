using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCL*W*lB*ZP*y*EIm*U*O";

		var expected = new PCL_PreviousCollege()
		{
			IdentificationCodeQualifier = "W",
			IdentificationCode = "lB",
			DateTimePeriodFormatQualifier = "ZP",
			DateTimePeriod = "y",
			AcademicDegreeCode = "EIm",
			DateTimePeriod2 = "U",
			Description = "O",
		};

		var actual = Map.MapObject<PCL_PreviousCollege>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		//Required fields
		subject.IdentificationCode = "lB";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lB", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		//Required fields
		subject.IdentificationCodeQualifier = "W";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "EIm", true)]
	[InlineData("U", "", false)]
	[InlineData("", "EIm", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string academicDegreeCode, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		//Required fields
		subject.IdentificationCodeQualifier = "W";
		subject.IdentificationCode = "lB";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.AcademicDegreeCode = academicDegreeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
