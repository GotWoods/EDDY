using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class Y4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y4*G*W*H2y8kN*lQpBTT*9*dY3h*gY*W*G*2m";

		var expected = new Y4_ContainerRelease()
		{
			BookingNumber = "G",
			BookingNumber2 = "W",
			Date = "H2y8kN",
			StandardPointLocationCode = "lQpBTT",
			NumberOfContainers = 9,
			EquipmentType = "dY3h",
			StandardCarrierAlphaCode = "gY",
			LocationQualifier = "W",
			LocationIdentifier = "G",
			TypeOfServiceCode = "2m",
		};

		var actual = Map.MapObject<Y4_ContainerRelease>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "G", true)]
	[InlineData("W", "", false)]
	[InlineData("", "G", false)]
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
