using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class F03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F03*2*Ut*X*qN*R*k*Rx*l*2Z*s*5c*G*L*1vzbL";

		var expected = new F03_DetailSupportingEvidenceForClaim()
		{
			Quantity = 2,
			UnitOfMeasurementCode = "Ut",
			LadingDescription = "X",
			NatureOfClaimCode = "qN",
			Amount = "R",
			Amount2 = "k",
			ReferenceNumberQualifier = "Rx",
			ReferenceNumber = "l",
			ReferenceNumberQualifier2 = "2Z",
			ReferenceNumber2 = "s",
			NatureOfClaimCode2 = "5c",
			FreeFormDescription = "G",
			LadingDescription2 = "L",
			PackagingCode = "1vzbL",
		};

		var actual = Map.MapObject<F03_DetailSupportingEvidenceForClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.UnitOfMeasurementCode = "Ut";
		subject.LadingDescription = "X";
		subject.NatureOfClaimCode = "qN";
		subject.Amount = "R";
		subject.Amount2 = "k";
		subject.NatureOfClaimCode2 = "5c";
		subject.LadingDescription2 = "L";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Rx";
			subject.ReferenceNumber = "l";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "2Z";
			subject.ReferenceNumber2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ut", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 2;
		subject.LadingDescription = "X";
		subject.NatureOfClaimCode = "qN";
		subject.Amount = "R";
		subject.Amount2 = "k";
		subject.NatureOfClaimCode2 = "5c";
		subject.LadingDescription2 = "L";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Rx";
			subject.ReferenceNumber = "l";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "2Z";
			subject.ReferenceNumber2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredLadingDescription(string ladingDescription, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 2;
		subject.UnitOfMeasurementCode = "Ut";
		subject.NatureOfClaimCode = "qN";
		subject.Amount = "R";
		subject.Amount2 = "k";
		subject.NatureOfClaimCode2 = "5c";
		subject.LadingDescription2 = "L";
		subject.LadingDescription = ladingDescription;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Rx";
			subject.ReferenceNumber = "l";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "2Z";
			subject.ReferenceNumber2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qN", true)]
	public void Validation_RequiredNatureOfClaimCode(string natureOfClaimCode, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 2;
		subject.UnitOfMeasurementCode = "Ut";
		subject.LadingDescription = "X";
		subject.Amount = "R";
		subject.Amount2 = "k";
		subject.NatureOfClaimCode2 = "5c";
		subject.LadingDescription2 = "L";
		subject.NatureOfClaimCode = natureOfClaimCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Rx";
			subject.ReferenceNumber = "l";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "2Z";
			subject.ReferenceNumber2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 2;
		subject.UnitOfMeasurementCode = "Ut";
		subject.LadingDescription = "X";
		subject.NatureOfClaimCode = "qN";
		subject.Amount2 = "k";
		subject.NatureOfClaimCode2 = "5c";
		subject.LadingDescription2 = "L";
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Rx";
			subject.ReferenceNumber = "l";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "2Z";
			subject.ReferenceNumber2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredAmount2(string amount2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 2;
		subject.UnitOfMeasurementCode = "Ut";
		subject.LadingDescription = "X";
		subject.NatureOfClaimCode = "qN";
		subject.Amount = "R";
		subject.NatureOfClaimCode2 = "5c";
		subject.LadingDescription2 = "L";
		subject.Amount2 = amount2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Rx";
			subject.ReferenceNumber = "l";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "2Z";
			subject.ReferenceNumber2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Rx", "l", true)]
	[InlineData("Rx", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 2;
		subject.UnitOfMeasurementCode = "Ut";
		subject.LadingDescription = "X";
		subject.NatureOfClaimCode = "qN";
		subject.Amount = "R";
		subject.Amount2 = "k";
		subject.NatureOfClaimCode2 = "5c";
		subject.LadingDescription2 = "L";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "2Z";
			subject.ReferenceNumber2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2Z", "s", true)]
	[InlineData("2Z", "", false)]
	[InlineData("", "s", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 2;
		subject.UnitOfMeasurementCode = "Ut";
		subject.LadingDescription = "X";
		subject.NatureOfClaimCode = "qN";
		subject.Amount = "R";
		subject.Amount2 = "k";
		subject.NatureOfClaimCode2 = "5c";
		subject.LadingDescription2 = "L";
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Rx";
			subject.ReferenceNumber = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5c", true)]
	public void Validation_RequiredNatureOfClaimCode2(string natureOfClaimCode2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 2;
		subject.UnitOfMeasurementCode = "Ut";
		subject.LadingDescription = "X";
		subject.NatureOfClaimCode = "qN";
		subject.Amount = "R";
		subject.Amount2 = "k";
		subject.LadingDescription2 = "L";
		subject.NatureOfClaimCode2 = natureOfClaimCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Rx";
			subject.ReferenceNumber = "l";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "2Z";
			subject.ReferenceNumber2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredLadingDescription2(string ladingDescription2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 2;
		subject.UnitOfMeasurementCode = "Ut";
		subject.LadingDescription = "X";
		subject.NatureOfClaimCode = "qN";
		subject.Amount = "R";
		subject.Amount2 = "k";
		subject.NatureOfClaimCode2 = "5c";
		subject.LadingDescription2 = ladingDescription2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Rx";
			subject.ReferenceNumber = "l";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "2Z";
			subject.ReferenceNumber2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
