using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class REDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RED*z*YS*38*q*m*Q";

		var expected = new RED_RelatedData()
		{
			Description = "z",
			RelatedDataIdentificationCode = "YS",
			AgencyQualifierCode = "38",
			SourceSubqualifier = "q",
			CodeListQualifierCode = "m",
			IndustryCode = "Q",
		};

		var actual = Map.MapObject<RED_RelatedData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new RED_RelatedData();
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("YS","Q", true)]
	[InlineData("", "Q", true)]
	[InlineData("YS", "", true)]
	public void Validation_AtLeastOneRelatedDataIdentificationCode(string relatedDataIdentificationCode, string industryCode, bool isValidExpected)
	{
		var subject = new RED_RelatedData();
		subject.Description = "z";
		subject.RelatedDataIdentificationCode = relatedDataIdentificationCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("YS", "Q", false)]
	[InlineData("", "Q", true)]
	[InlineData("YS", "", true)]
	public void Validation_OnlyOneOfRelatedDataIdentificationCode(string relatedDataIdentificationCode, string industryCode, bool isValidExpected)
	{
		var subject = new RED_RelatedData();
		subject.Description = "z";
		subject.RelatedDataIdentificationCode = relatedDataIdentificationCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "38", true)]
	[InlineData("q", "", false)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new RED_RelatedData();
		subject.Description = "z";
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
