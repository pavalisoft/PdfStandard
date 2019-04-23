/* 
   Copyright 2019 Pavalisoft Corporation

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License. 
*/

using System.Collections.Generic;
using Pavalisoft.PdfStandard.FontBox.Util;

namespace Pavalisoft.PdfStandard.FontBox.Afm
{
    /// <summary>
    /// This class represents a single character metric.
    /// </summary>
    public class CharMetric
    {
        /// <summary>
        /// Gets or Sets value for boundingBox
        /// </summary>
        public BoundingBox BoundingBox { get; set; }
        
        /// <summary>
        /// Gets and Sets characterCode.
        /// </summary>
        public int CharacterCode { get; set; }
        
        /// <summary>
        /// This will add an entry to the list of ligatures.
        /// </summary>
        public List<Ligature> Ligatures { get; set; } = new List<Ligature>();
        
        /// <summary>
        /// Gets or Sets Name.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or Sets vv.
        /// </summary>
        public float[] Vv { get; set; }
        
        /// <summary>
        /// Gets or Sets property w.
        /// </summary>
        public float[] W { get; set; }
        
        /// <summary>
        /// Gets or Sets property w0.
        /// </summary>
        public float[] W0 { get; set; }
        
        /// <summary>
        /// Gets or Sets the property w0x.
        /// </summary>
        public float W0x { get; set; }
        
        /// <summary>
        /// Gets or Sets the property w0y.
        /// </summary>
        public float W0y { get; set; }
        
        /// <summary
        /// Gets or Sets the property w1.
        /// </summary>
        public float[] W1 { get; set; }
        
        /// <summary>
        /// Gets or Sets the property w1x.
        /// </summary>
        public float W1x { get; set; }
        
        /// <summary>
        /// Gets or Sets the property w1y.
        /// </summary>
        public float W1y { get; set; }
        
        /// <summary>
        /// Gets or Sets the property wx.
        /// </summary>
        public float Wx { get; set; }        

        /// <summary>
        /// Gets or Sets the property wy.
        /// </summary>
        public float Wy { get; set; }      
    }
}