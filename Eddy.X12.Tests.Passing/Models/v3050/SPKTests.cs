using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SPKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPK*N*d*1";

		var expected = new SPK_SpecimenKitInformation()
		{
			SpecimenKitTypeCode = "N",
			TransportationMethodTypeCode = "d",
			Temperature = 1,
		};

		var actual = Map.MapObject<SPK_SpecimenKitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredSpecimenKitTypeCode(string specimenKitTypeCode, bool isValidExpected)
	{
		var subject = new SPK_SpecimenKitInformation();
		//Required fields
		//Test Parameters
		subject.SpecimenKitTypeCode = specimenKitTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
