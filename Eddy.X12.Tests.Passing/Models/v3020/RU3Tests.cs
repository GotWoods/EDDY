using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RU3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU3*V6AbRY*D5*Q*sM*g*IM*C*D1*T*ZG*n*ZJ*1*nE*G*np*3*bc*k*kQ*o*Rs*8*hB*8*Ao*B*ka*b";

		var expected = new RU3_EmployingCarrierClaimProfile()
		{
			Date = "V6AbRY",
			PayrollStatusCode = "D5",
			WagesPaidCode = "Q",
			PayrollStatusCode2 = "sM",
			WagesPaidCode2 = "g",
			PayrollStatusCode3 = "IM",
			WagesPaidCode3 = "C",
			PayrollStatusCode4 = "D1",
			WagesPaidCode4 = "T",
			PayrollStatusCode5 = "ZG",
			WagesPaidCode5 = "n",
			PayrollStatusCode6 = "ZJ",
			WagesPaidCode6 = "1",
			PayrollStatusCode7 = "nE",
			WagesPaidCode7 = "G",
			PayrollStatusCode8 = "np",
			WagesPaidCode8 = "3",
			PayrollStatusCode9 = "bc",
			WagesPaidCode9 = "k",
			PayrollStatusCode10 = "kQ",
			WagesPaidCode10 = "o",
			PayrollStatusCode11 = "Rs",
			WagesPaidCode11 = "8",
			PayrollStatusCode12 = "hB",
			WagesPaidCode12 = "8",
			PayrollStatusCode13 = "Ao",
			WagesPaidCode13 = "B",
			PayrollStatusCode14 = "ka",
			WagesPaidCode14 = "b",
		};

		var actual = Map.MapObject<RU3_EmployingCarrierClaimProfile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V6AbRY", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D5", "Q", true)]
	[InlineData("D5", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredPayrollStatusCode(string payrollStatusCode, string wagesPaidCode, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode = payrollStatusCode;
		subject.WagesPaidCode = wagesPaidCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sM", "g", true)]
	[InlineData("sM", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredPayrollStatusCode2(string payrollStatusCode2, string wagesPaidCode2, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode2 = payrollStatusCode2;
		subject.WagesPaidCode2 = wagesPaidCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("IM", "C", true)]
	[InlineData("IM", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredPayrollStatusCode3(string payrollStatusCode3, string wagesPaidCode3, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode3 = payrollStatusCode3;
		subject.WagesPaidCode3 = wagesPaidCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D1", "T", true)]
	[InlineData("D1", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredPayrollStatusCode4(string payrollStatusCode4, string wagesPaidCode4, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode4 = payrollStatusCode4;
		subject.WagesPaidCode4 = wagesPaidCode4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZG", "n", true)]
	[InlineData("ZG", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredPayrollStatusCode5(string payrollStatusCode5, string wagesPaidCode5, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode5 = payrollStatusCode5;
		subject.WagesPaidCode5 = wagesPaidCode5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZJ", "1", true)]
	[InlineData("ZJ", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredPayrollStatusCode6(string payrollStatusCode6, string wagesPaidCode6, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode6 = payrollStatusCode6;
		subject.WagesPaidCode6 = wagesPaidCode6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nE", "G", true)]
	[InlineData("nE", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredPayrollStatusCode7(string payrollStatusCode7, string wagesPaidCode7, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode7 = payrollStatusCode7;
		subject.WagesPaidCode7 = wagesPaidCode7;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("np", "3", true)]
	[InlineData("np", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredPayrollStatusCode8(string payrollStatusCode8, string wagesPaidCode8, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode8 = payrollStatusCode8;
		subject.WagesPaidCode8 = wagesPaidCode8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bc", "k", true)]
	[InlineData("bc", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredPayrollStatusCode9(string payrollStatusCode9, string wagesPaidCode9, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode9 = payrollStatusCode9;
		subject.WagesPaidCode9 = wagesPaidCode9;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kQ", "o", true)]
	[InlineData("kQ", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredPayrollStatusCode10(string payrollStatusCode10, string wagesPaidCode10, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode10 = payrollStatusCode10;
		subject.WagesPaidCode10 = wagesPaidCode10;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Rs", "8", true)]
	[InlineData("Rs", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredPayrollStatusCode11(string payrollStatusCode11, string wagesPaidCode11, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode11 = payrollStatusCode11;
		subject.WagesPaidCode11 = wagesPaidCode11;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hB", "8", true)]
	[InlineData("hB", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredPayrollStatusCode12(string payrollStatusCode12, string wagesPaidCode12, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode12 = payrollStatusCode12;
		subject.WagesPaidCode12 = wagesPaidCode12;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ao", "B", true)]
	[InlineData("Ao", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredPayrollStatusCode13(string payrollStatusCode13, string wagesPaidCode13, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode13 = payrollStatusCode13;
		subject.WagesPaidCode13 = wagesPaidCode13;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "ka";
			subject.WagesPaidCode14 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ka", "b", true)]
	[InlineData("ka", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredPayrollStatusCode14(string payrollStatusCode14, string wagesPaidCode14, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "V6AbRY";
		//Test Parameters
		subject.PayrollStatusCode14 = payrollStatusCode14;
		subject.WagesPaidCode14 = wagesPaidCode14;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "D5";
			subject.WagesPaidCode = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "sM";
			subject.WagesPaidCode2 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "IM";
			subject.WagesPaidCode3 = "C";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "D1";
			subject.WagesPaidCode4 = "T";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "ZG";
			subject.WagesPaidCode5 = "n";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "ZJ";
			subject.WagesPaidCode6 = "1";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "nE";
			subject.WagesPaidCode7 = "G";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "np";
			subject.WagesPaidCode8 = "3";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "bc";
			subject.WagesPaidCode9 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "kQ";
			subject.WagesPaidCode10 = "o";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "Rs";
			subject.WagesPaidCode11 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "hB";
			subject.WagesPaidCode12 = "8";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "Ao";
			subject.WagesPaidCode13 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
