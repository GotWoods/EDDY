using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class POCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "POC*S*9K*5*3*nV*6*jw*RW*2*8Z*A*vk*g*VJ*e*TK*F*Nw*E*ZU*Q*q4*t*mH*B*sg*7";

		var expected = new POC_LineItemChange()
		{
			AssignedIdentification = "S",
			ChangeOrResponseTypeCode = "9K",
			QuantityOrdered = 5,
			QuantityLeftToReceive = 3,
			UnitOfMeasurementCode = "nV",
			UnitPrice = 6,
			BasisOfUnitPriceCode = "jw",
			ProductServiceIDQualifier = "RW",
			ProductServiceID = "2",
			ProductServiceIDQualifier2 = "8Z",
			ProductServiceID2 = "A",
			ProductServiceIDQualifier3 = "vk",
			ProductServiceID3 = "g",
			ProductServiceIDQualifier4 = "VJ",
			ProductServiceID4 = "e",
			ProductServiceIDQualifier5 = "TK",
			ProductServiceID5 = "F",
			ProductServiceIDQualifier6 = "Nw",
			ProductServiceID6 = "E",
			ProductServiceIDQualifier7 = "ZU",
			ProductServiceID7 = "Q",
			ProductServiceIDQualifier8 = "q4",
			ProductServiceID8 = "t",
			ProductServiceIDQualifier9 = "mH",
			ProductServiceID9 = "B",
			ProductServiceIDQualifier10 = "sg",
			ProductServiceID10 = "7",
		};

		var actual = Map.MapObject<POC_LineItemChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9K", true)]
	public void Validation_RequiredChangeOrResponseTypeCode(string changeOrResponseTypeCode, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		//Test Parameters
		subject.ChangeOrResponseTypeCode = changeOrResponseTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
