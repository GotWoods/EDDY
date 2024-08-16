using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class QRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "QRS+p++";

		var expected = new QRS_QueryAndResponse()
		{
			SectorAreaIdentificationCodeQualifier = "p",
			QuestionDetails = null,
			ResponseDetails = null,
		};

		var actual = Map.MapObject<QRS_QueryAndResponse>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredSectorAreaIdentificationCodeQualifier(string sectorAreaIdentificationCodeQualifier, bool isValidExpected)
	{
		var subject = new QRS_QueryAndResponse();
		//Required fields
		//Test Parameters
		subject.SectorAreaIdentificationCodeQualifier = sectorAreaIdentificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
