// Copyright (c) 2012-2014 Sharpex2D - Kevin Scholz (ThuCommix)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the 'Software'), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.IO;
using Sharpex2D.Content;
using Sharpex2D.Content.Pipeline;

namespace Sharpex2D.Audio
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    [Content("Sound")]
    public class Sound : IContent, IDisposable
    {
        #region IDisposable Implementation

        /// <summary>
        /// Disposes the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing">The Disposing State.</param>
        public virtual void Dispose(bool disposing)
        {
            if (disposing && IsInitialized)
            {
                Data = null;
                IsInitialized = false;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new Sound.
        /// </summary>
        internal Sound()
        {
        }

        /// <summary>
        /// Initializes a new Sound based on the resource file.
        /// </summary>
        /// <param name="file">The File.</param>
        internal Sound(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException("The sound resource could not be located");
            }

            ResourcePath = file;
            Data = File.ReadAllBytes(ResourcePath);
            IsInitialized = true;
        }

        /// <summary>
        /// Sets or Gets the resource path.
        /// </summary>
        public string ResourcePath { get; private set; }

        /// <summary>
        /// Gets the Data.
        /// </summary>
        public byte[] Data { get; private set; }

        /// <summary>
        /// Determines, if the Sound is initialized.
        /// </summary>
        public bool IsInitialized { get; private set; }
    }
}