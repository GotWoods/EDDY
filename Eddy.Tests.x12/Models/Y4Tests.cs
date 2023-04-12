using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class Y4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y4*W*R*m4RJFboM*36RJJQ*9*uVvv*kU*q*d*De";

		var expected = new Y4_ContainerRelease()
		{
			BookingNumber = "W",
			BookingNumber2 = "R",
			Date = "m4RJFboM",
			StandardPointLocationCode = "36RJJQ",
			NumberOfContainers = 9,
			EquipmentTypeCode = "uVvv",
			StandardCarrierAlphaCode = "kU",
			LocationQualifier = "q",
			LocationIdentifier = "d",
			TypeOfServiceCode = "De",
		};

		var actual = Map.MapObject<Y4_ContainerRelease>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("q", "d", true)]
	[InlineData("", "d", false)]
	[InlineData("q", "", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new Y4_ContainerRelease();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
