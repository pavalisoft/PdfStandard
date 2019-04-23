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

using System.Text;

namespace Pavalisoft.PdfStandard.FontBox.Util
{
    /// <summary>
    /// This class provides an instance of all common Encodings used to transform byte arrays into strings. 
    /// </summary>

    public class Encodings
    {
        /// <summary>
        /// ISO-8859-1 Encoding
        /// </summary>
        public static readonly Encoding ISO_8859_1 = Encoding.GetEncoding(28591);
        
        /// <summary>
        /// UTF-16 Encoding
        /// </summary>
        public static readonly Encoding UTF_16 = Encoding.Unicode;
        
        /// <summary>
        /// UTF-16BE Charset
        /// </summary>
        public static readonly Encoding UTF_16BE = Encoding.BigEndianUnicode;
        
        /// <summary>
        /// US-ASCII Charset
        /// </summary>
        public static readonly Encoding US_ASCII = Encoding.GetEncoding(20127);
        
        /// <summary>
        /// ISO-10646 Charset
        /// </summary>
        public static readonly Encoding ISO_10646 = Encoding.BigEndianUnicode;
    }
}