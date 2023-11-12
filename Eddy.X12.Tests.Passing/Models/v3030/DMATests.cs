using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class DMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMA*J*c8*A*uH*C";

		var expected = new DMA_AdditionalDemographicInformation()
		{
			ReferenceNumber = "J",
			StateOrProvinceCode = "c8",
			ReferenceNumber2 = "A",
			StateOrProvinceCode2 = "uH",
			ApplicantTypeCode = "C",
		};

		var actual = Map.MapObject<DMA_AdditionalDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "uH", true)]
	[InlineData("A", "", false)]
	[InlineData("", "uH", false)]
	public void Validation_AllAreRequiredReferenceNumber2(string referenceNumber2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new DMA_AdditionalDemographicInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceNumber2 = referenceNumber2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
