using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SI*a5*9G*A*Oj*k*NW*C*J3*a*U5*I*Mi*U*zo*e*Yu*V*6c*d*3L*G";

		var expected = new SI_ServiceCharacteristicIdentification()
		{
			AgencyQualifierCode = "a5",
			ServiceCharacteristicsQualifier = "9G",
			ProductServiceID = "A",
			ServiceCharacteristicsQualifier2 = "Oj",
			ProductServiceID2 = "k",
			ServiceCharacteristicsQualifier3 = "NW",
			ProductServiceID3 = "C",
			ServiceCharacteristicsQualifier4 = "J3",
			ProductServiceID4 = "a",
			ServiceCharacteristicsQualifier5 = "U5",
			ProductServiceID5 = "I",
			ServiceCharacteristicsQualifier6 = "Mi",
			ProductServiceID6 = "U",
			ServiceCharacteristicsQualifier7 = "zo",
			ProductServiceID7 = "e",
			ServiceCharacteristicsQualifier8 = "Yu",
			ProductServiceID8 = "V",
			ServiceCharacteristicsQualifier9 = "6c",
			ProductServiceID9 = "d",
			ServiceCharacteristicsQualifier10 = "3L",
			ProductServiceID10 = "G",
		};

		var actual = Map.MapObject<SI_ServiceCharacteristicIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a5", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.ServiceCharacteristicsQualifier = "9G";
		subject.ProductServiceID = "A";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Oj";
			subject.ProductServiceID2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "NW";
			subject.ProductServiceID3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "J3";
			subject.ProductServiceID4 = "a";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "U5";
			subject.ProductServiceID5 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Mi";
			subject.ProductServiceID6 = "U";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "zo";
			subject.ProductServiceID7 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "Yu";
			subject.ProductServiceID8 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "6c";
			subject.ProductServiceID9 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3L";
			subject.ProductServiceID10 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9G", true)]
	public void Validation_RequiredServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "a5";
		subject.ProductServiceID = "A";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier = serviceCharacteristicsQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Oj";
			subject.ProductServiceID2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "NW";
			subject.ProductServiceID3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "J3";
			subject.ProductServiceID4 = "a";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "U5";
			subject.ProductServiceID5 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Mi";
			subject.ProductServiceID6 = "U";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "zo";
			subject.ProductServiceID7 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "Yu";
			subject.ProductServiceID8 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "6c";
			subject.ProductServiceID9 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3L";
			subject.ProductServiceID10 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "a5";
		subject.ServiceCharacteristicsQualifier = "9G";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Oj";
			subject.ProductServiceID2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "NW";
			subject.ProductServiceID3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "J3";
			subject.ProductServiceID4 = "a";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "U5";
			subject.ProductServiceID5 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Mi";
			subject.ProductServiceID6 = "U";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "zo";
			subject.ProductServiceID7 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "Yu";
			subject.ProductServiceID8 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "6c";
			subject.ProductServiceID9 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3L";
			subject.ProductServiceID10 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Oj", "k", true)]
	[InlineData("Oj", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier2(string serviceCharacteristicsQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "a5";
		subject.ServiceCharacteristicsQualifier = "9G";
		subject.ProductServiceID = "A";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier2 = serviceCharacteristicsQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "NW";
			subject.ProductServiceID3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "J3";
			subject.ProductServiceID4 = "a";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "U5";
			subject.ProductServiceID5 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Mi";
			subject.ProductServiceID6 = "U";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "zo";
			subject.ProductServiceID7 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "Yu";
			subject.ProductServiceID8 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "6c";
			subject.ProductServiceID9 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3L";
			subject.ProductServiceID10 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("NW", "C", true)]
	[InlineData("NW", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier3(string serviceCharacteristicsQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "a5";
		subject.ServiceCharacteristicsQualifier = "9G";
		subject.ProductServiceID = "A";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier3 = serviceCharacteristicsQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Oj";
			subject.ProductServiceID2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "J3";
			subject.ProductServiceID4 = "a";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "U5";
			subject.ProductServiceID5 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Mi";
			subject.ProductServiceID6 = "U";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "zo";
			subject.ProductServiceID7 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "Yu";
			subject.ProductServiceID8 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "6c";
			subject.ProductServiceID9 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3L";
			subject.ProductServiceID10 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J3", "a", true)]
	[InlineData("J3", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier4(string serviceCharacteristicsQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "a5";
		subject.ServiceCharacteristicsQualifier = "9G";
		subject.ProductServiceID = "A";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier4 = serviceCharacteristicsQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Oj";
			subject.ProductServiceID2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "NW";
			subject.ProductServiceID3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "U5";
			subject.ProductServiceID5 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Mi";
			subject.ProductServiceID6 = "U";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "zo";
			subject.ProductServiceID7 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "Yu";
			subject.ProductServiceID8 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "6c";
			subject.ProductServiceID9 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3L";
			subject.ProductServiceID10 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U5", "I", true)]
	[InlineData("U5", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier5(string serviceCharacteristicsQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "a5";
		subject.ServiceCharacteristicsQualifier = "9G";
		subject.ProductServiceID = "A";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier5 = serviceCharacteristicsQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Oj";
			subject.ProductServiceID2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "NW";
			subject.ProductServiceID3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "J3";
			subject.ProductServiceID4 = "a";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Mi";
			subject.ProductServiceID6 = "U";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "zo";
			subject.ProductServiceID7 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "Yu";
			subject.ProductServiceID8 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "6c";
			subject.ProductServiceID9 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3L";
			subject.ProductServiceID10 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Mi", "U", true)]
	[InlineData("Mi", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier6(string serviceCharacteristicsQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "a5";
		subject.ServiceCharacteristicsQualifier = "9G";
		subject.ProductServiceID = "A";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier6 = serviceCharacteristicsQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Oj";
			subject.ProductServiceID2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "NW";
			subject.ProductServiceID3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "J3";
			subject.ProductServiceID4 = "a";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "U5";
			subject.ProductServiceID5 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "zo";
			subject.ProductServiceID7 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "Yu";
			subject.ProductServiceID8 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "6c";
			subject.ProductServiceID9 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3L";
			subject.ProductServiceID10 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zo", "e", true)]
	[InlineData("zo", "", false)]
	[InlineData("", "e", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier7(string serviceCharacteristicsQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "a5";
		subject.ServiceCharacteristicsQualifier = "9G";
		subject.ProductServiceID = "A";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier7 = serviceCharacteristicsQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Oj";
			subject.ProductServiceID2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "NW";
			subject.ProductServiceID3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "J3";
			subject.ProductServiceID4 = "a";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "U5";
			subject.ProductServiceID5 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Mi";
			subject.ProductServiceID6 = "U";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "Yu";
			subject.ProductServiceID8 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "6c";
			subject.ProductServiceID9 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3L";
			subject.ProductServiceID10 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Yu", "V", true)]
	[InlineData("Yu", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier8(string serviceCharacteristicsQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "a5";
		subject.ServiceCharacteristicsQualifier = "9G";
		subject.ProductServiceID = "A";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier8 = serviceCharacteristicsQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Oj";
			subject.ProductServiceID2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "NW";
			subject.ProductServiceID3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "J3";
			subject.ProductServiceID4 = "a";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "U5";
			subject.ProductServiceID5 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Mi";
			subject.ProductServiceID6 = "U";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "zo";
			subject.ProductServiceID7 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "6c";
			subject.ProductServiceID9 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3L";
			subject.ProductServiceID10 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6c", "d", true)]
	[InlineData("6c", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier9(string serviceCharacteristicsQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "a5";
		subject.ServiceCharacteristicsQualifier = "9G";
		subject.ProductServiceID = "A";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier9 = serviceCharacteristicsQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Oj";
			subject.ProductServiceID2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "NW";
			subject.ProductServiceID3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "J3";
			subject.ProductServiceID4 = "a";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "U5";
			subject.ProductServiceID5 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Mi";
			subject.ProductServiceID6 = "U";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "zo";
			subject.ProductServiceID7 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "Yu";
			subject.ProductServiceID8 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3L";
			subject.ProductServiceID10 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3L", "G", true)]
	[InlineData("3L", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier10(string serviceCharacteristicsQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "a5";
		subject.ServiceCharacteristicsQualifier = "9G";
		subject.ProductServiceID = "A";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier10 = serviceCharacteristicsQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Oj";
			subject.ProductServiceID2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "NW";
			subject.ProductServiceID3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "J3";
			subject.ProductServiceID4 = "a";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "U5";
			subject.ProductServiceID5 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Mi";
			subject.ProductServiceID6 = "U";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "zo";
			subject.ProductServiceID7 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "Yu";
			subject.ProductServiceID8 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "6c";
			subject.ProductServiceID9 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
