using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SFCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SFC*J*c";

		var expected = new SFC_StorageFacilityCharacteristics()
		{
			FacilityCharacteristicCodeQualifier = "J",
			FacilityCharacteristicCode = "c",
		};

		var actual = Map.MapObject<SFC_StorageFacilityCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredFacilityCharacteristicCodeQualifier(string facilityCharacteristicCodeQualifier, bool isValidExpected)
	{
		var subject = new SFC_StorageFacilityCharacteristics();
		//Required fields
		subject.FacilityCharacteristicCode = "c";
		//Test Parameters
		subject.FacilityCharacteristicCodeQualifier = facilityCharacteristicCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredFacilityCharacteristicCode(string facilityCharacteristicCode, bool isValidExpected)
	{
		var subject = new SFC_StorageFacilityCharacteristics();
		//Required fields
		subject.FacilityCharacteristicCodeQualifier = "J";
		//Test Parameters
		subject.FacilityCharacteristicCode = facilityCharacteristicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
