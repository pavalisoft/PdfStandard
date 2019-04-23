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

namespace Pavalisoft.PdfStandard.FontBox.Util
{
    /// <summary>
    /// This is an implementation of a bounding box.  This was originally written for the AMF parser.
    /// </summary>

    public class BoundingBox
    {
        /// <summary>
        /// Creates an instance of <c>BoundingBox</c> using Default constructor.
        /// </summary>
        public BoundingBox() 
        {
        }
        
        /// <summary>
        /// Creates an instance of <c>BoundingBox</c>.
        /// </summary> 
        /// <param name="minX">lower left x value</param>
        /// <param name="minY">lower left y value</param>
        /// <param name="maxX">upper right x value</param>
        /// <param name="maxY">upper right y value</param>        
        public BoundingBox(float minX, float minY, float maxX, float maxY) 
        {
            LowerLeftX = minX;
            LowerLeftY = minY;
            UpperRightX = maxX;
            UpperRightY = maxY;
        }

        /// <summary>
        /// Creates an instance of <c>BoundingBox</c>.
        /// </summary> 
        /// <param name="numbers">list of four numbers</param>
        public BoundingBox(List<float> numbers)
        {
            LowerLeftX = numbers[0];
            LowerLeftY = numbers[1];
            UpperRightX = numbers[2];
            UpperRightY = numbers[3];
        }

        /// <summary>
        /// Gets or Sets Lower Left X value
        /// </summary>
        public float LowerLeftX { get; set; }
        
        /// <summary>
        /// Gets or Sets Lower Left Y value
        /// </summary>
        public float LowerLeftY { get; set; }

        /// <summary>
        /// Gets or Sets Upper Right X value
        /// </summary>
        public float UpperRightX { get; set; }
        
        /// <summary>
        /// Gets or Sets Upper Right Y value
        /// </summary>
        public float UpperRightY { get; set; }
        
        /// <summary>
        /// This will get the width of this rectangle as calculated by upperRightX - lowerLeftX.
        /// </summary>
        /// <value>The width of this rectangle.</value>
        public float Width { get => UpperRightX - LowerLeftX; }

        /// <summary>
        /// This will get the height of this rectangle as calculated by upperRightY - lowerLeftY.
        /// </summary>
        /// <value>The height of this rectangle.</value>
        public float Height { get => UpperRightY - LowerLeftY; }

        /// <summary>
        /// Checks if a point is inside this rectangle.
        /// </summary> 
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>true If the point is on the edge or inside the rectangle bounds.</returns>
        public bool Contains(float x, float y) => x >= LowerLeftX && x <= UpperRightX &&
                y >= LowerLeftY && y <= UpperRightY;

        /// <summary>
        /// This will return a string representation of this rectangle.
        /// </summary>
        /// <returns>This object as a string.</returns>
        public override string ToString() => $"[{LowerLeftX},{LowerLeftY},{UpperRightX},{UpperRightY}]";
    }
}