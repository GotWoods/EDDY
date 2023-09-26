using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class ISITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISI*x*p*vp**8*7";

		var expected = new ISI_InstitutionalStaffInformation()
		{
			CodeListQualifierCode = "x",
			IndustryCode = "p",
			LevelOfIndividualTestOrCourseCode = "vp",
			CompositeRaceOrEthnicityInformation = null,
			Quantity = 8,
			YesNoConditionOrResponseCode = "7",
		};

		var actual = Map.MapObject<ISI_InstitutionalStaffInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new ISI_InstitutionalStaffInformation();
		//Required fields
		subject.IndustryCode = "p";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new ISI_InstitutionalStaffInformation();
		//Required fields
		subject.CodeListQualifierCode = "x";
		//Test Parameters
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
