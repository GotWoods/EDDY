using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class LINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIN*6*7Z*B*LL*I*PM*c*p5*T*Xb*b*J9*f*Yt*9*bI*2*iq*B*nm*g*wm*g*c1*S*hq*k*pZ*P*8v*8";

		var expected = new LIN_ItemIdentification()
		{
			AssignedIdentification = "6",
			ProductServiceIDQualifier = "7Z",
			ProductServiceID = "B",
			ProductServiceIDQualifier2 = "LL",
			ProductServiceID2 = "I",
			ProductServiceIDQualifier3 = "PM",
			ProductServiceID3 = "c",
			ProductServiceIDQualifier4 = "p5",
			ProductServiceID4 = "T",
			ProductServiceIDQualifier5 = "Xb",
			ProductServiceID5 = "b",
			ProductServiceIDQualifier6 = "J9",
			ProductServiceID6 = "f",
			ProductServiceIDQualifier7 = "Yt",
			ProductServiceID7 = "9",
			ProductServiceIDQualifier8 = "bI",
			ProductServiceID8 = "2",
			ProductServiceIDQualifier9 = "iq",
			ProductServiceID9 = "B",
			ProductServiceIDQualifier10 = "nm",
			ProductServiceID10 = "g",
			ProductServiceIDQualifier11 = "wm",
			ProductServiceID11 = "g",
			ProductServiceIDQualifier12 = "c1",
			ProductServiceID12 = "S",
			ProductServiceIDQualifier13 = "hq",
			ProductServiceID13 = "k",
			ProductServiceIDQualifier14 = "pZ",
			ProductServiceID14 = "P",
			ProductServiceIDQualifier15 = "8v",
			ProductServiceID15 = "8",
		};

		var actual = Map.MapObject<LIN_ItemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7Z", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceID = "B";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "7Z";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
