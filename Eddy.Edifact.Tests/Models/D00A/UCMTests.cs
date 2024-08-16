using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UCMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UCM+I++I+M+I++8++S+F";

		var expected = new UCM_MessagePackageResponse()
		{
			MessageReferenceNumber = "I",
			MessageIdentifier = null,
			ActionCoded = "I",
			SyntaxErrorCoded = "M",
			ServiceSegmentTagCoded = "I",
			DataElementIdentification = null,
			PackageReferenceNumber = "8",
			ReferenceIdentification = null,
			SecurityReferenceNumber = "S",
			SecuritySegmentPosition = "F",
		};

		var actual = Map.MapObject<UCM_MessagePackageResponse>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredActionCoded(string actionCoded, bool isValidExpected)
	{
		var subject = new UCM_MessagePackageResponse();
		//Required fields
		//Test Parameters
		subject.ActionCoded = actionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
