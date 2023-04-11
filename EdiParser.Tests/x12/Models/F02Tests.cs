using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class F02Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F02*VYOufank*L*b*kK*6*8W*O*M*4d";

		var expected = new F02_IdentificationOfShipment()
		{
			Date = "VYOufank",
			EquipmentInitial = "L",
			EquipmentNumber = "b",
			ReferenceIdentificationQualifier = "kK",
			ReferenceIdentification = "6",
			ReferenceIdentificationQualifier2 = "8W",
			ReferenceIdentification2 = "O",
			VesselCode = "M",
			VesselName = "4d",
		};

		var actual = Map.MapObject<F02_IdentificationOfShipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("kK", "6", true)]
	[InlineData("", "6", false)]
	[InlineData("kK", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new F02_IdentificationOfShipment();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("8W", "O", true)]
	[InlineData("", "O", false)]
	[InlineData("8W", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new F02_IdentificationOfShipment();
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
