using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class REPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REP*1*ra*v*LR*f*11*N*T*o*KB*g*4*RP*r*A*k*KQ*I*n*o";

		var expected = new REP_RepairAction()
		{
			AssignedIdentification = "1",
			ProductServiceIDQualifier = "ra",
			ProductServiceID = "v",
			ProductServiceIDQualifier2 = "LR",
			ProductServiceID2 = "f",
			AgencyQualifierCode = "11",
			SourceSubqualifier = "N",
			RepairActionCode = "T",
			Description = "o",
			AgencyQualifierCode2 = "KB",
			SourceSubqualifier2 = "g",
			RepairComplexityCode = "4",
			ProductServiceIDQualifier3 = "RP",
			ProductServiceID3 = "r",
			RepairActionCode2 = "A",
			Description2 = "k",
			AgencyQualifierCode3 = "KQ",
			SourceSubqualifier3 = "I",
			ReferenceIdentification = "n",
			AuthorizationIdentification = "o",
		};

		var actual = Map.MapObject<REP_RepairAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ra", "v", true)]
	[InlineData("ra", "", false)]
	[InlineData("", "v", false)]
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
			subject.ProductServiceIDQualifier2 = "LR";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "RP";
			subject.ProductServiceID3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "A";
			subject.ProductServiceID3 = "r";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "r";
			subject.RepairActionCode2 = "A";
			subject.Description2 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LR", "f", true)]
	[InlineData("LR", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//A Requires B
		if (productServiceID2 != "")
			subject.ProductServiceID = "v";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "ra";
			subject.ProductServiceID = "v";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "RP";
			subject.ProductServiceID3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "A";
			subject.ProductServiceID3 = "r";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "r";
			subject.RepairActionCode2 = "A";
			subject.Description2 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "v", true)]
	[InlineData("f", "", false)]
	[InlineData("", "v", true)]
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
			subject.ProductServiceIDQualifier = "ra";
			subject.ProductServiceID = "v";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LR";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "RP";
			subject.ProductServiceID3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "A";
			subject.ProductServiceID3 = "r";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "r";
			subject.RepairActionCode2 = "A";
			subject.Description2 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("11", "T", true)]
	[InlineData("11", "", false)]
	[InlineData("", "T", true)]
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
			subject.ProductServiceIDQualifier = "ra";
			subject.ProductServiceID = "v";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LR";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "RP";
			subject.ProductServiceID3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "A";
			subject.ProductServiceID3 = "r";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "r";
			subject.RepairActionCode2 = "A";
			subject.Description2 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "11", true)]
	[InlineData("N", "", false)]
	[InlineData("", "11", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.RepairActionCode = "T";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "ra";
			subject.ProductServiceID = "v";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LR";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "RP";
			subject.ProductServiceID3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "A";
			subject.ProductServiceID3 = "r";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "r";
			subject.RepairActionCode2 = "A";
			subject.Description2 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KB", "4", true)]
	[InlineData("KB", "", false)]
	[InlineData("", "4", true)]
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
			subject.ProductServiceIDQualifier = "ra";
			subject.ProductServiceID = "v";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LR";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "RP";
			subject.ProductServiceID3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "A";
			subject.ProductServiceID3 = "r";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "r";
			subject.RepairActionCode2 = "A";
			subject.Description2 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "KB", true)]
	[InlineData("g", "", false)]
	[InlineData("", "KB", true)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		//A Requires B
		if (agencyQualifierCode2 != "")
			subject.RepairComplexityCode = "4";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "ra";
			subject.ProductServiceID = "v";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LR";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "RP";
			subject.ProductServiceID3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "A";
			subject.ProductServiceID3 = "r";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "r";
			subject.RepairActionCode2 = "A";
			subject.Description2 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("RP", "r", true)]
	[InlineData("RP", "", false)]
	[InlineData("", "r", false)]
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
			subject.ProductServiceIDQualifier = "ra";
			subject.ProductServiceID = "v";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LR";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "A";
			subject.ProductServiceID3 = "r";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.RepairActionCode2 = "A";
			subject.Description2 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("r", "A", "k", true)]
	[InlineData("", "A", "k", true)]
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
			subject.ProductServiceIDQualifier = "ra";
			subject.ProductServiceID = "v";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LR";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "RP";
			subject.ProductServiceID3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "A";
			subject.ProductServiceID3 = "r";
		}

        if (subject.ProductServiceID3 != "")
            subject.ProductServiceIDQualifier3 = "Kc";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "r", true)]
	[InlineData("A", "", false)]
	[InlineData("", "r", false)]
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
			subject.ProductServiceIDQualifier = "ra";
			subject.ProductServiceID = "v";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LR";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "RP";
			subject.ProductServiceID3 = "r";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.Description2 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KQ", "n", true)]
	[InlineData("KQ", "", false)]
	[InlineData("", "n", true)]
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
			subject.ProductServiceIDQualifier = "ra";
			subject.ProductServiceID = "v";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LR";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "RP";
			subject.ProductServiceID3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "A";
			subject.ProductServiceID3 = "r";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "r";
			subject.RepairActionCode2 = "A";
			subject.Description2 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "KQ", true)]
	[InlineData("I", "", false)]
	[InlineData("", "KQ", true)]
	public void Validation_ARequiresBSourceSubqualifier3(string sourceSubqualifier3, string agencyQualifierCode3, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier3 = sourceSubqualifier3;
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		//A Requires B
		if (agencyQualifierCode3 != "")
			subject.ReferenceIdentification = "n";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "ra";
			subject.ProductServiceID = "v";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LR";
			subject.ProductServiceID2 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "RP";
			subject.ProductServiceID3 = "r";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "A";
			subject.ProductServiceID3 = "r";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "r";
			subject.RepairActionCode2 = "A";
			subject.Description2 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
