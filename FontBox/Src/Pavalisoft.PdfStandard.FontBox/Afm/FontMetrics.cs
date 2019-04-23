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
using System.Collections.ObjectModel;
using Pavalisoft.PdfStandard.FontBox.Util;

namespace Pavalisoft.PdfStandard.FontBox.Afm
{
    /// <summary>
    /// This is the outermost AFM type. This can be created by the afm parser with a valid AFM document.
    /// </summary>
    public class FontMetrics
    {
        private int metricSets = 0;
        private readonly List<string> comments = new List<string>();
        private List<CharMetric> charMetrics = new List<CharMetric>();
        private Dictionary<string, CharMetric> charMetricsMap = new Dictionary<string, CharMetric>();
        private List<TrackKern> trackKern = new List<TrackKern>();
        private List<Composite> composites = new List<Composite>();
        private List<KernPair> kernPairs = new List<KernPair>();
        private List<KernPair> kernPairs0 = new List<KernPair>();
        private List<KernPair> kernPairs1 = new List<KernPair>();

        /// <summary>
        /// Creates an instance of <c>FontMetrics</c> using Default constructor
        /// </summary>
        public FontMetrics()
        {
        }

        /// <summary>
        /// This will get the width of a character.
        /// </summary>
        /// <param name="name">The character to get the width for.</param>
        /// <returns>The width of the character.</returns>
        public float GetCharacterWidth( string name )
        {
            float result = 0;
            CharMetric metric = charMetricsMap[name];
            if( metric != null )
            {
                result = metric.Wx;
            }
            return result;
        }
        
