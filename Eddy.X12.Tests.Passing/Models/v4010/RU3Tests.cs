using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class RU3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU3*3Ho9wIX3*f8*z*rW*W*x0*X*pR*S*KJ*Q*so*J*wF*p*EP*D*yd*Y*Ld*Z*DI*p*WR*k*2p*g*qW*r";

		var expected = new RU3_EmployingCarrierClaimProfile()
		{
			Date = "3Ho9wIX3",
			PayrollStatusCode = "f8",
			WagesPaidCode = "z",
			PayrollStatusCode2 = "rW",
			WagesPaidCode2 = "W",
			PayrollStatusCode3 = "x0",
			WagesPaidCode3 = "X",
			PayrollStatusCode4 = "pR",
			WagesPaidCode4 = "S",
			PayrollStatusCode5 = "KJ",
			WagesPaidCode5 = "Q",
			PayrollStatusCode6 = "so",
			WagesPaidCode6 = "J",
			PayrollStatusCode7 = "wF",
			WagesPaidCode7 = "p",
			PayrollStatusCode8 = "EP",
			WagesPaidCode8 = "D",
			PayrollStatusCode9 = "yd",
			WagesPaidCode9 = "Y",
			PayrollStatusCode10 = "Ld",
			WagesPaidCode10 = "Z",
			PayrollStatusCode11 = "DI",
			WagesPaidCode11 = "p",
			PayrollStatusCode12 = "WR",
			WagesPaidCode12 = "k",
			PayrollStatusCode13 = "2p",
			WagesPaidCode13 = "g",
			PayrollStatusCode14 = "qW",
			WagesPaidCode14 = "r",
		};

		var actual = Map.MapObject<RU3_EmployingCarrierClaimProfile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3Ho9wIX3", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f8", "z", true)]
	[InlineData("f8", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredPayrollStatusCode(string payrollStatusCode, string wagesPaidCode, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode = payrollStatusCode;
		subject.WagesPaidCode = wagesPaidCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rW", "W", true)]
	[InlineData("rW", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredPayrollStatusCode2(string payrollStatusCode2, string wagesPaidCode2, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode2 = payrollStatusCode2;
		subject.WagesPaidCode2 = wagesPaidCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x0", "X", true)]
	[InlineData("x0", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredPayrollStatusCode3(string payrollStatusCode3, string wagesPaidCode3, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode3 = payrollStatusCode3;
		subject.WagesPaidCode3 = wagesPaidCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pR", "S", true)]
	[InlineData("pR", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredPayrollStatusCode4(string payrollStatusCode4, string wagesPaidCode4, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode4 = payrollStatusCode4;
		subject.WagesPaidCode4 = wagesPaidCode4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KJ", "Q", true)]
	[InlineData("KJ", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredPayrollStatusCode5(string payrollStatusCode5, string wagesPaidCode5, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode5 = payrollStatusCode5;
		subject.WagesPaidCode5 = wagesPaidCode5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("so", "J", true)]
	[InlineData("so", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredPayrollStatusCode6(string payrollStatusCode6, string wagesPaidCode6, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode6 = payrollStatusCode6;
		subject.WagesPaidCode6 = wagesPaidCode6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wF", "p", true)]
	[InlineData("wF", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredPayrollStatusCode7(string payrollStatusCode7, string wagesPaidCode7, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode7 = payrollStatusCode7;
		subject.WagesPaidCode7 = wagesPaidCode7;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("EP", "D", true)]
	[InlineData("EP", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredPayrollStatusCode8(string payrollStatusCode8, string wagesPaidCode8, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode8 = payrollStatusCode8;
		subject.WagesPaidCode8 = wagesPaidCode8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yd", "Y", true)]
	[InlineData("yd", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredPayrollStatusCode9(string payrollStatusCode9, string wagesPaidCode9, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode9 = payrollStatusCode9;
		subject.WagesPaidCode9 = wagesPaidCode9;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ld", "Z", true)]
	[InlineData("Ld", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredPayrollStatusCode10(string payrollStatusCode10, string wagesPaidCode10, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode10 = payrollStatusCode10;
		subject.WagesPaidCode10 = wagesPaidCode10;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DI", "p", true)]
	[InlineData("DI", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredPayrollStatusCode11(string payrollStatusCode11, string wagesPaidCode11, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode11 = payrollStatusCode11;
		subject.WagesPaidCode11 = wagesPaidCode11;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WR", "k", true)]
	[InlineData("WR", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredPayrollStatusCode12(string payrollStatusCode12, string wagesPaidCode12, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode12 = payrollStatusCode12;
		subject.WagesPaidCode12 = wagesPaidCode12;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2p", "g", true)]
	[InlineData("2p", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredPayrollStatusCode13(string payrollStatusCode13, string wagesPaidCode13, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode13 = payrollStatusCode13;
		subject.WagesPaidCode13 = wagesPaidCode13;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.PayrollStatusCode14) || !string.IsNullOrEmpty(subject.WagesPaidCode14))
		{
			subject.PayrollStatusCode14 = "qW";
			subject.WagesPaidCode14 = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qW", "r", true)]
	[InlineData("qW", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredPayrollStatusCode14(string payrollStatusCode14, string wagesPaidCode14, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		//Required fields
		subject.Date = "3Ho9wIX3";
		//Test Parameters
		subject.PayrollStatusCode14 = payrollStatusCode14;
		subject.WagesPaidCode14 = wagesPaidCode14;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.PayrollStatusCode) || !string.IsNullOrEmpty(subject.WagesPaidCode))
		{
			subject.PayrollStatusCode = "f8";
			subject.WagesPaidCode = "z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.PayrollStatusCode2) || !string.IsNullOrEmpty(subject.WagesPaidCode2))
		{
			subject.PayrollStatusCode2 = "rW";
			subject.WagesPaidCode2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.PayrollStatusCode3) || !string.IsNullOrEmpty(subject.WagesPaidCode3))
		{
			subject.PayrollStatusCode3 = "x0";
			subject.WagesPaidCode3 = "X";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.PayrollStatusCode4) || !string.IsNullOrEmpty(subject.WagesPaidCode4))
		{
			subject.PayrollStatusCode4 = "pR";
			subject.WagesPaidCode4 = "S";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.PayrollStatusCode5) || !string.IsNullOrEmpty(subject.WagesPaidCode5))
		{
			subject.PayrollStatusCode5 = "KJ";
			subject.WagesPaidCode5 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.PayrollStatusCode6) || !string.IsNullOrEmpty(subject.WagesPaidCode6))
		{
			subject.PayrollStatusCode6 = "so";
			subject.WagesPaidCode6 = "J";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.PayrollStatusCode7) || !string.IsNullOrEmpty(subject.WagesPaidCode7))
		{
			subject.PayrollStatusCode7 = "wF";
			subject.WagesPaidCode7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.PayrollStatusCode8) || !string.IsNullOrEmpty(subject.WagesPaidCode8))
		{
			subject.PayrollStatusCode8 = "EP";
			subject.WagesPaidCode8 = "D";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.PayrollStatusCode9) || !string.IsNullOrEmpty(subject.WagesPaidCode9))
		{
			subject.PayrollStatusCode9 = "yd";
			subject.WagesPaidCode9 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.PayrollStatusCode10) || !string.IsNullOrEmpty(subject.WagesPaidCode10))
		{
			subject.PayrollStatusCode10 = "Ld";
			subject.WagesPaidCode10 = "Z";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.PayrollStatusCode11) || !string.IsNullOrEmpty(subject.WagesPaidCode11))
		{
			subject.PayrollStatusCode11 = "DI";
			subject.WagesPaidCode11 = "p";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.PayrollStatusCode12) || !string.IsNullOrEmpty(subject.WagesPaidCode12))
		{
			subject.PayrollStatusCode12 = "WR";
			subject.WagesPaidCode12 = "k";
		}
		if(!string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.PayrollStatusCode13) || !string.IsNullOrEmpty(subject.WagesPaidCode13))
		{
			subject.PayrollStatusCode13 = "2p";
			subject.WagesPaidCode13 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
