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
    /// This represents some kern pair data.
    /// </summary>
    public class KernPair
    {
        /// <summary>
        /// Gets or Sets the property firstKernCharacter.
        /// </summary>
        public string FirstKernCharacter { get; set; }
        
        /// <summary>
        /// Gets or Sets the property secondKernCharacter.
        /// </summary>
        public string SecondKernCharacter { get; set; }
        
        /// <summary>
        /// Gets or Sets the property x.
        /// </summary>
        public float X { get; set; }
        
        /// <summary>
        /// Gets or Sets the property y.
        /// </summary>
        public float Y { get; set; }
    }
}