using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C555Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "J:m:V:N";

		var expected = new C555_Status()
		{
			StatusCoded = "J",
			CodeListQualifier = "m",
			CodeListResponsibleAgencyCoded = "V",
			Status = "N",
		};

		var actual = Map.MapComposite<C555_Status>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredStatusCoded(string statusCoded, bool isValidExpected)
	{
		var subject = new C555_Status();
		//Required fields
		//Test Parameters
		subject.StatusCoded = statusCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
