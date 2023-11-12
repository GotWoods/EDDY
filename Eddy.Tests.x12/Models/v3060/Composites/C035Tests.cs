using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Tests.Models.v3060.Composites;

public class C035Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "D*H6*e";

		var expected = new C035_ProviderSpecialtyInformation()
		{
			ProviderSpecialtyCode = "D",
			AgencyQualifierCode = "H6",
			YesNoConditionOrResponseCode = "e",
		};

		var actual = Map.MapObject<C035_ProviderSpecialtyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredProviderSpecialtyCode(string providerSpecialtyCode, bool isValidExpected)
	{
		var subject = new C035_ProviderSpecialtyInformation();
		//Required fields
		//Test Parameters
		subject.ProviderSpecialtyCode = providerSpecialtyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
