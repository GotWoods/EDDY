using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class ERPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ERP+";

		var expected = new ERP_ErrorPointDetails()
		{
			ErrorPointDetails = null,
		};

		var actual = Map.MapObject<ERP_ErrorPointDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredErrorPointDetails(string errorPointDetails, bool isValidExpected)
	{
		var subject = new ERP_ErrorPointDetails();
		//Required fields
		//Test Parameters
		if (errorPointDetails != "") 
			subject.ErrorPointDetails = new C701_ErrorPointDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
