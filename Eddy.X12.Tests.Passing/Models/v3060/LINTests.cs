using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIN*N*bC*u*CP*b*qY*O*T7*O*uD*M*UL*Q*fw*n*Tk*G*sG*d*1S*I*qo*k*JC*R*xD*8*2a*j*7V*Z";

		var expected = new LIN_ItemIdentification()
		{
			AssignedIdentification = "N",
			ProductServiceIDQualifier = "bC",
			ProductServiceID = "u",
			ProductServiceIDQualifier2 = "CP",
			ProductServiceID2 = "b",
			ProductServiceIDQualifier3 = "qY",
			ProductServiceID3 = "O",
			ProductServiceIDQualifier4 = "T7",
			ProductServiceID4 = "O",
			ProductServiceIDQualifier5 = "uD",
			ProductServiceID5 = "M",
			ProductServiceIDQualifier6 = "UL",
			ProductServiceID6 = "Q",
			ProductServiceIDQualifier7 = "fw",
			ProductServiceID7 = "n",
			ProductServiceIDQualifier8 = "Tk",
			ProductServiceID8 = "G",
			ProductServiceIDQualifier9 = "sG",
			ProductServiceID9 = "d",
			ProductServiceIDQualifier10 = "1S",
			ProductServiceID10 = "I",
			ProductServiceIDQualifier11 = "qo",
			ProductServiceID11 = "k",
			ProductServiceIDQualifier12 = "JC",
			ProductServiceID12 = "R",
			ProductServiceIDQualifier13 = "xD",
			ProductServiceID13 = "8",
			ProductServiceIDQualifier14 = "2a",
			ProductServiceID14 = "j",
			ProductServiceIDQualifier15 = "7V",
			ProductServiceID15 = "Z",
		};

		var actual = Map.MapObject<LIN_ItemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bC", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CP", "b", true)]
	[InlineData("CP", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qY", "O", true)]
	[InlineData("qY", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T7", "O", true)]
	[InlineData("T7", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uD", "M", true)]
	[InlineData("uD", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("UL", "Q", true)]
	[InlineData("UL", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fw", "n", true)]
	[InlineData("fw", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Tk", "G", true)]
	[InlineData("Tk", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sG", "d", true)]
	[InlineData("sG", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1S", "I", true)]
	[InlineData("1S", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qo", "k", true)]
	[InlineData("qo", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier11(string productServiceIDQualifier11, string productServiceID11, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier11 = productServiceIDQualifier11;
		subject.ProductServiceID11 = productServiceID11;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JC", "R", true)]
	[InlineData("JC", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier12(string productServiceIDQualifier12, string productServiceID12, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier12 = productServiceIDQualifier12;
		subject.ProductServiceID12 = productServiceID12;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xD", "8", true)]
	[InlineData("xD", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier13(string productServiceIDQualifier13, string productServiceID13, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier13 = productServiceIDQualifier13;
		subject.ProductServiceID13 = productServiceID13;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2a", "j", true)]
	[InlineData("2a", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier14(string productServiceIDQualifier14, string productServiceID14, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier14 = productServiceIDQualifier14;
		subject.ProductServiceID14 = productServiceID14;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "7V";
			subject.ProductServiceID15 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7V", "Z", true)]
	[InlineData("7V", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier15(string productServiceIDQualifier15, string productServiceID15, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "bC";
		subject.ProductServiceID = "u";
		subject.ProductServiceIDQualifier15 = productServiceIDQualifier15;
		subject.ProductServiceID15 = productServiceID15;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CP";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "qY";
			subject.ProductServiceID3 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "T7";
			subject.ProductServiceID4 = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "uD";
			subject.ProductServiceID5 = "M";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UL";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "fw";
			subject.ProductServiceID7 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Tk";
			subject.ProductServiceID8 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "sG";
			subject.ProductServiceID9 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "1S";
			subject.ProductServiceID10 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "qo";
			subject.ProductServiceID11 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "JC";
			subject.ProductServiceID12 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "xD";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "2a";
			subject.ProductServiceID14 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
