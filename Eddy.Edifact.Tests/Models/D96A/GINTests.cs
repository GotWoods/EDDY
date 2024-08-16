using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class GINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GIN+h+++++";

		var expected = new GIN_GoodsIdentityNumber()
		{
			IdentityNumberQualifier = "h",
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
	[InlineData("h", true)]
	public void Validation_RequiredIdentityNumberQualifier(string identityNumberQualifier, bool isValidExpected)
	{
		var subject = new GIN_GoodsIdentityNumber();
		//Required fields
		subject.IdentityNumberRange = new C208_IdentityNumberRange();
		//Test Parameters
		subject.IdentityNumberQualifier = identityNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredIdentityNumberRange(string identityNumberRange, bool isValidExpected)
	{
		var subject = new GIN_GoodsIdentityNumber();
		//Required fields
		subject.IdentityNumberQualifier = "h";
		//Test Parameters
		if (identityNumberRange != "") 
			subject.IdentityNumberRange = new C208_IdentityNumberRange();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
