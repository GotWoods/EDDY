using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class LINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIN*F*vz*7*e9*D*Il*Y*GO*I*cf*a*sO*q*Td*a*KE*i*4Z*G*ZP*X*5s*2*ek*h*Vs*8*v2*3*gh*O";

		var expected = new LIN_ItemIdentification()
		{
			AssignedIdentification = "F",
			ProductServiceIDQualifier = "vz",
			ProductServiceID = "7",
			ProductServiceIDQualifier2 = "e9",
			ProductServiceID2 = "D",
			ProductServiceIDQualifier3 = "Il",
			ProductServiceID3 = "Y",
			ProductServiceIDQualifier4 = "GO",
			ProductServiceID4 = "I",
			ProductServiceIDQualifier5 = "cf",
			ProductServiceID5 = "a",
			ProductServiceIDQualifier6 = "sO",
			ProductServiceID6 = "q",
			ProductServiceIDQualifier7 = "Td",
			ProductServiceID7 = "a",
			ProductServiceIDQualifier8 = "KE",
			ProductServiceID8 = "i",
			ProductServiceIDQualifier9 = "4Z",
			ProductServiceID9 = "G",
			ProductServiceIDQualifier10 = "ZP",
			ProductServiceID10 = "X",
			ProductServiceIDQualifier11 = "5s",
			ProductServiceID11 = "2",
			ProductServiceIDQualifier12 = "ek",
			ProductServiceID12 = "h",
			ProductServiceIDQualifier13 = "Vs",
			ProductServiceID13 = "8",
			ProductServiceIDQualifier14 = "v2",
			ProductServiceID14 = "3",
			ProductServiceIDQualifier15 = "gh",
			ProductServiceID15 = "O",
		};

		var actual = Map.MapObject<LIN_ItemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vz", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e9", "D", true)]
	[InlineData("e9", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Il", "Y", true)]
	[InlineData("Il", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GO", "I", true)]
	[InlineData("GO", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cf", "a", true)]
	[InlineData("cf", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sO", "q", true)]
	[InlineData("sO", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Td", "a", true)]
	[InlineData("Td", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KE", "i", true)]
	[InlineData("KE", "", false)]
	[InlineData("", "i", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4Z", "G", true)]
	[InlineData("4Z", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZP", "X", true)]
	[InlineData("ZP", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5s", "2", true)]
	[InlineData("5s", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier11(string productServiceIDQualifier11, string productServiceID11, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier11 = productServiceIDQualifier11;
		subject.ProductServiceID11 = productServiceID11;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ek", "h", true)]
	[InlineData("ek", "", false)]
	[InlineData("", "h", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier12(string productServiceIDQualifier12, string productServiceID12, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier12 = productServiceIDQualifier12;
		subject.ProductServiceID12 = productServiceID12;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Vs", "8", true)]
	[InlineData("Vs", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier13(string productServiceIDQualifier13, string productServiceID13, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier13 = productServiceIDQualifier13;
		subject.ProductServiceID13 = productServiceID13;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v2", "3", true)]
	[InlineData("v2", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier14(string productServiceIDQualifier14, string productServiceID14, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier14 = productServiceIDQualifier14;
		subject.ProductServiceID14 = productServiceID14;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "gh";
			subject.ProductServiceID15 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gh", "O", true)]
	[InlineData("gh", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier15(string productServiceIDQualifier15, string productServiceID15, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "vz";
		subject.ProductServiceID = "7";
		subject.ProductServiceIDQualifier15 = productServiceIDQualifier15;
		subject.ProductServiceID15 = productServiceID15;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "e9";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Il";
			subject.ProductServiceID3 = "Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "GO";
			subject.ProductServiceID4 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "cf";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "sO";
			subject.ProductServiceID6 = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "Td";
			subject.ProductServiceID7 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "KE";
			subject.ProductServiceID8 = "i";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "4Z";
			subject.ProductServiceID9 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "ZP";
			subject.ProductServiceID10 = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "5s";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "ek";
			subject.ProductServiceID12 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "Vs";
			subject.ProductServiceID13 = "8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "v2";
			subject.ProductServiceID14 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
