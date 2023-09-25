using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAT*5H*i*oR*R*1g*e";

		var expected = new PAT_PatientInformation()
		{
			IndividualRelationshipCode = "5H",
			PatientLocationCode = "i",
			EmploymentStatusCode = "oR",
			StudentStatusCode = "R",
			DateTimePeriodFormatQualifier = "1g",
			DateTimePeriod = "e",
		};

		var actual = Map.MapObject<PAT_PatientInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1g", "e", true)]
	[InlineData("1g", "", false)]
	[InlineData("", "e", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PAT_PatientInformation();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
