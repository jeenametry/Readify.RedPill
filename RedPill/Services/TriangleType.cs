using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RedPill.Services
{

    [Serializable]
    [DataContract(Name = "TriangleType", Namespace = "http://KnockKnock.readify.net")]
    public enum TriangleType : int
    {

        [EnumMember()]
        Error = 0,

        [EnumMember()]
        Equilateral = 1,

        [EnumMember()]
        Isosceles = 2,

        [EnumMember()]
        Scalene = 3,
    }
}