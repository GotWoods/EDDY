using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SPKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPK*z*A*2";

		var expected = new SPK_SpecimenKitInformation()
		{
			SpecimenKitTypeCode = "z",
			TransportationMethodTypeCode = "A",
			Temperature = 2,
		};

		var actual = Map.MapObject<SPK_SpecimenKitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredSpecimenKitTypeCode(string specimenKitTypeCode, bool isValidExpected)
	{
		var subject = new SPK_SpecimenKitInformation();
		//Required fields
		//Test Parameters
		subject.SpecimenKitTypeCode = specimenKitTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
