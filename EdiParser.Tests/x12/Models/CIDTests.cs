using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CID*2*t3*Vq*t*F*P*P";

		var expected = new CID_CharacteristicClassID()
		{
			MeasurementQualifier = "2",
			ProductProcessCharacteristicCode = "t3",
			AgencyQualifierCode = "Vq",
			ProductDescriptionCode = "t",
			Description = "F",
			SourceSubqualifier = "P",
			YesNoConditionOrResponseCode = "P",
		};

		var actual = Map.MapObject<CID_CharacteristicClassID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Vq", "t", true)]
	[InlineData("", "t", false)]
	[InlineData("Vq", "", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new CID_CharacteristicClassID();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	//TODO enable this:
	// [Theory]
	// [InlineData("","", true)]
	// [InlineData("P", "t", false)]
	// [InlineData("","t", true)]
	// [InlineData("P", "", true)]
	// public void Validation_NEWYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string productDescriptionCode, string description, bool isValidExpected)
	// {
	// 	var subject = new CID_CharacteristicClassID();
	// 	subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
	// 	subject.ProductDescriptionCode = productDescriptionCode;
	// 	subject.Description = description;
	//
	// 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
	// }

}
