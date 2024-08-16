using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C703Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "D:q:B";

		var expected = new C703_NatureOfCargo()
		{
			CargoTypeClassificationCode = "D",
			CodeListIdentificationCode = "q",
			CodeListResponsibleAgencyCode = "B",
		};

		var actual = Map.MapComposite<C703_NatureOfCargo>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredCargoTypeClassificationCode(string cargoTypeClassificationCode, bool isValidExpected)
	{
		var subject = new C703_NatureOfCargo();
		//Required fields
		//Test Parameters
		subject.CargoTypeClassificationCode = cargoTypeClassificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
