using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SFCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SFC*s*d";

		var expected = new SFC_StorageFacilityCharacteristics()
		{
			FacilityCharacteristicCodeQualifier = "s",
			FacilityCharacteristicCode = "d",
		};

		var actual = Map.MapObject<SFC_StorageFacilityCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredFacilityCharacteristicCodeQualifier(string facilityCharacteristicCodeQualifier, bool isValidExpected)
	{
		var subject = new SFC_StorageFacilityCharacteristics();
		subject.FacilityCharacteristicCode = "d";
		subject.FacilityCharacteristicCodeQualifier = facilityCharacteristicCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredFacilityCharacteristicCode(string facilityCharacteristicCode, bool isValidExpected)
	{
		var subject = new SFC_StorageFacilityCharacteristics();
		subject.FacilityCharacteristicCodeQualifier = "s";
		subject.FacilityCharacteristicCode = facilityCharacteristicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
