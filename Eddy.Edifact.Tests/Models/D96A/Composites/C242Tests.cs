using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C242Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "o:Y:z:T:e";

		var expected = new C242_ProcessTypeAndDescription()
		{
			ProcessTypeIdentification = "o",
			CodeListQualifier = "Y",
			CodeListResponsibleAgencyCoded = "z",
			ProcessType = "T",
			ProcessType2 = "e",
		};

		var actual = Map.MapComposite<C242_ProcessTypeAndDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredProcessTypeIdentification(string processTypeIdentification, bool isValidExpected)
	{
		var subject = new C242_ProcessTypeAndDescription();
		//Required fields
		//Test Parameters
		subject.ProcessTypeIdentification = processTypeIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
