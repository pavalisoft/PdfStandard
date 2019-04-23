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

using System;
using System.Collections;

namespace Pavalisoft.PdfStandard.FontBox.Util
{
    /// <summary>
    /// The string tokenizer class allows an application to break a string into tokens.
    /// The tokenization method is much simpler than the one used by the <code>StreamTokenizer</code> class.
    /// The <code>StringTokenizer</code> methods do not distinguish among identifiers, numbers, and quoted strings,
    /// nor do they recognize and skip comments.
    /// </summary>
    public class StringTokenizer : IEnumerator
    {
        private int position = -1;
        private string[] tokens;

        /// <summary>
        /// Creates an instance of <c>StringTokenizer</c> for the <paramref="sourceString"/> that should split on the default delimiter 
        /// set (space, tab, newline, return and formfeed) when <paramref="delimeters"/> not supplied.
        /// </summary>
        /// <param name="sourceString">The string to split</param>
        /// <param name="delimeters">A string containing all delimiter characters</param>
        public StringTokenizer(string sourceString, string delimeters = " \t\n\r\f")
        {
            this.tokens = sourceString.Split(delimeters.ToCharArray());
        }        

        /// <summary>
        /// Gives next Token
        /// </summary>
        public string NextToken()
        {
            (this as IEnumerator).MoveNext();
            return (this as IEnumerator).Current as string;
        }

        /// <summary>
        /// Tells if there are more tokens.
        /// </summary>
        /// <returns>true if the next call of NextToken() will succeed</returns>
        public bool HasMoreTokens()
        {
            int nextPosition = position + 1;
            return (nextPosition >= 0 && nextPosition < tokens.Length);
        }

        /// <summary>
        /// Gives the current token
        /// </summary>
        /// <value>returns current token value</value>
        object IEnumerator.Current { get{
            try
            {
                return tokens[position];
            }
            catch (IndexOutOfRangeException)
            {                
                throw new InvalidOperationException();
            }
        } }

        /// <summary>
        /// Moves to next token
        /// </summary>
        /// <returns>true if max position not reached</returns>
        bool IEnumerator.MoveNext()
        {
            position++;
            return (position < tokens.Length);
        }

        /// <summary>
        /// Resets to starting position
        /// </summary>
        void IEnumerator.Reset()
        {
            position = -1;
        }
    }    
}