using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class QRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "QRS+H++";

		var expected = new QRS_QueryAndResponse()
		{
			SectorSubjectIdentificationQualifier = "H",
			QuestionDetails = null,
			ResponseDetails = null,
		};

		var actual = Map.MapObject<QRS_QueryAndResponse>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredSectorSubjectIdentificationQualifier(string sectorSubjectIdentificationQualifier, bool isValidExpected)
	{
		var subject = new QRS_QueryAndResponse();
		//Required fields
		//Test Parameters
		subject.SectorSubjectIdentificationQualifier = sectorSubjectIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
