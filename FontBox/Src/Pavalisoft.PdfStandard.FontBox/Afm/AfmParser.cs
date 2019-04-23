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
using System.Collections.Generic;
using System.Text;
using System.IO;
using Pavalisoft.PdfStandard.FontBox.Util;

namespace Pavalisoft.PdfStandard.FontBox.Afm
{
    /// <summary>
	/// This class is used to parse AFM(Adobe Font Metrics) documents.
	/// </summary>
	/// <seealso cref= <a href="http://partners.adobe.com/asn/developer/type/">AFM Documentation</a>		
    public class AfmParser
    {
        /// <summary>
        /// This is a comment in a AFM file.
        /// </summary>
        public const string COMMENT = "Comment";

        /// <summary>
        /// This is the constant used in the AFM file to start a font metrics item.
        /// </summary>
        public const string START_FONT_METRICS = "StartFontMetrics";
        
        /// <summary>
        /// This is the constant used in the AFM file to end a font metrics item.
        /// </summary>
        public const string END_FONT_METRICS = "EndFontMetrics";
        
        /// <summary>
        /// This is the font name.
        /// </summary>
        public const string FONT_NAME = "FontName";
        
        /// <summary>
        /// This is the full name.
        /// </summary>
        public const string FULL_NAME = "FullName";
        
        /// <summary>
        /// This is the Family name.
        /// </summary>
        public const string FAMILY_NAME = "FamilyName";
        
        /// <summary>
        /// This is the weight.
        /// </summary>
        public const string WEIGHT = "Weight";
        
        /// <summary>
        /// This is the font bounding box.
        /// </summary>
        public const string FONT_BBOX = "FontBBox";
        
        /// <summary>
        ///  This is the version of the font.
        /// </summary>
        public const string VERSION = "Version";
        
        /// <summary>
        ///  This is the notice.
        /// </summary>
        public const string NOTICE = "Notice";
        
        /// <summary>
        ///  This is the encoding scheme.
        /// </summary>
        public const string ENCODING_SCHEME = "EncodingScheme";
        
        /// <summary>
        ///  This is the mapping scheme.
        /// </summary>
        public const string MAPPING_SCHEME = "MappingScheme";
        
        /// <summary>
        ///  This is the escape character.
        /// </summary>
        public const string ESC_CHAR = "EscChar";
        
        /// <summary>
        ///  This is the character set.
        /// </summary>
        public const string CHARACTER_SET = "CharacterSet";
        
        /// <summary>
        ///  This is the characters attribute.
        /// </summary>
        public const string CHARACTERS = "Characters";
        
        /// <summary>
        ///  This will determine if this is a base font.
        /// </summary>
        public const string IS_BASE_FONT = "IsBaseFont";
        
        /// <summary>
        ///  This is the V Vector attribute.
        /// </summary>
        public const string V_VECTOR = "VVector";
        
        /// <summary>
        ///  This will tell if the V is fixed.
        /// </summary>
        public const string IS_FIXED_V = "IsFixedV";
        
        /// <summary>
        ///  This is the cap height attribute.
        /// </summary>
        public const string CAP_HEIGHT = "CapHeight";
        
        /// <summary>
        ///  This is the X height.
        /// </summary>
        public const string X_HEIGHT = "XHeight";
        
        /// <summary>
        ///  This is ascender attribute.
        /// </summary>
        public const string ASCENDER = "Ascender";
        
        /// <summary>
        ///  This is the descender attribute.
        /// </summary>
        public const string DESCENDER = "Descender";

        /// <summary>
        ///  The underline position.
        /// </summary>
        public const string UNDERLINE_POSITION = "UnderlinePosition";
        
        /// <summary>
        ///  This is the Underline thickness.
        /// </summary>
        public const string UNDERLINE_THICKNESS = "UnderlineThickness";
        
        /// <summary>
        ///  This is the italic angle.
        /// </summary>
        public const string ITALIC_ANGLE = "ItalicAngle";
        
        /// <summary>
        ///  This is the char width.
        /// </summary>
        public const string CHAR_WIDTH = "CharWidth";
        
        /// <summary>
        ///  This will determine if this is fixed pitch.
        /// </summary>
        public const string IS_FIXED_PITCH = "IsFixedPitch";
        
