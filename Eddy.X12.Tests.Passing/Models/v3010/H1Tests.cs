using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class H1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H1*FNKp*nw*n*Nw*b*C*x*w8";

		var expected = new H1_HazardousMaterial()
		{
			HazardousMaterialCode = "FNKp",
			HazardousMaterialClassCode = "nw",
			HazardousMaterialCodeQualifier = "n",
			HazardousMaterialDescription = "Nw",
			HazardousMaterialContact = "b",
			HazardousMaterialsPage = "C",
			FlashpointTemperature = "x",
			UnitOfMeasurementCode = "w8",
		};

		var actual = Map.MapObject<H1_HazardousMaterial>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FNKp", true)]
	public void Validation_RequiredHazardousMaterialCode(string hazardousMaterialCode, bool isValidExpected)
	{
		var subject = new H1_HazardousMaterial();
		subject.HazardousMaterialCode = hazardousMaterialCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
