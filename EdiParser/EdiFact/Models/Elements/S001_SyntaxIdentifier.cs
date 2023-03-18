using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;

namespace EdiParser.EdiFact.Models.Elements
{
    public class S001_SyntaxIdentifier :IElement
    {
        [Position(1)]
        public string SyntaxIdentifier { get; set; }

        [Position(2)]
        public string SyntaxVersionNumber{ get; set; }

        [Position(3)]
        public string ServiceCodeListDirectoryVersionNumber { get; set; }
        
        [Position(4)]
        public string CharacterEncoding { get; set; }
        
        [Position(5)]
        public string SyntaxReleaseNumber { get; set; }
    }
}
