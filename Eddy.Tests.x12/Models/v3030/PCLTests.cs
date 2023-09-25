using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCL*x*CK*yf*q*LL4*P*M";

		var expected = new PCL_PreviousCollege()
		{
			IdentificationCodeQualifier = "x",
			IdentificationCode = "CK",
			DateTimePeriodFormatQualifier = "yf",
			DateTimePeriod = "q",
			AcademicDegreeCode = "LL4",
			DateTimePeriod2 = "P",
			FreeFormMessage = "M",
		};

		var actual = Map.MapObject<PCL_PreviousCollege>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		//Required fields
		subject.IdentificationCode = "CK";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CK", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		//Required fields
		subject.IdentificationCodeQualifier = "x";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "LL4", true)]
	[InlineData("P", "", false)]
	[InlineData("", "LL4", true)]
	public void Validation_ARequiresBDateTimePeriod2(string dateTimePeriod2, string academicDegreeCode, bool isValidExpected)
	{
		var subject = new PCL_PreviousCollege();
		//Required fields
		subject.IdentificationCodeQualifier = "x";
		subject.IdentificationCode = "CK";
		//Test Parameters
		subject.DateTimePeriod2 = dateTimePeriod2;
		subject.AcademicDegreeCode = academicDegreeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
