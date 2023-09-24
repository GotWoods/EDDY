using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LSC*YW*Ps*v*Y*xJ";

		var expected = new LSC_LocationScopeParameter()
		{
			LocationScopeParameterTypeCode = "YW",
			LocationScopeTypeCode = "Ps",
			Description = "v",
			IdentificationCodeQualifier = "Y",
			IdentificationCode = "xJ",
		};

		var actual = Map.MapObject<LSC_LocationScopeParameter>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YW", true)]
	public void Validation_RequiredLocationScopeParameterTypeCode(string locationScopeParameterTypeCode, bool isValidExpected)
	{
		var subject = new LSC_LocationScopeParameter();
		subject.LocationScopeTypeCode = "Ps";
		subject.LocationScopeParameterTypeCode = locationScopeParameterTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ps", true)]
	public void Validation_RequiredLocationScopeTypeCode(string locationScopeTypeCode, bool isValidExpected)
	{
		var subject = new LSC_LocationScopeParameter();
		subject.LocationScopeParameterTypeCode = "YW";
		subject.LocationScopeTypeCode = locationScopeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Y", "xJ", true)]
	[InlineData("", "xJ", false)]
	[InlineData("Y", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new LSC_LocationScopeParameter();
		subject.LocationScopeParameterTypeCode = "YW";
		subject.LocationScopeTypeCode = "Ps";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
