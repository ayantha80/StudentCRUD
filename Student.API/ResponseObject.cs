using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Api
{
    public class ResponseObject
    {
       
        /// <summary>
        /// gets or set value.
        /// </summary>
        /// <value>if error then the error description.</value>
        public dynamic ErrorDescription { get; set; }
        /// <summary>
        /// gets or set value.
        /// </summary>
        /// <value>data that will be returned.</value>
        public dynamic Data { get; set; }    
    }
}