        /// <summary>
        ///  This is the start of character metrics.
        /// </summary>
        public const string START_CHAR_METRICS = "StartCharMetrics";
        
        /// <summary>
        ///  This is the end of character metrics.
        /// </summary>
        public const string END_CHAR_METRICS = "EndCharMetrics";
        
        /// <summary>
        ///  The character metrics c value.
        /// </summary>
        public const string CHARMETRICS_C = "C";
        
        /// <summary>
        ///  The character metrics c value.
        /// </summary>
        public const string CHARMETRICS_CH = "CH";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_WX = "WX";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_W0X = "W0X";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_W1X = "W1X";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_WY = "WY";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_W0Y = "W0Y";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_W1Y = "W1Y";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_W = "W";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_W0 = "W0";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_W1 = "W1";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_VV = "VV";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_N = "N";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_B = "B";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string CHARMETRICS_L = "L";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string STD_HW = "StdHW";
        
        /// <summary>
        ///  The character metrics value.
        /// </summary>
        public const string STD_VW = "StdVW";
        
        /// <summary>
        ///  This is the start of track kern data.
        /// </summary>
        public const string START_TRACK_KERN = "StartTrackKern";
        
        /// <summary>
        ///  This is the end of track kern data.
        /// </summary>
        public const string END_TRACK_KERN = "EndTrackKern";
        
        /// <summary>
        ///  This is the start of kern data.
        /// </summary>
        public const string START_KERN_DATA = "StartKernData";
        
        /// <summary>
        ///  This is the end of kern data.
        /// </summary>
        public const string END_KERN_DATA = "EndKernData";
        
        /// <summary>
        ///  This is the start of kern pairs data.
        /// </summary>
        public const string START_KERN_PAIRS = "StartKernPairs";
        
        /// <summary>
        ///  This is the end of kern pairs data.
        /// </summary>
        public const string END_KERN_PAIRS = "EndKernPairs";
        
        /// <summary>
        ///  This is the start of kern pairs data.
        /// </summary>
        public const string START_KERN_PAIRS0 = "StartKernPairs0";
        
        /// <summary>
        ///  This is the start of kern pairs data.
        /// </summary>
        public const string START_KERN_PAIRS1 = "StartKernPairs1";
        
        /// <summary>
        ///  This is the start composites data section.
        /// </summary>
        public const string START_COMPOSITES = "StartComposites";
        
        /// <summary>
        ///  This is the end composites data section.
        /// </summary>
        public const string END_COMPOSITES = "EndComposites";
        
        /// <summary>
        ///  This is a composite character.
        /// </summary>
        public const string CC = "CC";
        
        /// <summary>
        ///  This is a composite character part.
        /// </summary>
        public const string PCC = "PCC";
        
        /// <summary>
        ///  This is a kern pair.
        /// </summary>
        public const string KERN_PAIR_KP = "KP";
        
        /// <summary>
        ///  This is a kern pair.
        /// </summary>
        public const string KERN_PAIR_KPH = "KPH";
        
        /// <summary>
        ///  This is a kern pair.
        /// </summary>
        public const string KERN_PAIR_KPX = "KPX";
        
        /// <summary>
        ///  This is a kern pair.
        /// </summary>
        public const string KERN_PAIR_KPY = "KPY";

        private const int BITS_IN_HEX = 16;

        private readonly Stream inputStream;

        /// <summary>
        /// Creates an instance of <c>AfmParser</c> class.
        /// </summary>
        /// <param name="stream">The input stream to read the AFM document from.</param>
        public AfmParser(Stream stream )
        {
            inputStream = stream;
        }

        /// <summary>
        /// This will parse the AFM document. The input stream is closed when the parsing is finished.
        /// </summary>
        /// <returns>The parsed FontMetric</returns>
        /// <exception cref="IOException">If there is an IO error reading the document.</exception>
        public FontMetrics Parse()
        {
            return ParseFontMetric(false);
        }

        /// <summary>
        /// This will parse the AFM document. The input stream is closed when the parsing is finished.
        /// </summary>
        /// <param name="reducedDataset">Parse a reduced subset of data if set to true</param>
        /// <returns>The parsed FontMetric</returns>
        /// <exception cref="IOException">If there is an IO error reading the document.</exception>
        public FontMetrics Parse(bool reducedDataset)
        {
            return ParseFontMetric(reducedDataset);
        }
    
