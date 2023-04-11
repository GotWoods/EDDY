using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DETTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DET*HO*n*Jz*F*X*3FAejWOL*tAiOTvPk";

		var expected = new DET_DietInformation()
		{
			DietTypeCode = "HO",
			Description = "n",
			ConditionIndicatorCode = "Jz",
			NameLastOrOrganizationName = "F",
			ReferenceIdentification = "X",
			Date = "3FAejWOL",
			Date2 = "tAiOTvPk",
		};

		var actual = Map.MapObject<DET_DietInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("HO","n", true)]
	[InlineData("", "n", true)]
	[InlineData("HO", "", true)]
	public void Validation_AtLeastOneDietTypeCode(string dietTypeCode, string description, bool isValidExpected)
	{
		var subject = new DET_DietInformation();
		subject.DietTypeCode = dietTypeCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "F", true)]
	[InlineData("X", "", false)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string nameLastOrOrganizationName, bool isValidExpected)
	{
		var subject = new DET_DietInformation();
		subject.ReferenceIdentification = referenceIdentification;
		subject.NameLastOrOrganizationName = nameLastOrOrganizationName;

		subject.Description = "AB";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
