using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class REPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REP*r*Vi*g*bn*d*X6*O*X*y*vr*V*F*ZI*k*Z*m*si*d*g*E";

		var expected = new REP_RepairAction()
		{
			AssignedIdentification = "r",
			ProductServiceIDQualifier = "Vi",
			ProductServiceID = "g",
			ProductServiceIDQualifier2 = "bn",
			ProductServiceID2 = "d",
			AgencyQualifierCode = "X6",
			SourceSubqualifier = "O",
			RepairActionCode = "X",
			Description = "y",
			AgencyQualifierCode2 = "vr",
			SourceSubqualifier2 = "V",
			RepairComplexityCode = "F",
			ProductServiceIDQualifier3 = "ZI",
			ProductServiceID3 = "k",
			RepairActionCode2 = "Z",
			Description2 = "m",
			AgencyQualifierCode3 = "si",
			SourceSubqualifier3 = "d",
			ReferenceIdentification = "g",
			AuthorizationIdentification = "E",
		};

		var actual = Map.MapObject<REP_RepairAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Vi", "g", true)]
	[InlineData("Vi", "", false)]
	[InlineData("", "g", false)]
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
			subject.ProductServiceIDQualifier2 = "bn";
			subject.ProductServiceID2 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ZI";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Z";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "Z";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bn", "d", true)]
	[InlineData("bn", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//A Requires B
		if (productServiceID2 != "")
			subject.ProductServiceID = "g";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Vi";
			subject.ProductServiceID = "g";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ZI";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Z";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "Z";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "g", true)]
	[InlineData("d", "", false)]
	[InlineData("", "g", true)]
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
			subject.ProductServiceIDQualifier = "Vi";
			subject.ProductServiceID = "g";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bn";
			subject.ProductServiceID2 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ZI";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Z";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "Z";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X6", "X", true)]
	[InlineData("X6", "", false)]
	[InlineData("", "X", true)]
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
			subject.ProductServiceIDQualifier = "Vi";
			subject.ProductServiceID = "g";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bn";
			subject.ProductServiceID2 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ZI";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Z";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "Z";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "X6", true)]
	[InlineData("O", "", false)]
	[InlineData("", "X6", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.RepairActionCode = "X";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Vi";
			subject.ProductServiceID = "g";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bn";
			subject.ProductServiceID2 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ZI";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Z";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "Z";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vr", "F", true)]
	[InlineData("vr", "", false)]
	[InlineData("", "F", true)]
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
			subject.ProductServiceIDQualifier = "Vi";
			subject.ProductServiceID = "g";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bn";
			subject.ProductServiceID2 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ZI";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Z";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "Z";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "vr", true)]
	[InlineData("V", "", false)]
	[InlineData("", "vr", true)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		//A Requires B
		if (agencyQualifierCode2 != "")
			subject.RepairComplexityCode = "F";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Vi";
			subject.ProductServiceID = "g";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bn";
			subject.ProductServiceID2 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ZI";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Z";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "Z";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZI", "k", true)]
	[InlineData("ZI", "", false)]
	[InlineData("", "k", false)]
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
			subject.ProductServiceIDQualifier = "Vi";
			subject.ProductServiceID = "g";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bn";
			subject.ProductServiceID2 = "d";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Z";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.RepairActionCode2 = "Z";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("k", "Z", "m", true)]
	[InlineData("", "Z", "m", true)]
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
			subject.ProductServiceIDQualifier = "Vi";
			subject.ProductServiceID = "g";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bn";
			subject.ProductServiceID2 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ZI";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Z";
			subject.ProductServiceID3 = "k";
		}

        if (subject.ProductServiceID3 != "")
            subject.ProductServiceIDQualifier3 = "Kc";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z", "k", true)]
	[InlineData("Z", "", false)]
	[InlineData("", "k", false)]
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
			subject.ProductServiceIDQualifier = "Vi";
			subject.ProductServiceID = "g";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bn";
			subject.ProductServiceID2 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ZI";
			subject.ProductServiceID3 = "k";
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
	[InlineData("si", "g", true)]
	[InlineData("si", "", false)]
	[InlineData("", "g", true)]
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
			subject.ProductServiceIDQualifier = "Vi";
			subject.ProductServiceID = "g";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bn";
			subject.ProductServiceID2 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ZI";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Z";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "Z";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "si", true)]
	[InlineData("d", "", false)]
	[InlineData("", "si", true)]
	public void Validation_ARequiresBSourceSubqualifier3(string sourceSubqualifier3, string agencyQualifierCode3, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier3 = sourceSubqualifier3;
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		//A Requires B
		if (agencyQualifierCode3 != "")
			subject.ReferenceIdentification = "g";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Vi";
			subject.ProductServiceID = "g";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "bn";
			subject.ProductServiceID2 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ZI";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "Z";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "Z";
			subject.Description2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
