using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class Y4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y4*x*t*7MRcah*Fci5i9*1*jrRb*AK*d*J*be";

		var expected = new Y4_ContainerRelease()
		{
			BookingNumber = "x",
			BookingNumber2 = "t",
			ContainerAvailabilityDate = "7MRcah",
			StandardPointLocationCode = "Fci5i9",
			NumberOfContainers = 1,
			EquipmentType = "jrRb",
			StandardCarrierAlphaCode = "AK",
			LocationQualifier = "d",
			LocationIdentifier = "J",
			TypeOfServiceCode = "be",
		};

		var actual = Map.MapObject<Y4_ContainerRelease>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "J", true)]
	[InlineData("d", "", false)]
	[InlineData("", "J", false)]
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