        /// <summary>
        /// This will parse a font metrics item.
        /// </summary>
        /// <returns>The parse font metrics item.<returns>
        /// <exception cref="IOException">If there is an error reading the AFM file.</exception>
        private FontMetrics ParseFontMetric(bool reducedDataset)
        {
            FontMetrics fontMetrics = new FontMetrics();
            string startFontMetrics = ReadString();
            if( !START_FONT_METRICS.Equals( startFontMetrics ) )
            {
                throw new IOException( "Error: The AFM file should start with " + START_FONT_METRICS +
                                    " and not '" + startFontMetrics + "'" );
            }
            fontMetrics.AfmVersion = ReadFloat();
            string nextCommand;
            bool charMetricsRead = false;
            while( !END_FONT_METRICS.Equals( (nextCommand = ReadString() ) ) )
            {
                if( FONT_NAME.Equals( nextCommand ) )
                {
                    fontMetrics.FontName = ReadLine();
                }
                else if( FULL_NAME.Equals( nextCommand ) )
                {
                    fontMetrics.FullName = ReadLine();
                }
                else if( FAMILY_NAME.Equals( nextCommand ) )
                {
                    fontMetrics.FamilyName = ReadLine();
                }
                else if( WEIGHT.Equals( nextCommand ) )
                {
                    fontMetrics.Weight = ReadLine();
                }
                else if( FONT_BBOX.Equals( nextCommand ) )
                {
                    fontMetrics.FontBBox = new BoundingBox
                    {
                        LowerLeftX = ReadFloat(),
                        LowerLeftY = ReadFloat(),
                        UpperRightX = ReadFloat(),
                        UpperRightY = ReadFloat()
                    };
                }
                else if( VERSION.Equals( nextCommand ) )
                {
                    fontMetrics.FontVersion = ReadLine();
                }
                else if( NOTICE.Equals( nextCommand ) )
                {
                    fontMetrics.Notice = ReadLine();
                }
                else if( ENCODING_SCHEME.Equals( nextCommand ) )
                {
                    fontMetrics.EncodingScheme = ReadLine();
                }
                else if( MAPPING_SCHEME.Equals( nextCommand ) )
                {
                    fontMetrics.MappingScheme = ReadInt();
                }
                else if( ESC_CHAR.Equals( nextCommand ) )
                {
                    fontMetrics.EscChar = ReadInt();
                }
                else if( CHARACTER_SET.Equals( nextCommand ) )
                {
                    fontMetrics.CharacterSet = ReadLine();
                }
                else if( CHARACTERS.Equals( nextCommand ) )
                {
                    fontMetrics.Characters = ReadInt();
                }
                else if( IS_BASE_FONT.Equals( nextCommand ) )
                {
                    fontMetrics.IsBaseFont = Readbool();
                }
                else if( V_VECTOR.Equals( nextCommand ) )
                {
                    fontMetrics.VVector = new float[2]{ReadFloat(), ReadFloat()};
                }
                else if( IS_FIXED_V.Equals( nextCommand ) )
                {
                    fontMetrics.IsFixedV = Readbool();
                }
                else if( CAP_HEIGHT.Equals( nextCommand ) )
                {
                    fontMetrics.CapHeight = ReadFloat();
                }
                else if( X_HEIGHT.Equals( nextCommand ) )
                {
                    fontMetrics.XHeight = ReadFloat();
                }
                else if( ASCENDER.Equals( nextCommand ) )
                {
                    fontMetrics.Ascender = ReadFloat();
                }
                else if( DESCENDER.Equals( nextCommand ) )
                {
                    fontMetrics.Descender = ReadFloat();
                }
                else if( STD_HW.Equals( nextCommand ) )
                {
                    fontMetrics.StandardHorizontalWidth = ReadFloat();
                }
                else if( STD_VW.Equals( nextCommand ) )
                {
                    fontMetrics.StandardVerticalWidth = ReadFloat();
                }
                else if( COMMENT.Equals( nextCommand ) )
                {
                    fontMetrics.AddComment( ReadLine() );
                }
                else if( UNDERLINE_POSITION.Equals( nextCommand ) )
                {
                    fontMetrics.UnderlinePosition = ReadFloat();
                }
                else if( UNDERLINE_THICKNESS.Equals( nextCommand ) )
                {
                    fontMetrics.UnderlineThickness = ReadFloat();
                }
                else if( ITALIC_ANGLE.Equals( nextCommand ) )
                {
                    fontMetrics.ItalicAngle = ReadFloat();
                }
                else if( CHAR_WIDTH.Equals( nextCommand ) )
                {
                    fontMetrics.CharWidth = new float[2]{ReadFloat(),ReadFloat()};
                }
                else if( IS_FIXED_PITCH.Equals( nextCommand ) )
                {
                    fontMetrics.FixedPitch = Readbool();
                }
                else if( START_CHAR_METRICS.Equals( nextCommand ) )
                {
                    int count = ReadInt();
                    List<CharMetric> charMetrics = new List<CharMetric>(count);
                    for( int i=0; i<count; i++ )
                    {
                        CharMetric charMetric = ParseCharMetric();
                        charMetrics.Add( charMetric );
                    }
                    string end = ReadString();
                    if( !end.Equals( END_CHAR_METRICS ) )
                    {
                        throw new IOException( "Error: Expected '" + END_CHAR_METRICS + "' actual '" + end + "'" );
                    }
                    charMetricsRead = true;
                    fontMetrics.CharMetrics = charMetrics.AsReadOnly();
                }
                else if( !reducedDataset && START_COMPOSITES.Equals( nextCommand ) )
                {
                    int count = ReadInt();
                    for( int i=0; i<count; i++ )
                    {
                        Composite part = ParseComposite();
                        fontMetrics.AddComposite( part );
                    }
                    string end = ReadString();
                    if( !end.Equals( END_COMPOSITES ) )
                    {
                        throw new IOException( "Error: Expected '" + END_COMPOSITES + "' actual '" + end + "'" );
                    }
                }
                else if( !reducedDataset && START_KERN_DATA.Equals( nextCommand ) )
                {
                    ParseKernData( fontMetrics );
                }
                else
                {
                    if (reducedDataset && charMetricsRead)
                    {
                        break;
                    }
                    throw new IOException( "Unknown AFM key '" + nextCommand + "'" );
                }
            }
            return fontMetrics;
        }

