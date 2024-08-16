using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C703Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "x:r:A";

		var expected = new C703_NatureOfCargo()
		{
			NatureOfCargoCoded = "x",
			CodeListIdentificationCode = "r",
			CodeListResponsibleAgencyCode = "A",
		};

		var actual = Map.MapComposite<C703_NatureOfCargo>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredNatureOfCargoCoded(string natureOfCargoCoded, bool isValidExpected)
	{
		var subject = new C703_NatureOfCargo();
		//Required fields
		//Test Parameters
		subject.NatureOfCargoCoded = natureOfCargoCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
