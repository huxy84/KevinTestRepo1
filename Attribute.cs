using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentStep1
{
    public class Attribute
    {
        //AttributeId, AttributeName, AttributeType, MinValue, MaxValue, Optional, PossibleValues

        public Guid AttributeId { get; set; }

        public string AttributeName { get; set; }

        public string AttributeType { get; set; }

        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public bool Optional { get; set; }

        public string PossibleValues { get; set; }
    }
}
