using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class Y4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y4*0*I*gKOCTAf0*HrAgIp*5*iJ40*zL*H*V*Bd";

		var expected = new Y4_ContainerRelease()
		{
			BookingNumber = "0",
			BookingNumber2 = "I",
			Date = "gKOCTAf0",
			StandardPointLocationCode = "HrAgIp",
			NumberOfContainers = 5,
			EquipmentType = "iJ40",
			StandardCarrierAlphaCode = "zL",
			LocationQualifier = "H",
			LocationIdentifier = "V",
			TypeOfServiceCode = "Bd",
		};

		var actual = Map.MapObject<Y4_ContainerRelease>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "V", true)]
	[InlineData("H", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new Y4_ContainerRelease();
		//Required fields
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
