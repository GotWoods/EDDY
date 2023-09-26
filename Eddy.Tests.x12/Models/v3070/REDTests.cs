using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class REDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RED*U*tv*nU*D*n*E";

		var expected = new RED_RelatedData()
		{
			Description = "U",
			RelatedDataIdentificationCode = "tv",
			AgencyQualifierCode = "nU",
			SourceSubqualifier = "D",
			CodeListQualifierCode = "n",
			IndustryCode = "E",
		};

		var actual = Map.MapObject<RED_RelatedData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new RED_RelatedData();
		//Required fields
		//Test Parameters
		subject.Description = description;
		//At Least one
		subject.RelatedDataIdentificationCode = "tv";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("tv", "", true)]
	[InlineData("", "E", true)]
	public void Validation_AtLeastOneRelatedDataIdentificationCode(string relatedDataIdentificationCode, string industryCode, bool isValidExpected)
	{
		var subject = new RED_RelatedData();
		//Required fields
		subject.Description = "U";


		//Test Parameters
		subject.RelatedDataIdentificationCode = relatedDataIdentificationCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("tv", "E", false)]
	[InlineData("tv", "", true)]
	[InlineData("", "E", true)]
	public void Validation_OnlyOneOfRelatedDataIdentificationCode(string relatedDataIdentificationCode, string industryCode, bool isValidExpected)
	{
		var subject = new RED_RelatedData();
		//Required fields
		subject.Description = "U";
		//Test Parameters
		subject.RelatedDataIdentificationCode = relatedDataIdentificationCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "nU", true)]
	[InlineData("D", "", false)]
	[InlineData("", "nU", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new RED_RelatedData();
		//Required fields
		subject.Description = "U";
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//At Least one
		subject.RelatedDataIdentificationCode = "tv";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
