using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class DETTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DET*En*1*55*z*n*pVOlcG7h*SXWFLAcN";

		var expected = new DET_DietInformation()
		{
			DietTypeCode = "En",
			Description = "1",
			ConditionIndicatorCode = "55",
			NameLastOrOrganizationName = "z",
			ReferenceIdentification = "n",
			Date = "pVOlcG7h",
			Date2 = "SXWFLAcN",
		};

		var actual = Map.MapObject<DET_DietInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("En", "1", true)]
	[InlineData("En", "", true)]
	[InlineData("", "1", true)]
	public void Validation_AtLeastOneDietTypeCode(string dietTypeCode, string description, bool isValidExpected)
	{
		var subject = new DET_DietInformation();
		//Required fields
		//Test Parameters
		subject.DietTypeCode = dietTypeCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.NameLastOrOrganizationName) || !string.IsNullOrEmpty(subject.NameLastOrOrganizationName) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.NameLastOrOrganizationName = "z";
			subject.ReferenceIdentification = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "n", true)]
	[InlineData("z", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredNameLastOrOrganizationName(string nameLastOrOrganizationName, string referenceIdentification, bool isValidExpected)
	{
		var subject = new DET_DietInformation();
		//Required fields
		//Test Parameters
		subject.NameLastOrOrganizationName = nameLastOrOrganizationName;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.DietTypeCode = "En";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