        /// <summary>
        /// This will parse the kern data.
        /// </summary>
        /// <param name="fontMetrics">The metrics class to put the parsed data into.</param>
        /// <exception cref="IOException">If there is an error parsing the data.</exception>
        private void ParseKernData( FontMetrics fontMetrics )
        {
            string nextCommand;
            while( !(nextCommand = ReadString()).Equals( END_KERN_DATA ) )
            {
                if( START_TRACK_KERN.Equals( nextCommand ) )
                {
                    int count = ReadInt();
                    for( int i=0; i<count; i++ )
                    {
                        fontMetrics.AddTrackKern( new TrackKern{
                            Degree = ReadInt(),
                            MinPointSize = ReadFloat(),
                            MinKern = ReadFloat(),
                            MaxPointSize = ReadFloat(),
                            MaxKern = ReadFloat()
                        } );
                    }
                    string end = ReadString();
                    if( !end.Equals( END_TRACK_KERN ) )
                    {
                        throw new IOException( "Error: Expected '" + END_TRACK_KERN + "' actual '" + end + "'" );
                    }
                }
                else if( START_KERN_PAIRS.Equals( nextCommand ) )
                {
                    int count = ReadInt();
                    for( int i=0; i<count; i++ )
                    {
                        KernPair pair = ParseKernPair();
                        fontMetrics.AddKernPair( pair );
                    }
                    String end = ReadString();
                    if( !end.Equals( END_KERN_PAIRS ) )
                    {
                        throw new IOException( "Error: Expected '" + END_KERN_PAIRS + "' actual '" + end + "'" );
                    }
                }
                else if( START_KERN_PAIRS0.Equals( nextCommand ) )
                {
                    int count = ReadInt();
                    for( int i=0; i<count; i++ )
                    {
                        KernPair pair = ParseKernPair();
                        fontMetrics.AddKernPair0( pair );
                    }
                    string end = ReadString();
                    if( !end.Equals( END_KERN_PAIRS ) )
                    {
                        throw new IOException( "Error: Expected '" + END_KERN_PAIRS + "' actual '" + end + "'" );
                    }
                }
                else if( START_KERN_PAIRS1.Equals( nextCommand ) )
                {
                    int count = ReadInt();
                    for( int i=0; i<count; i++ )
                    {
                        KernPair pair = ParseKernPair();
                        fontMetrics.AddKernPair1( pair );
                    }
                    string end = ReadString();
                    if( !end.Equals( END_KERN_PAIRS ) )
                    {
                        throw new IOException( "Error: Expected '" + END_KERN_PAIRS + "' actual '" + end + "'" );
                    }
                }
                else
                {
                    throw new IOException( "Unknown kerning data type '" + nextCommand + "'" );
                }
            }
        }

