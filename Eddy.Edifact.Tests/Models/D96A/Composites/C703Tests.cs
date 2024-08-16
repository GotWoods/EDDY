using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C703Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "d:L:t";

		var expected = new C703_NatureOfCargo()
		{
			NatureOfCargoCoded = "d",
			CodeListQualifier = "L",
			CodeListResponsibleAgencyCoded = "t",
		};

		var actual = Map.MapComposite<C703_NatureOfCargo>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredNatureOfCargoCoded(string natureOfCargoCoded, bool isValidExpected)
	{
		var subject = new C703_NatureOfCargo();
		//Required fields
		//Test Parameters
		subject.NatureOfCargoCoded = natureOfCargoCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
