using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class DETTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DET*cb*l*XT*A*N*19Y1RZiO*U2iTYLIw";

		var expected = new DET_DietInformation()
		{
			DietTypeCode = "cb",
			Description = "l",
			ConditionIndicatorCode = "XT",
			NameLastOrOrganizationName = "A",
			ReferenceIdentification = "N",
			Date = "19Y1RZiO",
			Date2 = "U2iTYLIw",
		};

		var actual = Map.MapObject<DET_DietInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("cb", "l", true)]
	[InlineData("cb", "", true)]
	[InlineData("", "l", true)]
	public void Validation_AtLeastOneDietTypeCode(string dietTypeCode, string description, bool isValidExpected)
	{
		var subject = new DET_DietInformation();
		//Required fields
		//Test Parameters
		subject.DietTypeCode = dietTypeCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "A", true)]
	[InlineData("N", "", false)]
	[InlineData("", "A", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string nameLastOrOrganizationName, bool isValidExpected)
	{
		var subject = new DET_DietInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.NameLastOrOrganizationName = nameLastOrOrganizationName;
		//At Least one
		subject.DietTypeCode = "cb";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
