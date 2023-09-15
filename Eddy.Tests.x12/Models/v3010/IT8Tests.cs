using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class IT8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT8*n*W*Wd*9*7spTY6*SI*i*ao*Q*ir*N*Hw*B*RT*u*Ij*2*rx*7*mE*0*zh*n*uK*N*r2*v";

		var expected = new IT8_ConditionsOfSale()
		{
			SalesRequirementCode = "n",
			DoNotExceedActionCode = "W",
			DoNotExceedAmount = "Wd",
			AccountNumber = "9",
			RequiredInvoiceDate = "7spTY6",
			AssociationQualifierCode = "SI",
			ProductServiceSubstitutionCode = "i",
			ProductServiceIDQualifier = "ao",
			ProductServiceID = "Q",
			ProductServiceIDQualifier2 = "ir",
			ProductServiceID2 = "N",
			ProductServiceIDQualifier3 = "Hw",
			ProductServiceID3 = "B",
			ProductServiceIDQualifier4 = "RT",
			ProductServiceID4 = "u",
			ProductServiceIDQualifier5 = "Ij",
			ProductServiceID5 = "2",
			ProductServiceIDQualifier6 = "rx",
			ProductServiceID6 = "7",
			ProductServiceIDQualifier7 = "mE",
			ProductServiceID7 = "0",
			ProductServiceIDQualifier8 = "zh",
			ProductServiceID8 = "n",
			ProductServiceIDQualifier9 = "uK",
			ProductServiceID9 = "N",
			ProductServiceIDQualifier10 = "r2",
			ProductServiceID10 = "v",
		};

		var actual = Map.MapObject<IT8_ConditionsOfSale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
