using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class Y4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y4*h*D*Enp8tIYP*QZuLRp*2*Jtuj*sC*A*9*Kq";

		var expected = new Y4_ContainerRelease()
		{
			BookingNumber = "h",
			BookingNumber2 = "D",
			Date = "Enp8tIYP",
			StandardPointLocationCode = "QZuLRp",
			NumberOfContainers = 2,
			EquipmentTypeCode = "Jtuj",
			StandardCarrierAlphaCode = "sC",
			LocationQualifier = "A",
			LocationIdentifier = "9",
			TypeOfServiceCode = "Kq",
		};

		var actual = Map.MapObject<Y4_ContainerRelease>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "9", true)]
	[InlineData("A", "", false)]
	[InlineData("", "9", false)]
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
