using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class F03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F03*5*YT*B*Bc*l*8*cc*V*Gx*1*ub*J*z*GRepN";

		var expected = new F03_DetailSupportingEvidenceForClaim()
		{
			Quantity = 5,
			UnitOrBasisForMeasurementCode = "YT",
			LadingDescription = "B",
			NatureOfClaimCode = "Bc",
			Amount = "l",
			Amount2 = "8",
			ReferenceNumberQualifier = "cc",
			ReferenceNumber = "V",
			ReferenceNumberQualifier2 = "Gx",
			ReferenceNumber2 = "1",
			NatureOfClaimCode2 = "ub",
			FreeFormDescription = "J",
			LadingDescription2 = "z",
			PackagingCode = "GRepN",
		};

		var actual = Map.MapObject<F03_DetailSupportingEvidenceForClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.UnitOrBasisForMeasurementCode = "YT";
		subject.LadingDescription = "B";
		subject.NatureOfClaimCode = "Bc";
		subject.Amount = "l";
		subject.Amount2 = "8";
		subject.NatureOfClaimCode2 = "ub";
		subject.LadingDescription2 = "z";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "cc";
			subject.ReferenceNumber = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Gx";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YT", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 5;
		subject.LadingDescription = "B";
		subject.NatureOfClaimCode = "Bc";
		subject.Amount = "l";
		subject.Amount2 = "8";
		subject.NatureOfClaimCode2 = "ub";
		subject.LadingDescription2 = "z";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "cc";
			subject.ReferenceNumber = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Gx";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredLadingDescription(string ladingDescription, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "YT";
		subject.NatureOfClaimCode = "Bc";
		subject.Amount = "l";
		subject.Amount2 = "8";
		subject.NatureOfClaimCode2 = "ub";
		subject.LadingDescription2 = "z";
		subject.LadingDescription = ladingDescription;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "cc";
			subject.ReferenceNumber = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Gx";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bc", true)]
	public void Validation_RequiredNatureOfClaimCode(string natureOfClaimCode, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "YT";
		subject.LadingDescription = "B";
		subject.Amount = "l";
		subject.Amount2 = "8";
		subject.NatureOfClaimCode2 = "ub";
		subject.LadingDescription2 = "z";
		subject.NatureOfClaimCode = natureOfClaimCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "cc";
			subject.ReferenceNumber = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Gx";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "YT";
		subject.LadingDescription = "B";
		subject.NatureOfClaimCode = "Bc";
		subject.Amount2 = "8";
		subject.NatureOfClaimCode2 = "ub";
		subject.LadingDescription2 = "z";
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "cc";
			subject.ReferenceNumber = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Gx";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredAmount2(string amount2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "YT";
		subject.LadingDescription = "B";
		subject.NatureOfClaimCode = "Bc";
		subject.Amount = "l";
		subject.NatureOfClaimCode2 = "ub";
		subject.LadingDescription2 = "z";
		subject.Amount2 = amount2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "cc";
			subject.ReferenceNumber = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Gx";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cc", "V", true)]
	[InlineData("cc", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "YT";
		subject.LadingDescription = "B";
		subject.NatureOfClaimCode = "Bc";
		subject.Amount = "l";
		subject.Amount2 = "8";
		subject.NatureOfClaimCode2 = "ub";
		subject.LadingDescription2 = "z";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Gx";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Gx", "1", true)]
	[InlineData("Gx", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "YT";
		subject.LadingDescription = "B";
		subject.NatureOfClaimCode = "Bc";
		subject.Amount = "l";
		subject.Amount2 = "8";
		subject.NatureOfClaimCode2 = "ub";
		subject.LadingDescription2 = "z";
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "cc";
			subject.ReferenceNumber = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ub", true)]
	public void Validation_RequiredNatureOfClaimCode2(string natureOfClaimCode2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "YT";
		subject.LadingDescription = "B";
		subject.NatureOfClaimCode = "Bc";
		subject.Amount = "l";
		subject.Amount2 = "8";
		subject.LadingDescription2 = "z";
		subject.NatureOfClaimCode2 = natureOfClaimCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "cc";
			subject.ReferenceNumber = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Gx";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredLadingDescription2(string ladingDescription2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "YT";
		subject.LadingDescription = "B";
		subject.NatureOfClaimCode = "Bc";
		subject.Amount = "l";
		subject.Amount2 = "8";
		subject.NatureOfClaimCode2 = "ub";
		subject.LadingDescription2 = ladingDescription2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "cc";
			subject.ReferenceNumber = "V";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Gx";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