        /// <summary>
        /// This will get the width of a character.
        /// </summary>
        /// <param name="name">The character to get the width for.</param>
        /// <returns>The width of the character.</returns>
        public float GetCharacterHeight( string name )
        {
            float result = 0;
            CharMetric metric = charMetricsMap[name];
            if( metric != null )
            {
                result = metric.Wy; 
                if( result == 0 )
                {
                    result = metric.BoundingBox.Height;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the average width of a character.
        /// </summary>
        /// <value>The width of the character.</value>
        public float AverageCharacterWidth
        {
            get {
                float average = 0;
                float totalWidths = 0;
                float characterCount = 0;
                foreach (CharMetric metric in charMetrics)
                {
                    if( metric.Wx > 0 )
                    {
                        totalWidths += metric.Wx;
                        characterCount += 1;
                    }
                }
                if( totalWidths > 0 )
                {
                    average = totalWidths / characterCount;
                }
                return average;
            }
        }

        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <value>retruns readonly comments collection</value>
        public ReadOnlyCollection<string> Comments { get => comments.AsReadOnly();}
        
        /// <summary>
        /// Adds comment to the comments
        /// </summary>
        /// <param name="comment">The comment to add to this metric.</param>
        public void AddComment( string comment )
        {
            comments.Add( comment );
        }
        
        /// <summary>
        /// Gets or Sets the version of the AFM document.
        /// </summary>
        public float AfmVersion { get; set; }
        
        /// <summary>
        /// This will get the metricSets attribute.
        /// </summary>
        /// <remarks>This will set the metricSets attribute.  This value must be 0,1, or 2.</remarks>
        /// <exception cref="ArgumentException">If the metricSets attribute is not 0,1, or 2.</exception>
        public int MetricSets
        {
            get { return metricSets;}
            set { if( value < 0 || value > 2 )
            {
                throw new ArgumentException("The metricSets attribute must be in the " + "set {0,1,2} and not '" + value + "'");
            }
            metricSets = value;}
        }
        
        /// <summary>
        /// Gets or Sets the property fontName.
        /// </summary>
        public string FontName { get; set; }
        
        /// <summary>
        /// Gets or Sets the property Font fullName
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// Gets or Sets the property Font familyName
        /// </summary>
        public string FamilyName { get; set; }
        
        /// <summary>
        /// Gets or Sets the property Font weight.
        /// </summary>
        public string Weight { get; set; }
        
        /// <summary>
        /// Gets or Sets the property fontBBox.
        /// </summary>
        public BoundingBox FontBBox { get; set; }        

        /// <summary>
        /// Getter for property notice.
        /// </summary>
        public string Notice { get; set; }
        
        /// <summary>
        /// Gets or Sets the property encodingScheme.
        /// </summary>
        public string EncodingScheme { get; set; }
        
        /// <summary>
        /// Gets or Sets the property mappingScheme.
        /// </summary>
        public int MappingScheme { get; set; }
        
        /// <summary>
        /// Gets or Sets the property escChar.
        /// </summary>
        public int EscChar { get; set; }
        
        /// <summary>
        /// Gets or Sets the property characterSet.
        /// </summary>
        public string CharacterSet { get; set; }
        
        /// <summary>
        /// Gets or Sets the property characters.
        /// </summary>
        public int Characters { get; set; }
        
        /// <summary>
        /// Gets or Sets the property isBaseFont.
        /// </summary>
        public bool IsBaseFont { get; set; }
        
        /// <summary>
        /// Gets or Sets the property vVector.
        /// </summary>
        public float[] VVector { get; set; }
        
        /// <summary>
        /// Gets or Sets the property isFixedV.
        /// </summary>
        public bool IsFixedV { get; set; }
        
        /// <summary>
        /// Gets or Sets the property capHeight.
        /// </summary>
        public float CapHeight { get; set; }
        
        /// <summary>
        /// Gets or Sets the property xHeight.
        /// </summary>
        public float XHeight { get; set; }
        
        /// <summary>
        /// Gets or Sets the property ascender.
        /// </summary>
        public float Ascender { get; set; }
        
        /// <summary>
        /// Gets or Sets the property descender.
        /// </summary>
        public float Descender { get; set; }
        
        /// <summary>
        /// Gets or Sets the property fontVersion.
        /// </summary>
        public string FontVersion { get; set; }
        
        /// <summary>
        /// Gets or Sets the property underlinePosition.
        /// </summary>
        public float UnderlinePosition { get; set; }
        
        /// <summary>
        /// Gets or Sets the property underlineThickness.
        /// </summary>
        public float UnderlineThickness { get; set; }
        
        /// <summary>
        /// Gets or Sets the property italicAngle.
        /// </summary>
        public float ItalicAngle { get; set; }
        
        /// <summary>
        /// Gets or Sets the property charWidth.
        /// </summary>
        public float[] CharWidth { get; set; }
        
        /// <summary>
        /// Gets or Sets the property isFixedPitch.
        /// </summary>
        public bool FixedPitch { get; set; }
        
        /// <summary>
        /// Gets or Sets the property charMetrics.
        /// </summary>
        public ReadOnlyCollection<CharMetric> CharMetrics { 
            get => charMetrics.AsReadOnly();
            set {
                charMetrics = new List<CharMetric>();
                charMetricsMap = new Dictionary<string, CharMetric>(value.Count);
                foreach (CharMetric metric in value)
                {
                    charMetrics.Add(metric);
                    charMetricsMap[metric.Name] = metric;
                }    
            }
        }
        
        /// <summary>
        /// This will add another character metric.
        /// </summary>
        /// <param name="metric">The character metric to add.</param>
        public void AddCharMetric( CharMetric metric )
        {
            charMetrics.Add( metric );
            charMetricsMap[metric.Name] = metric;
        }

        /// <summary>
        /// Gets or Sets the property trackKern value.
        /// </summary>
        /// <value>Value of property trackKern.</value>
        public ReadOnlyCollection<TrackKern> TrackKern { 
            get => trackKern.AsReadOnly(); 
            set {
                trackKern = new List<TrackKern>(value.Count);
                foreach (TrackKern kern in value)
                {
                    trackKern.Add(kern);
                }    
            }
        }        

        /// <summary>
        /// This will add another track kern.
        /// </summary>
        /// <param name="kern">The track kerning data.</param>
        public void AddTrackKern( TrackKern kern )
        {
            trackKern.Add( kern );
        }

        /// <summary>
        /// Getter for property composites.
        /// </summary>
        public ReadOnlyCollection<Composite> Composites { 
            get => composites.AsReadOnly(); 
            set {
                composites = new List<Composite>(value.Count);
                foreach (Composite composite in value)
                {
                    composites.Add(composite);
                }    
            } 
        }
        
        /// <summary>
        /// This will add a single composite part to the picture.
        /// </summary>
        /// <param name="composite">The composite info to add.</param>
        public void AddComposite( Composite composite )
        {
            composites.Add( composite );
        }

        /// <summary>
        /// Gets or Sets the property kernPairs.
        /// </summary>
        public ReadOnlyCollection<KernPair> KernPairs {
            get => kernPairs.AsReadOnly(); 
            set {
                kernPairs = new List<KernPair>(value.Count);
                foreach (KernPair pair in value)
                {
                    kernPairs.Add(pair);
                }    
            } 
        }
        
        /// <summary>
        /// This will add a kern pair.
        /// </summary>
        /// <param name="kernPair">The kern pair to add.</param>
        public void AddKernPair( KernPair kernPair )
        {
            kernPairs.Add( kernPair );
        }

        /// <summary>
        /// Gets or Sets the property kernPairs0.
        /// </summary>
        public ReadOnlyCollection<KernPair> KernPairs0 { 
            get => kernPairs0.AsReadOnly(); 
            set {
                kernPairs0 = new List<KernPair>(value.Count);
                foreach (KernPair pair in value)
                {
                    kernPairs0.Add(pair);
                }    
            } 
        }
        
        /// <summary>
        /// This will add a kern pair.
        /// </summary>
        /// <param name="kernPair">The kern pair to add.</param>
        public void AddKernPair0( KernPair kernPair )
        {
            kernPairs0.Add( kernPair );
        }

        /// <summary>
        /// Gets or Sets the property kernPairs1.
        /// </summary>
        public ReadOnlyCollection<KernPair> KernPairs1 { 
            get => kernPairs1.AsReadOnly(); 
            set {
                kernPairs1 = new List<KernPair>(value.Count);
                foreach (KernPair pair in value)
                {
                    kernPairs1.Add(pair);
                }    
            }           
        }
        
        /// <summary>
        /// This will add a kern pair.
        /// </summary>
        /// <param name="kernPair">The kern pair to add.</param>
        public void AddKernPair1( KernPair kernPair )
        {
            kernPairs1.Add( kernPair );
        }

        /// <summary>
        /// Gets or Sets the property standardHorizontalWidth.
        /// </summary>
        public float StandardHorizontalWidth { get; set; }
        
        /// <summary>
        /// Gets or Sets the property standardVerticalWidth.
        /// </summary>
        public float StandardVerticalWidth { get; set; }        
    }
}