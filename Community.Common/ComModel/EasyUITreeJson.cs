using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Common
{
    public class EasyUITreeJson
    {
        public EasyUITreeJson()
        {
            State = "closed";
        }

        /// <summary>
            /// Id
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// Text
            /// </summary>
            public string Text { get; set; }
            /// <summary>
            /// closed
            /// </summary>
            public string State { get; set; }
            /// <summary>
            /// Children
            /// </summary>
            public object Children { get; set; }

    }
}