        /// <summary>
        /// This will parse a kern pair from the data stream.
        /// </summary>
        /// <returns>The kern pair that was parsed from the stream.</returns>
        /// <exception cref="IOException">If there is an error reading from the stream.</exception>
        private KernPair ParseKernPair()
        {
            KernPair kernPair = null;
            string cmd = ReadString();
            if( KERN_PAIR_KP.Equals( cmd ) )
            {
                kernPair = new KernPair{
                    FirstKernCharacter = ReadString(),
                    SecondKernCharacter = ReadString(),
                    X = ReadFloat(),
                    Y = ReadFloat()
                };
            }
            else if( KERN_PAIR_KPH.Equals( cmd ) )
            {
                kernPair = new KernPair{
                    FirstKernCharacter = HexToString(ReadString()),
                    SecondKernCharacter = HexToString(ReadString()),
                    X = ReadFloat(),
                    Y = ReadFloat()
                };
            }
            else if( KERN_PAIR_KPX.Equals( cmd ) )
            {
                kernPair = new KernPair{
                    FirstKernCharacter = ReadString(),
                    SecondKernCharacter = ReadString(),
                    X = ReadFloat(),
                    Y = 0
                };
            }
            else if( KERN_PAIR_KPY.Equals( cmd ) )
            {
                kernPair = new KernPair{
                    FirstKernCharacter = ReadString(),
                    SecondKernCharacter = ReadString(),
                    X = 0,
                    Y = ReadFloat()
                };
            }
            else
            {
                throw new IOException( "Error expected kern pair command actual='" + cmd + "'" );
            }
            return kernPair;
        }

        /// <summary>
        /// This will convert and angle bracket hex string to a string.
        /// </summary>
        /// <param name="hexString">An angle bracket string.</param>
        /// <returns>The bytes of the hex string.</returns>
        /// <exception cref="IOException">If the string is in an invalid format.</exception>
        private string HexToString( string hexString )
        {
            if( hexString.Length < 2 )
            {
                throw new IOException( "Error: Expected hex string of length >= 2 not='" + hexString );
            }
            
            char[] hexStringCharacters = hexString.ToCharArray();
            if( hexStringCharacters[0] != '<' ||
                hexStringCharacters[hexString.Length -1] != '>' )
            {
                throw new IOException( "String should be enclosed by angle brackets '" + hexString+ "'" );
            }
            hexString = hexString.Substring( 1, hexString.Length -1 );
            byte[] data = new byte[hexString.Length / 2];
            for( int i=0; i<hexString.Length; i+=2 )
            {
                string hex = Convert.ToString(hexStringCharacters[i]) + hexStringCharacters[i + 1];
                try
                {
                    data[ i / 2 ] = (byte)int.Parse( hex, System.Globalization.NumberStyles.AllowHexSpecifier );
                }
                catch( FormatException e )
                {
                    throw new IOException( "Error parsing AFM file:" + e );
                }
            }
            
            return Encodings.ISO_8859_1.GetString(data);
        }

