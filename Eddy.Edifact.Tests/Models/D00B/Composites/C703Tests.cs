using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C703Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "W:H:s";

		var expected = new C703_NatureOfCargo()
		{
			CargoTypeClassificationCode = "W",
			CodeListIdentificationCode = "H",
			CodeListResponsibleAgencyCode = "s",
		};

		var actual = Map.MapComposite<C703_NatureOfCargo>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredCargoTypeClassificationCode(string cargoTypeClassificationCode, bool isValidExpected)
	{
		var subject = new C703_NatureOfCargo();
		//Required fields
		//Test Parameters
		subject.CargoTypeClassificationCode = cargoTypeClassificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
