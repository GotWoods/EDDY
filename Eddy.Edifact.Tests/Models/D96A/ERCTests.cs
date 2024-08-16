using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class ERCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ERC+";

		var expected = new ERC_ApplicationErrorInformation()
		{
			ApplicationErrorDetail = null,
		};

		var actual = Map.MapObject<ERC_ApplicationErrorInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredApplicationErrorDetail(string applicationErrorDetail, bool isValidExpected)
	{
		var subject = new ERC_ApplicationErrorInformation();
		//Required fields
		//Test Parameters
		if (applicationErrorDetail != "") 
			subject.ApplicationErrorDetail = new C901_ApplicationErrorDetail();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
