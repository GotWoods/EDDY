using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class REPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REP*o*5L*1*ew*e*QB*W*G*c*ad*t*e*Kc*k*U*f*73*6*z*B";

		var expected = new REP_RepairAction()
		{
			AssignedIdentification = "o",
			ProductServiceIDQualifier = "5L",
			ProductServiceID = "1",
			ProductServiceIDQualifier2 = "ew",
			ProductServiceID2 = "e",
			AgencyQualifierCode = "QB",
			SourceSubqualifier = "W",
			RepairActionCode = "G",
			Description = "c",
			AgencyQualifierCode2 = "ad",
			SourceSubqualifier2 = "t",
			RepairComplexityCode = "e",
			ProductServiceIDQualifier3 = "Kc",
			ProductServiceID3 = "k",
			RepairActionCode2 = "U",
			Description2 = "f",
			AgencyQualifierCode3 = "73",
			SourceSubqualifier3 = "6",
			ReferenceNumber = "z",
			AuthorizationIdentification = "B",
		};

		var actual = Map.MapObject<REP_RepairAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5L", "1", true)]
	[InlineData("5L", "", false)]
	[InlineData("", "1", false)]
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
			subject.ProductServiceIDQualifier2 = "ew";
			subject.ProductServiceID2 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Kc";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "U";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "U";
			subject.Description2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ew", "e", true)]
	[InlineData("ew", "", false)]
	[InlineData("", "e", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//A Requires B
		if (productServiceID2 != "")
			subject.ProductServiceID = "1";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "5L";
			subject.ProductServiceID = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Kc";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "U";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "U";
			subject.Description2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e", "1", true)]
	[InlineData("e", "", false)]
	[InlineData("", "1", true)]
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
			subject.ProductServiceIDQualifier = "5L";
			subject.ProductServiceID = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ew";
			subject.ProductServiceID2 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Kc";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "U";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "U";
			subject.Description2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QB", "G", true)]
	[InlineData("QB", "", false)]
	[InlineData("", "G", true)]
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
			subject.ProductServiceIDQualifier = "5L";
			subject.ProductServiceID = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ew";
			subject.ProductServiceID2 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Kc";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "U";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "U";
			subject.Description2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "QB", true)]
	[InlineData("W", "", false)]
	[InlineData("", "QB", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.RepairActionCode = "G";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "5L";
			subject.ProductServiceID = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ew";
			subject.ProductServiceID2 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Kc";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "U";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "U";
			subject.Description2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ad", "e", true)]
	[InlineData("ad", "", false)]
	[InlineData("", "e", true)]
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
			subject.ProductServiceIDQualifier = "5L";
			subject.ProductServiceID = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ew";
			subject.ProductServiceID2 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Kc";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "U";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "U";
			subject.Description2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "ad", true)]
	[InlineData("t", "", false)]
	[InlineData("", "ad", true)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		//A Requires B
		if (agencyQualifierCode2 != "")
			subject.RepairComplexityCode = "e";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "5L";
			subject.ProductServiceID = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ew";
			subject.ProductServiceID2 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Kc";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "U";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "U";
			subject.Description2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Kc", "k", true)]
	[InlineData("Kc", "", false)]
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
			subject.ProductServiceIDQualifier = "5L";
			subject.ProductServiceID = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ew";
			subject.ProductServiceID2 = "e";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "U";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.RepairActionCode2 = "U";
			subject.Description2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("k", "U", "f", true)]
	[InlineData("", "U", "f", true)]
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
			subject.ProductServiceIDQualifier = "5L";
			subject.ProductServiceID = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ew";
			subject.ProductServiceID2 = "e";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "U";
			subject.ProductServiceID3 = "k";
		}

        if (subject.ProductServiceID3 != "") 
            subject.ProductServiceIDQualifier3 = "Kc";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "k", true)]
	[InlineData("U", "", false)]
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
			subject.ProductServiceIDQualifier = "5L";
			subject.ProductServiceID = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ew";
			subject.ProductServiceID2 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Kc";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.Description2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("73", "z", true)]
	[InlineData("73", "", false)]
	[InlineData("", "z", true)]
	public void Validation_ARequiresBAgencyQualifierCode3(string agencyQualifierCode3, string referenceNumber, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "5L";
			subject.ProductServiceID = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ew";
			subject.ProductServiceID2 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Kc";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "U";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "U";
			subject.Description2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "73", true)]
	[InlineData("6", "", false)]
	[InlineData("", "73", true)]
	public void Validation_ARequiresBSourceSubqualifier3(string sourceSubqualifier3, string agencyQualifierCode3, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier3 = sourceSubqualifier3;
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		//A Requires B
		if (agencyQualifierCode3 != "")
			subject.ReferenceNumber = "z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "5L";
			subject.ProductServiceID = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ew";
			subject.ProductServiceID2 = "e";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "Kc";
			subject.ProductServiceID3 = "k";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "U";
			subject.ProductServiceID3 = "k";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "k";
			subject.RepairActionCode2 = "U";
			subject.Description2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
