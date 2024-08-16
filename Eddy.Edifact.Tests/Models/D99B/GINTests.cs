using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class GINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GIN+P+++++";

		var expected = new GIN_GoodsIdentityNumber()
		{
			ObjectIdentificationCodeQualifier = "P",
			IdentityNumberRange = null,
			IdentityNumberRange2 = null,
			IdentityNumberRange3 = null,
			IdentityNumberRange4 = null,
			IdentityNumberRange5 = null,
		};

		var actual = Map.MapObject<GIN_GoodsIdentityNumber>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredObjectIdentificationCodeQualifier(string objectIdentificationCodeQualifier, bool isValidExpected)
	{
		var subject = new GIN_GoodsIdentityNumber();
		//Required fields
		subject.IdentityNumberRange = new C208_IdentityNumberRange();
		//Test Parameters
		subject.ObjectIdentificationCodeQualifier = objectIdentificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredIdentityNumberRange(string identityNumberRange, bool isValidExpected)
	{
		var subject = new GIN_GoodsIdentityNumber();
		//Required fields
		subject.ObjectIdentificationCodeQualifier = "P";
		//Test Parameters
		if (identityNumberRange != "") 
			subject.IdentityNumberRange = new C208_IdentityNumberRange();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
