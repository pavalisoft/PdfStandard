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

namespace Pavalisoft.PdfStandard.FontBox.Afm
{
    /// <summary>
    /// This class represents a piece of track kerning data.
    /// </summary>
    public class TrackKern
    {
        /// <summary>
        /// Gets or Sets the property degree.
        /// </summary>
        public int Degree { get; set; }
        
        /// <summary>
        /// Gets or Sets the property maxKern.
        /// </summary>
        public float MaxKern { get; set; }
        
        /// <summary>
        /// Gets or Sets the property maxPointSize.
        /// </summary>
        public float MaxPointSize { get; set; }
        
        /// <summary>
        /// Gets or Sets the property minKern.
        /// </summary>
        public float MinKern { get; set; }
        
        /// <summary>
        /// Gets or Sets the property minPointSize.
        /// </summary>
        public float MinPointSize { get; set; }        
    }
}