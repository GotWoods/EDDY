using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class REPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REP*n*Eg*H*iv*l*P2*3*n*r*V4*P*Z*hQ*F*Q*m*sL*5*e*V";

		var expected = new REP_RepairAction()
		{
			AssignedIdentification = "n",
			ProductServiceIDQualifier = "Eg",
			ProductServiceID = "H",
			ProductServiceIDQualifier2 = "iv",
			ProductServiceID2 = "l",
			AgencyQualifierCode = "P2",
			SourceSubqualifier = "3",
			RepairActionCode = "n",
			Description = "r",
			AgencyQualifierCode2 = "V4",
			SourceSubqualifier2 = "P",
			RepairComplexityCode = "Z",
			ProductServiceIDQualifier3 = "hQ",
			ProductServiceID3 = "F",
			RepairActionCode2 = "Q",
			Description2 = "m",
			AgencyQualifierCode3 = "sL",
			SourceSubqualifier3 = "5",
			ReferenceIdentification = "e",
			AuthorizationIdentification = "V",
		};

		var actual = Map.MapObject<REP_RepairAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Eg", "H", true)]
	[InlineData("Eg", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iv";
			subject.ProductServiceID2 = "l";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "hQ";
			subject.ProductServiceID3 = "F";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Q";
			subject.ProductServiceID3 = "F";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "F";
			subject.RepairActionCode2 = "Q";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iv", "l", true)]
	[InlineData("iv", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//A Requires B
		if (productServiceID2 != "")
			subject.ProductServiceID = "H";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eg";
			subject.ProductServiceID = "H";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "hQ";
			subject.ProductServiceID3 = "F";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Q";
			subject.ProductServiceID3 = "F";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "F";
			subject.RepairActionCode2 = "Q";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "H", true)]
	[InlineData("l", "", false)]
	[InlineData("", "H", true)]
	public void Validation_ARequiresBProductServiceID2(string productServiceID2, string productServiceID, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceID2 = productServiceID2;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eg";
			subject.ProductServiceID = "H";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iv";
			subject.ProductServiceID2 = "l";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "hQ";
			subject.ProductServiceID3 = "F";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Q";
			subject.ProductServiceID3 = "F";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "F";
			subject.RepairActionCode2 = "Q";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P2", "n", true)]
	[InlineData("P2", "", false)]
	[InlineData("", "n", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string repairActionCode, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.RepairActionCode = repairActionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eg";
			subject.ProductServiceID = "H";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iv";
			subject.ProductServiceID2 = "l";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "hQ";
			subject.ProductServiceID3 = "F";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Q";
			subject.ProductServiceID3 = "F";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "F";
			subject.RepairActionCode2 = "Q";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3", "P2", true)]
	[InlineData("3", "", false)]
	[InlineData("", "P2", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.RepairActionCode = "n";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eg";
			subject.ProductServiceID = "H";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iv";
			subject.ProductServiceID2 = "l";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "hQ";
			subject.ProductServiceID3 = "F";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Q";
			subject.ProductServiceID3 = "F";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "F";
			subject.RepairActionCode2 = "Q";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V4", "Z", true)]
	[InlineData("V4", "", false)]
	[InlineData("", "Z", true)]
	public void Validation_ARequiresBAgencyQualifierCode2(string agencyQualifierCode2, string repairComplexityCode, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		subject.RepairComplexityCode = repairComplexityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eg";
			subject.ProductServiceID = "H";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iv";
			subject.ProductServiceID2 = "l";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "hQ";
			subject.ProductServiceID3 = "F";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Q";
			subject.ProductServiceID3 = "F";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "F";
			subject.RepairActionCode2 = "Q";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "V4", true)]
	[InlineData("P", "", false)]
	[InlineData("", "V4", true)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		//A Requires B
		if (agencyQualifierCode2 != "")
			subject.RepairComplexityCode = "Z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eg";
			subject.ProductServiceID = "H";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iv";
			subject.ProductServiceID2 = "l";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "hQ";
			subject.ProductServiceID3 = "F";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Q";
			subject.ProductServiceID3 = "F";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "F";
			subject.RepairActionCode2 = "Q";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hQ", "F", true)]
	[InlineData("hQ", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eg";
			subject.ProductServiceID = "H";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iv";
			subject.ProductServiceID2 = "l";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Q";
			subject.ProductServiceID3 = "F";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.RepairActionCode2 = "Q";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("F", "Q", "m", true)]
	[InlineData("", "Q", "m", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ProductServiceID3(string productServiceID3, string repairActionCode2, string description2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceID3 = productServiceID3;
		subject.RepairActionCode2 = repairActionCode2;
		subject.Description2 = description2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eg";
			subject.ProductServiceID = "H";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iv";
			subject.ProductServiceID2 = "l";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "hQ";
			subject.ProductServiceID3 = "F";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Q";
			subject.ProductServiceID3 = "F";
		}

        if (subject.ProductServiceID3 != "")
            subject.ProductServiceIDQualifier3 = "Kc";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q", "F", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredRepairActionCode2(string repairActionCode2, string productServiceID3, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.RepairActionCode2 = repairActionCode2;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eg";
			subject.ProductServiceID = "H";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iv";
			subject.ProductServiceID2 = "l";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "hQ";
			subject.ProductServiceID3 = "F";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sL", "e", true)]
	[InlineData("sL", "", false)]
	[InlineData("", "e", true)]
	public void Validation_ARequiresBAgencyQualifierCode3(string agencyQualifierCode3, string referenceIdentification, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eg";
			subject.ProductServiceID = "H";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iv";
			subject.ProductServiceID2 = "l";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "hQ";
			subject.ProductServiceID3 = "F";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Q";
			subject.ProductServiceID3 = "F";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "F";
			subject.RepairActionCode2 = "Q";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "sL", true)]
	[InlineData("5", "", false)]
	[InlineData("", "sL", true)]
	public void Validation_ARequiresBSourceSubqualifier3(string sourceSubqualifier3, string agencyQualifierCode3, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier3 = sourceSubqualifier3;
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		//A Requires B
		if (agencyQualifierCode3 != "")
			subject.ReferenceIdentification = "e";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Eg";
			subject.ProductServiceID = "H";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iv";
			subject.ProductServiceID2 = "l";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "hQ";
			subject.ProductServiceID3 = "F";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Q";
			subject.ProductServiceID3 = "F";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "F";
			subject.RepairActionCode2 = "Q";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
