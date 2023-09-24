using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class LINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIN*d*wm*0*w5*G*5c*f*Z8*a*Pd*Q*UU*Z*HP*J*DQ*a*5L*n*zh*0*i4*2*Xt*4*9f*p*Lb*t*pJ*j";

		var expected = new LIN_ItemIdentification()
		{
			AssignedIdentification = "d",
			ProductServiceIDQualifier = "wm",
			ProductServiceID = "0",
			ProductServiceIDQualifier2 = "w5",
			ProductServiceID2 = "G",
			ProductServiceIDQualifier3 = "5c",
			ProductServiceID3 = "f",
			ProductServiceIDQualifier4 = "Z8",
			ProductServiceID4 = "a",
			ProductServiceIDQualifier5 = "Pd",
			ProductServiceID5 = "Q",
			ProductServiceIDQualifier6 = "UU",
			ProductServiceID6 = "Z",
			ProductServiceIDQualifier7 = "HP",
			ProductServiceID7 = "J",
			ProductServiceIDQualifier8 = "DQ",
			ProductServiceID8 = "a",
			ProductServiceIDQualifier9 = "5L",
			ProductServiceID9 = "n",
			ProductServiceIDQualifier10 = "zh",
			ProductServiceID10 = "0",
			ProductServiceIDQualifier11 = "i4",
			ProductServiceID11 = "2",
			ProductServiceIDQualifier12 = "Xt",
			ProductServiceID12 = "4",
			ProductServiceIDQualifier13 = "9f",
			ProductServiceID13 = "p",
			ProductServiceIDQualifier14 = "Lb",
			ProductServiceID14 = "t",
			ProductServiceIDQualifier15 = "pJ",
			ProductServiceID15 = "j",
		};

		var actual = Map.MapObject<LIN_ItemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wm", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w5", "G", true)]
	[InlineData("w5", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5c", "f", true)]
	[InlineData("5c", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z8", "a", true)]
	[InlineData("Z8", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Pd", "Q", true)]
	[InlineData("Pd", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("UU", "Z", true)]
	[InlineData("UU", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HP", "J", true)]
	[InlineData("HP", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DQ", "a", true)]
	[InlineData("DQ", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5L", "n", true)]
	[InlineData("5L", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zh", "0", true)]
	[InlineData("zh", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i4", "2", true)]
	[InlineData("i4", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier11(string productServiceIDQualifier11, string productServiceID11, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier11 = productServiceIDQualifier11;
		subject.ProductServiceID11 = productServiceID11;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xt", "4", true)]
	[InlineData("Xt", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier12(string productServiceIDQualifier12, string productServiceID12, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier12 = productServiceIDQualifier12;
		subject.ProductServiceID12 = productServiceID12;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9f", "p", true)]
	[InlineData("9f", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier13(string productServiceIDQualifier13, string productServiceID13, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier13 = productServiceIDQualifier13;
		subject.ProductServiceID13 = productServiceID13;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Lb", "t", true)]
	[InlineData("Lb", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier14(string productServiceIDQualifier14, string productServiceID14, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier14 = productServiceIDQualifier14;
		subject.ProductServiceID14 = productServiceID14;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier15) || !string.IsNullOrEmpty(subject.ProductServiceID15))
		{
			subject.ProductServiceIDQualifier15 = "pJ";
			subject.ProductServiceID15 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pJ", "j", true)]
	[InlineData("pJ", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier15(string productServiceIDQualifier15, string productServiceID15, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "wm";
		subject.ProductServiceID = "0";
		subject.ProductServiceIDQualifier15 = productServiceIDQualifier15;
		subject.ProductServiceID15 = productServiceID15;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "w5";
			subject.ProductServiceID2 = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "5c";
			subject.ProductServiceID3 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Z8";
			subject.ProductServiceID4 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Pd";
			subject.ProductServiceID5 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "UU";
			subject.ProductServiceID6 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "HP";
			subject.ProductServiceID7 = "J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "DQ";
			subject.ProductServiceID8 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "5L";
			subject.ProductServiceID9 = "n";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "zh";
			subject.ProductServiceID10 = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier11) || !string.IsNullOrEmpty(subject.ProductServiceID11))
		{
			subject.ProductServiceIDQualifier11 = "i4";
			subject.ProductServiceID11 = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier12) || !string.IsNullOrEmpty(subject.ProductServiceID12))
		{
			subject.ProductServiceIDQualifier12 = "Xt";
			subject.ProductServiceID12 = "4";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier13) || !string.IsNullOrEmpty(subject.ProductServiceID13))
		{
			subject.ProductServiceIDQualifier13 = "9f";
			subject.ProductServiceID13 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier14) || !string.IsNullOrEmpty(subject.ProductServiceID14))
		{
			subject.ProductServiceIDQualifier14 = "Lb";
			subject.ProductServiceID14 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
