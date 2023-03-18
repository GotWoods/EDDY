using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiParser.x12;
using EdiParser.x12.DomainModels;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.DomainTests
{
    public class Edi210FreightInvoiceTests
    {
        [Fact]
        public void LoadDocument()
        {
			var data = @"ISA*00*          *00*          *16*SENDER1        *1B*RECEIVER1      *071216*1406*U*00204*000000263*1*T*>~
GS*IN*SENDER1*RECEIVER1*20071216*1406*000000001*X*004010*~
ST*210*00000001~
B3**3410889*545930791T*TP*L*20071031*5165**20071029*035*NLMI~
C3*USD~
N9*AE*260451~
N9*OP*3410889~
G62*86*20071031~
R3*EXEM*B**AE***20071031*37905~
N1*SH*SIEMENS VDO S A DE C V - SIEMENS AUTOMOTIVE*94*99999~
N3*PERIFERICO SUR 7999D COMPLEJO IND~
N4*TLAQUEPAQUE*MX*99999*MX~
N1*CN*BRAMPTON ASSEMBLY - COLLINS AND AIKMAN*94*09126B~
N3*500 LAIRD ROAD*GUELPH PRODUCTS~
N4*GUELPH*ON*99999*CA~
N1*BT*BRAMPTON ASSEMBLY - MAIN*94*09126~
N3*2000 WILLIAMS PARKWAY EAST~
N4*BRAMPTON*ON*99999*CA~
N1*CA*NATIONAL LOGISTICS MANAGEMENT*94*45795~
N3*14320 JOY RD.~
N4*DETROIT*MI*48228*US~
N1*ZZ*EXPEDITORS/EMERY WORLDWIDE*94*37905~
N3*10881 LOWELL AVENUE~
N4*OVERLANDPARK*KS*66201*US~
N7**53456*********TL****5300*******53ST~

LX*1~
L5*1**2*Z~
L0*1*1499*FR*1499*G******L~
L1*1*51.65*FR*5165****400~

L3*2619*G***5165~
SE*30*00000001~
GE*1*000000001~
IEA*1*000000263~";

			var document = x12Document.Parse(data);

			var actual = new Edi210_MotorCarrierFreightDetailsAndInvoice();
			actual.LoadFrom(document);


			var expected = new Edi210_MotorCarrierFreightDetailsAndInvoice();
			expected.Sender = "SENDER1";
			expected.Receiver = "RECEIVER1";
			expected.InvoiceNumber = "3410889";
			expected.ShipmentIdentificationNumber = "545930791T";
			expected.DeliveryDate = "20071029";
            expected.Totals.Weight = 2619;
            expected.Totals.WeightQualifier = "G";
            expected.Totals.AmountCharged = "5165";


            expected.Entities.Add(new Entity());
            expected.Entities.Add(new Entity());
            expected.Entities.Add(new Entity());
            expected.Entities.Add(new Entity());
            expected.Entities.Add(new Entity());


            expected.Entities[0].Name = "SIEMENS VDO S A DE C V - SIEMENS AUTOMOTIVE";
            expected.Entities[0].EntityIdentifierCode = "SH";
			expected.Entities[0].Address1 = "PERIFERICO SUR 7999D COMPLEJO IND";
            expected.Entities[0].City = "TLAQUEPAQUE";
			expected.Entities[0].Country = "MX";
			expected.Entities[0].ProvinceState = "MX";
			expected.Entities[0].PostalZip = "99999";

            expected.Entities[1].Name = "BRAMPTON ASSEMBLY - COLLINS AND AIKMAN";
            expected.Entities[1].EntityIdentifierCode = "CN";
            expected.Entities[1].Address1 = "500 LAIRD ROAD";
            expected.Entities[1].Address2 = "GUELPH PRODUCTS";
            expected.Entities[1].City = "GUELPH";
            expected.Entities[1].Country = "CA";
            expected.Entities[1].ProvinceState = "ON";
            expected.Entities[1].PostalZip = "99999";

            expected.Entities[2].Name = "BRAMPTON ASSEMBLY - MAIN";
            expected.Entities[2].EntityIdentifierCode = "BT";
            expected.Entities[2].Address1 = "2000 WILLIAMS PARKWAY EAST";
            expected.Entities[2].City = "BRAMPTON";
            expected.Entities[2].Country = "CA";
            expected.Entities[2].ProvinceState = "ON";
            expected.Entities[2].PostalZip = "99999";

            expected.Entities[3].Name = "NATIONAL LOGISTICS MANAGEMENT";
            expected.Entities[3].EntityIdentifierCode = "CA";
            expected.Entities[3].Address1 = "14320 JOY RD.";
            expected.Entities[3].City = "DETROIT";
            expected.Entities[3].Country = "US";
            expected.Entities[3].ProvinceState = "MI";
            expected.Entities[3].PostalZip = "48228";

            expected.Entities[4].Name = "EXPEDITORS/EMERY WORLDWIDE";
            expected.Entities[4].EntityIdentifierCode = "ZZ";
            expected.Entities[4].Address1 = "10881 LOWELL AVENUE";
            expected.Entities[4].City = "OVERLANDPARK";
            expected.Entities[4].Country = "US";
            expected.Entities[4].ProvinceState = "KS";
            expected.Entities[4].PostalZip = "66201";

            expected.EquipmentDetails.Add(new EquipmentDetails() { LineData = new N7_EquipmentDetails() { EquipmentNumber = "53456" } });
            //expected.TransactionSets.Add(new TransactionSet());

            Assert.Equivalent(expected.Entities[0], actual.Entities[0]);
            Assert.Equivalent(expected.Entities[1], actual.Entities[1]);
            Assert.Equivalent(expected.Entities[2], actual.Entities[2]);
            Assert.Equivalent(expected.Entities[3], actual.Entities[3]);
            Assert.Equivalent(expected.EquipmentDetails[0], actual.EquipmentDetails[0]);

            Assert.Equivalent(expected, actual, true);

		}
    }
}

