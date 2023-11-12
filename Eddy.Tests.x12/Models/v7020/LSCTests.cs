using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class LSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LSC*mk*Vw*7*B*hF";

		var expected = new LSC_LocationScopeParameter()
		{
			LocationScopeParameterTypeCode = "mk",
			LocationScopeTypeCode = "Vw",
			Description = "7",
			IdentificationCodeQualifier = "B",
			IdentificationCode = "hF",
		};

		var actual = Map.MapObject<LSC_LocationScopeParameter>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mk", true)]
	public void Validation_RequiredLocationScopeParameterTypeCode(string locationScopeParameterTypeCode, bool isValidExpected)
	{
		var subject = new LSC_LocationScopeParameter();
		//Required fields
		subject.LocationScopeTypeCode = "Vw";
		//Test Parameters
		subject.LocationScopeParameterTypeCode = locationScopeParameterTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "B";
			subject.IdentificationCode = "hF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vw", true)]
	public void Validation_RequiredLocationScopeTypeCode(string locationScopeTypeCode, bool isValidExpected)
	{
		var subject = new LSC_LocationScopeParameter();
		//Required fields
		subject.LocationScopeParameterTypeCode = "mk";
		//Test Parameters
		subject.LocationScopeTypeCode = locationScopeTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "B";
			subject.IdentificationCode = "hF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "hF", true)]
	[InlineData("B", "", false)]
	[InlineData("", "hF", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new LSC_LocationScopeParameter();
		//Required fields
		subject.LocationScopeParameterTypeCode = "mk";
		subject.LocationScopeTypeCode = "Vw";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
