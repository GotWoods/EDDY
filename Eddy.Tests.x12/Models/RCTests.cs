using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RC*xm*8*p*Jz*D*q*T*m*g";

		var expected = new RC_RootCause()
		{
			ProductServiceIDQualifier = "xm",
			ProductServiceID = "8",
			Name = "p",
			AgencyQualifierCode = "Jz",
			SourceSubqualifier = "D",
			CausalPartConditionCode = "q",
			Description = "T",
			FreeFormMessageText = "m",
			YesNoConditionOrResponseCode = "g",
		};

		var actual = Map.MapObject<RC_RootCause>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("xm", "8", true)]
	[InlineData("", "8", false)]
	[InlineData("xm", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "q", true)]
	[InlineData("Jz", "", false)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string causalPartConditionCode, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.CausalPartConditionCode = causalPartConditionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Jz", true)]
	[InlineData("D", "", false)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("q","T", true)]
	[InlineData("", "T", true)]
	[InlineData("q", "", true)]
	public void Validation_AtLeastOneCausalPartConditionCode(string causalPartConditionCode, string description, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		subject.CausalPartConditionCode = causalPartConditionCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
