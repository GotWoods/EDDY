using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TAX*z*g*l*d*b*l*e*I*q*T*E*Q";

		var expected = new TAX_SalesTaxReference()
		{
			TaxIdentificationNumber = "z",
			LocationQualifier = "g",
			LocationIdentifier = "l",
			LocationQualifier2 = "d",
			LocationIdentifier2 = "b",
			LocationQualifier3 = "l",
			LocationIdentifier3 = "e",
			LocationQualifier4 = "I",
			LocationIdentifier4 = "q",
			LocationQualifier5 = "T",
			LocationIdentifier5 = "E",
			TaxExemptCode = "Q",
		};

		var actual = Map.MapObject<TAX_SalesTaxReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