        /// <summary>
        /// This will parse a composite part from the stream.
        /// </summary>
        /// <returns>The composite.</returns>
        /// <exception cref="IOException">If there is an error parsing the composite.</exception>
        private Composite ParseComposite()
        {
            Composite composite = new Composite();
            string partData = ReadLine();
            StringTokenizer tokenizer = new StringTokenizer( partData, " ;");

            string cc = tokenizer.NextToken();
            if( !cc.Equals( CC ) )
            {
                throw new IOException( "Expected '" + CC + "' actual='" + cc + "'" );
            }
            
            composite.Name = tokenizer.NextToken();

            int partCount;
            try
            {
                partCount = int.Parse( tokenizer.NextToken() );
            }
            catch( FormatException e )
            {
                throw new IOException( "Error parsing AFM document:" + e );
            }
            for( int i=0; i<partCount; i++ )
            {
                CompositePart part = new CompositePart();
                String pcc = tokenizer.NextToken();
                if( !pcc.Equals( PCC ) )
                {
                    throw new IOException( "Expected '" + PCC + "' actual='" + pcc + "'" );
                }
                string partName = tokenizer.NextToken();
                try
                {
                    int x = int.Parse( tokenizer.NextToken() );
                    int y = int.Parse( tokenizer.NextToken() );

                    part.Name = partName;
                    part.XDisplacement = x;
                    part.YDisplacement = y;
                    composite.Parts.Add( part );
                }
                catch( FormatException e )
                {
                    throw new IOException( "Error parsing AFM document:" + e );
                }
            }
            return composite;
        }

