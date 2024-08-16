using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class BASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BAS+y+";

		var expected = new BAS_Basis()
		{
			BasisCodeQualifier = "y",
			BasisType = null,
		};

		var actual = Map.MapObject<BAS_Basis>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredBasisCodeQualifier(string basisCodeQualifier, bool isValidExpected)
	{
		var subject = new BAS_Basis();
		//Required fields
		subject.BasisType = new C974_BasisType();
		//Test Parameters
		subject.BasisCodeQualifier = basisCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredBasisType(string basisType, bool isValidExpected)
	{
		var subject = new BAS_Basis();
		//Required fields
		subject.BasisCodeQualifier = "y";
		//Test Parameters
		if (basisType != "") 
			subject.BasisType = new C974_BasisType();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
