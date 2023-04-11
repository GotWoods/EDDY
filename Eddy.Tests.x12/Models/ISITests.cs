using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ISITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISI*S*7*Fr**6*J";

		var expected = new ISI_InstitutionalStaffInformation()
		{
			CodeListQualifierCode = "S",
			IndustryCode = "7",
			LevelOfIndividualTestOrCourseCode = "Fr",
			CompositeRaceOrEthnicityInformation = "",
			Quantity = 6,
			YesNoConditionOrResponseCode = "J",
		};

		var actual = Map.MapObject<ISI_InstitutionalStaffInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new ISI_InstitutionalStaffInformation();
		subject.IndustryCode = "7";
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new ISI_InstitutionalStaffInformation();
		subject.CodeListQualifierCode = "S";
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