        /// <summary>
        /// This will parse a single CharMetric object from the stream.
        /// </summary>
        /// <returns>The next char metric in the stream.</returns>
        /// <exception cref="IOException">If there is an error reading from the stream.</exception>
        private CharMetric ParseCharMetric()
        {
            CharMetric charMetric = new CharMetric();
            string metrics = ReadLine();
            StringTokenizer metricsTokenizer = new StringTokenizer( metrics );
            try
            {
                while( metricsTokenizer.HasMoreTokens() )
                {
                    string nextCommand = metricsTokenizer.NextToken();
                    if( nextCommand.Equals( CHARMETRICS_C ) )
                    {
                        charMetric.CharacterCode = int.Parse( metricsTokenizer.NextToken() );
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_CH ) )
                    {
                        //Is the hex string <FF> or FF, the spec is a little
                        //unclear, wait and see if it breaks anything.
                        // charMetric.CharacterCode = int.Parse( metricsTokenizer.NextToken(), BITS_IN_HEX );
                        charMetric.CharacterCode = int.Parse(string.Empty, System.Globalization.NumberStyles.AllowHexSpecifier);                    
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_WX ) )
                    {
                        charMetric.Wx = float.Parse(metricsTokenizer.NextToken());
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_W0X ) )
                    {
                        charMetric.W0x = float.Parse(metricsTokenizer.NextToken());
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_W1X ) )
                    {
                        charMetric.W1x = float.Parse(metricsTokenizer.NextToken());
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_WY ) )
                    {
                        charMetric.Wy = float.Parse(metricsTokenizer.NextToken());
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_W0Y ) )
                    {
                        charMetric.W0y = float.Parse(metricsTokenizer.NextToken());
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_W1Y ) )
                    {
                        charMetric.W1y = float.Parse(metricsTokenizer.NextToken());
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_W ) )
                    {
                        charMetric.W = new float[2] {float.Parse(metricsTokenizer.NextToken()), float.Parse(metricsTokenizer.NextToken())};
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_W0 ) )
                    {
                        charMetric.W0 = new float[2]{float.Parse(metricsTokenizer.NextToken()), float.Parse(metricsTokenizer.NextToken())};
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_W1 ) )
                    {
                        charMetric.W1 = new float[2]{float.Parse(metricsTokenizer.NextToken()),float.Parse(metricsTokenizer.NextToken())};
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_VV ) )
                    {
                        charMetric.Vv = new float[2]{float.Parse(metricsTokenizer.NextToken()),float.Parse(metricsTokenizer.NextToken())};
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_N ) )
                    {
                        charMetric.Name = metricsTokenizer.NextToken();
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_B ) )
                    {
                        charMetric.BoundingBox = new BoundingBox{
                            LowerLeftX = float.Parse(metricsTokenizer.NextToken()),
                            LowerLeftY = float.Parse(metricsTokenizer.NextToken()),
                            UpperRightX = float.Parse(metricsTokenizer.NextToken()),
                            UpperRightY = float.Parse(metricsTokenizer.NextToken())
                        };
                        VerifySemicolon( metricsTokenizer );
                    }
                    else if( nextCommand.Equals( CHARMETRICS_L ) )
                    {
                        charMetric.Ligatures.Add( new Ligature{
                            Successor = metricsTokenizer.NextToken(),
                            CurrentLigature = metricsTokenizer.NextToken()
                        });
                        VerifySemicolon( metricsTokenizer );
                    }
                    else
                    {
                        throw new IOException( "Unknown CharMetrics command '" + nextCommand + "'" );
                    }
                }
            }
            catch( FormatException e )
            {
                throw new IOException( "Error: Corrupt AFM document:"  + e );
            }
            return charMetric;
        }

        /// <summary>
        /// This is used to verify that a semicolon is the next token in the stream.
        /// </summary>
        /// <param name="tokenizer">The tokenizer to read from.</param>
        /// <exception cref="IOException">If the semicolon is missing.</exception>
        private void VerifySemicolon( StringTokenizer tokenizer )
        {
            if( tokenizer.HasMoreTokens() )
            {
                String semicolon = tokenizer.NextToken();
                if (!";".Equals(semicolon))
                {
                    throw new IOException( "Error: Expected semicolon in stream actual='" + semicolon + "'" );
                }
            }
            else
            {
                throw new IOException( "CharMetrics is missing a semicolon after a command" );
            }
        }

        /// <summary>
        /// This will read a bool from the stream.
        /// </summary>
        /// <returns>The bool in the stream.</returns>
        private bool Readbool()
        {
            string thebool = ReadString();
            return bool.Parse( thebool );
        }

        /// <summary>
        /// This will read an integer from the stream.
        /// </summary>
        /// <returns>The integer in the stream.</returns>
        private int ReadInt()
        {
            string theInt = ReadString();
            try
            {
                return int.Parse( theInt );
            }
            catch( FormatException e )
            {
                throw new IOException( "Error parsing AFM document:" + e );
            }
        }

        /// <summary>
        /// This will read a float from the stream.
        /// </summary>
        /// <returns>The float in the stream.</returns>
        private float ReadFloat()
        {
            string theFloat = ReadString();
            return float.Parse( theFloat );
        }

        /// <summary>
        /// This will read until the end of a line.
        /// </summary>
        /// <returns>The string that is read.</returns>
        private string ReadLine()
        {
            //First skip the whitespace
            StringBuilder buf = new StringBuilder(60);
            int nextByte = inputStream.ReadByte();
            while( IsWhitespace( nextByte ) )
            {
                nextByte = inputStream.ReadByte();
                //do nothing just skip the whitespace.
            }
            buf.Append( (char)nextByte );

            //now read the data
            nextByte = inputStream.ReadByte();
            while (nextByte != -1 && !IsEOL(nextByte))
            {
                buf.Append((char) nextByte);
                nextByte = inputStream.ReadByte();
            }
            return buf.ToString();
        }

        /// <summary>
        /// This will read a string from the input stream and stop at any whitespace.
        /// </summary>
        /// <returns>The string read from the stream.</returns>
        /// <exception cref="IOException">If an IO error occurs when reading from the stream.</exception>
        private string ReadString()
        {
            //First skip the whitespace
            StringBuilder buf = new StringBuilder(24);
            int nextByte = inputStream.ReadByte();
            while( IsWhitespace( nextByte ) )
            {
                nextByte = inputStream.ReadByte();
                //do nothing just skip the whitespace.
            }
            buf.Append( (char)nextByte );

            //now read the data
            nextByte = inputStream.ReadByte();
            while (nextByte != -1 && !IsWhitespace(nextByte))
            {
                buf.Append((char) nextByte);
                nextByte = inputStream.ReadByte();
            }
            return buf.ToString();
        }

        /// <summary>
        /// This will determine if the byte is a whitespace character or not.
        /// </summary>
        /// <param name="character">The character to test for whitespace.</param>
        /// <returns>true If the character is whitespace as defined by the AFM spec.</returns>
        private bool IsEOL( int character )
        {
            return character == 0x0D ||
                character == 0x0A;
        }

        /// <summary>
        /// This will determine if the byte is a whitespace character or not.
        /// </summary>
        /// <param name="character">The character to test for whitespace.</param>
        /// <returns>true If the character is whitespace as defined by the AFM spec.</returns>
        private bool IsWhitespace( int character )
        {
            return character == ' ' ||
                character == '\t' ||
                character == 0x0D ||
                character == 0x0A;
        }
    }    
}