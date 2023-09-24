using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class LINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIN*h*ai*o*Ek*T*bl*2*gE*r*9I*h*9a*P*U4*R*Cs*m*GG*0*Qg*7*SS*v*dO*D*ek*k*Fh*j*Ix*u";

		var expected = new LIN_ItemIdentification()
		{
			AssignedIdentification = "h",
			ProductServiceIDQualifier = "ai",
			ProductServiceID = "o",
			ProductServiceIDQualifier2 = "Ek",
			ProductServiceID2 = "T",
			ProductServiceIDQualifier3 = "bl",
			ProductServiceID3 = "2",
			ProductServiceIDQualifier4 = "gE",
			ProductServiceID4 = "r",
			ProductServiceIDQualifier5 = "9I",
			ProductServiceID5 = "h",
			ProductServiceIDQualifier6 = "9a",
			ProductServiceID6 = "P",
			ProductServiceIDQualifier7 = "U4",
			ProductServiceID7 = "R",
			ProductServiceIDQualifier8 = "Cs",
			ProductServiceID8 = "m",
			ProductServiceIDQualifier9 = "GG",
			ProductServiceID9 = "0",
			ProductServiceIDQualifier10 = "Qg",
			ProductServiceID10 = "7",
			ProductServiceIDQualifier11 = "SS",
			ProductServiceID11 = "v",
			ProductServiceIDQualifier12 = "dO",
			ProductServiceID12 = "D",
			ProductServiceIDQualifier13 = "ek",
			ProductServiceID13 = "k",
			ProductServiceIDQualifier14 = "Fh",
			ProductServiceID14 = "j",
			ProductServiceIDQualifier15 = "Ix",
			ProductServiceID15 = "u",
		};

		var actual = Map.MapObject<LIN_ItemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ai", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ek", "T", true)]
	[InlineData("Ek", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bl", "2", true)]
	[InlineData("bl", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gE", "r", true)]
	[InlineData("gE", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9I", "h", true)]
	[InlineData("9I", "", false)]
	[InlineData("", "h", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9a", "P", true)]
	[InlineData("9a", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U4", "R", true)]
	[InlineData("U4", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Cs", "m", true)]
	[InlineData("Cs", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GG", "0", true)]
	[InlineData("GG", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Qg", "7", true)]
	[InlineData("Qg", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("SS", "v", true)]
	[InlineData("SS", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier11(string productServiceIDQualifier11, string productServiceID11, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier11 = productServiceIDQualifier11;
		subject.ProductServiceID11 = productServiceID11;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dO", "D", true)]
	[InlineData("dO", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier12(string productServiceIDQualifier12, string productServiceID12, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier12 = productServiceIDQualifier12;
		subject.ProductServiceID12 = productServiceID12;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ek", "k", true)]
	[InlineData("ek", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier13(string productServiceIDQualifier13, string productServiceID13, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier13 = productServiceIDQualifier13;
		subject.ProductServiceID13 = productServiceID13;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Fh", "j", true)]
	[InlineData("Fh", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier14(string productServiceIDQualifier14, string productServiceID14, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier14 = productServiceIDQualifier14;
		subject.ProductServiceID14 = productServiceID14;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "Ix";
			subject.ProductServiceID15 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ix", "u", true)]
	[InlineData("Ix", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier15(string productServiceIDQualifier15, string productServiceID15, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "ai";
		subject.ProductServiceID = "o";
		subject.ProductServiceIDQualifier15 = productServiceIDQualifier15;
		subject.ProductServiceID15 = productServiceID15;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ek";
			subject.ProductServiceID2 = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bl";
			subject.ProductServiceID3 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "gE";
			subject.ProductServiceID4 = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "9I";
			subject.ProductServiceID5 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "9a";
			subject.ProductServiceID6 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "U4";
			subject.ProductServiceID7 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Cs";
			subject.ProductServiceID8 = "m";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "GG";
			subject.ProductServiceID9 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Qg";
			subject.ProductServiceID10 = "7";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "SS";
			subject.ProductServiceID11 = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "dO";
			subject.ProductServiceID12 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "ek";
			subject.ProductServiceID13 = "k";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Fh";
			subject.ProductServiceID14 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
