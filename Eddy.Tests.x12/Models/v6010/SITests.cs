using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class SITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SI*jK*hS*7*77*O*fY*T*uD*d*tN*P*Ra*5*pc*D*cw*E*q2*T*3P*a";

		var expected = new SI_ServiceCharacteristicIdentification()
		{
			AgencyQualifierCode = "jK",
			ServiceCharacteristicsQualifier = "hS",
			ProductServiceID = "7",
			ServiceCharacteristicsQualifier2 = "77",
			ProductServiceID2 = "O",
			ServiceCharacteristicsQualifier3 = "fY",
			ProductServiceID3 = "T",
			ServiceCharacteristicsQualifier4 = "uD",
			ProductServiceID4 = "d",
			ServiceCharacteristicsQualifier5 = "tN",
			ProductServiceID5 = "P",
			ServiceCharacteristicsQualifier6 = "Ra",
			ProductServiceID6 = "5",
			ServiceCharacteristicsQualifier7 = "pc",
			ProductServiceID7 = "D",
			ServiceCharacteristicsQualifier8 = "cw",
			ProductServiceID8 = "E",
			ServiceCharacteristicsQualifier9 = "q2",
			ProductServiceID9 = "T",
			ServiceCharacteristicsQualifier10 = "3P",
			ProductServiceID10 = "a",
		};

		var actual = Map.MapObject<SI_ServiceCharacteristicIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jK", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.ServiceCharacteristicsQualifier = "hS";
		subject.ProductServiceID = "7";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "77";
			subject.ProductServiceID2 = "O";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "fY";
			subject.ProductServiceID3 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "uD";
			subject.ProductServiceID4 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "tN";
			subject.ProductServiceID5 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Ra";
			subject.ProductServiceID6 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "pc";
			subject.ProductServiceID7 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "cw";
			subject.ProductServiceID8 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "q2";
			subject.ProductServiceID9 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3P";
			subject.ProductServiceID10 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hS", true)]
	public void Validation_RequiredServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "jK";
		subject.ProductServiceID = "7";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier = serviceCharacteristicsQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "77";
			subject.ProductServiceID2 = "O";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "fY";
			subject.ProductServiceID3 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "uD";
			subject.ProductServiceID4 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "tN";
			subject.ProductServiceID5 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Ra";
			subject.ProductServiceID6 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "pc";
			subject.ProductServiceID7 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "cw";
			subject.ProductServiceID8 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "q2";
			subject.ProductServiceID9 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3P";
			subject.ProductServiceID10 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "jK";
		subject.ServiceCharacteristicsQualifier = "hS";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "77";
			subject.ProductServiceID2 = "O";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "fY";
			subject.ProductServiceID3 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "uD";
			subject.ProductServiceID4 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "tN";
			subject.ProductServiceID5 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Ra";
			subject.ProductServiceID6 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "pc";
			subject.ProductServiceID7 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "cw";
			subject.ProductServiceID8 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "q2";
			subject.ProductServiceID9 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3P";
			subject.ProductServiceID10 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("77", "O", true)]
	[InlineData("77", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier2(string serviceCharacteristicsQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "jK";
		subject.ServiceCharacteristicsQualifier = "hS";
		subject.ProductServiceID = "7";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier2 = serviceCharacteristicsQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "fY";
			subject.ProductServiceID3 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "uD";
			subject.ProductServiceID4 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "tN";
			subject.ProductServiceID5 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Ra";
			subject.ProductServiceID6 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "pc";
			subject.ProductServiceID7 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "cw";
			subject.ProductServiceID8 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "q2";
			subject.ProductServiceID9 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3P";
			subject.ProductServiceID10 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fY", "T", true)]
	[InlineData("fY", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier3(string serviceCharacteristicsQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "jK";
		subject.ServiceCharacteristicsQualifier = "hS";
		subject.ProductServiceID = "7";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier3 = serviceCharacteristicsQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "77";
			subject.ProductServiceID2 = "O";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "uD";
			subject.ProductServiceID4 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "tN";
			subject.ProductServiceID5 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Ra";
			subject.ProductServiceID6 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "pc";
			subject.ProductServiceID7 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "cw";
			subject.ProductServiceID8 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "q2";
			subject.ProductServiceID9 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3P";
			subject.ProductServiceID10 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uD", "d", true)]
	[InlineData("uD", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier4(string serviceCharacteristicsQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "jK";
		subject.ServiceCharacteristicsQualifier = "hS";
		subject.ProductServiceID = "7";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier4 = serviceCharacteristicsQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "77";
			subject.ProductServiceID2 = "O";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "fY";
			subject.ProductServiceID3 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "tN";
			subject.ProductServiceID5 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Ra";
			subject.ProductServiceID6 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "pc";
			subject.ProductServiceID7 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "cw";
			subject.ProductServiceID8 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "q2";
			subject.ProductServiceID9 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3P";
			subject.ProductServiceID10 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("tN", "P", true)]
	[InlineData("tN", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier5(string serviceCharacteristicsQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "jK";
		subject.ServiceCharacteristicsQualifier = "hS";
		subject.ProductServiceID = "7";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier5 = serviceCharacteristicsQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "77";
			subject.ProductServiceID2 = "O";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "fY";
			subject.ProductServiceID3 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "uD";
			subject.ProductServiceID4 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Ra";
			subject.ProductServiceID6 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "pc";
			subject.ProductServiceID7 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "cw";
			subject.ProductServiceID8 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "q2";
			subject.ProductServiceID9 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3P";
			subject.ProductServiceID10 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ra", "5", true)]
	[InlineData("Ra", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier6(string serviceCharacteristicsQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "jK";
		subject.ServiceCharacteristicsQualifier = "hS";
		subject.ProductServiceID = "7";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier6 = serviceCharacteristicsQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "77";
			subject.ProductServiceID2 = "O";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "fY";
			subject.ProductServiceID3 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "uD";
			subject.ProductServiceID4 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "tN";
			subject.ProductServiceID5 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "pc";
			subject.ProductServiceID7 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "cw";
			subject.ProductServiceID8 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "q2";
			subject.ProductServiceID9 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3P";
			subject.ProductServiceID10 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pc", "D", true)]
	[InlineData("pc", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier7(string serviceCharacteristicsQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "jK";
		subject.ServiceCharacteristicsQualifier = "hS";
		subject.ProductServiceID = "7";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier7 = serviceCharacteristicsQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "77";
			subject.ProductServiceID2 = "O";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "fY";
			subject.ProductServiceID3 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "uD";
			subject.ProductServiceID4 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "tN";
			subject.ProductServiceID5 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Ra";
			subject.ProductServiceID6 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "cw";
			subject.ProductServiceID8 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "q2";
			subject.ProductServiceID9 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3P";
			subject.ProductServiceID10 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cw", "E", true)]
	[InlineData("cw", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier8(string serviceCharacteristicsQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "jK";
		subject.ServiceCharacteristicsQualifier = "hS";
		subject.ProductServiceID = "7";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier8 = serviceCharacteristicsQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "77";
			subject.ProductServiceID2 = "O";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "fY";
			subject.ProductServiceID3 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "uD";
			subject.ProductServiceID4 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "tN";
			subject.ProductServiceID5 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Ra";
			subject.ProductServiceID6 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "pc";
			subject.ProductServiceID7 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "q2";
			subject.ProductServiceID9 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3P";
			subject.ProductServiceID10 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q2", "T", true)]
	[InlineData("q2", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier9(string serviceCharacteristicsQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "jK";
		subject.ServiceCharacteristicsQualifier = "hS";
		subject.ProductServiceID = "7";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier9 = serviceCharacteristicsQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "77";
			subject.ProductServiceID2 = "O";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "fY";
			subject.ProductServiceID3 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "uD";
			subject.ProductServiceID4 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "tN";
			subject.ProductServiceID5 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Ra";
			subject.ProductServiceID6 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "pc";
			subject.ProductServiceID7 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "cw";
			subject.ProductServiceID8 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "3P";
			subject.ProductServiceID10 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3P", "a", true)]
	[InlineData("3P", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier10(string serviceCharacteristicsQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "jK";
		subject.ServiceCharacteristicsQualifier = "hS";
		subject.ProductServiceID = "7";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier10 = serviceCharacteristicsQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "77";
			subject.ProductServiceID2 = "O";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "fY";
			subject.ProductServiceID3 = "T";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "uD";
			subject.ProductServiceID4 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "tN";
			subject.ProductServiceID5 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "Ra";
			subject.ProductServiceID6 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "pc";
			subject.ProductServiceID7 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "cw";
			subject.ProductServiceID8 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "q2";
			subject.ProductServiceID9 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
