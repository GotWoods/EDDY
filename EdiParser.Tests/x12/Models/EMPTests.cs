using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class EMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EMP*z*1W*5*4q*M*f*p*b*S*G";

		var expected = new EMP_Employer()
		{
			Description = "z",
			ProductServiceIDQualifier = "1W",
			ProductServiceID = "5",
			ReferenceIdentificationQualifier = "4q",
			ReferenceIdentification = "M",
			YesNoConditionOrResponseCode = "f",
			Description2 = "p",
			YesNoConditionOrResponseCode2 = "b",
			YesNoConditionOrResponseCode3 = "S",
			ReferenceIdentification2 = "G",
		};

		var actual = Map.MapObject<EMP_Employer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validatation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new EMP_Employer();
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("1W", "5", true)]
	[InlineData("", "5", false)]
	[InlineData("1W", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new EMP_Employer();
		subject.Description = "z";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("4q", "M", true)]
	[InlineData("", "M", false)]
	[InlineData("4q", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new EMP_Employer();
		subject.Description = "z";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
