﻿// Permission is hereby granted, free of charge, to any person obtaining a copy
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

namespace Sharpex2D.Input
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    public abstract class NativeInput<T> : IInputDevice
    {
        /// <summary>
        /// Initializes a new NativeInput class.
        /// </summary>
        /// <param name="guid">The Guid.</param>
        protected NativeInput(Guid guid)
        {
            Guid = guid;
        }

        /// <summary>
        /// Gets the Guid.
        /// </summary>
        public Guid Guid { get; private set; }

        /// <summary>
        /// Gets the PlatformVersion.
        /// </summary>
        public abstract Version PlatformVersion { get; }

        /// <summary>
        /// A value indicating whether the Platform is supported.
        /// </summary>
        public virtual bool IsPlatformSupported
        {
            get { return PlatformVersion >= Environment.OSVersion.Version; }
        }

        /// <summary>
        /// Initializes the device.
        /// </summary>
        public abstract void InitializeDevice();

        /// <summary>
        /// Updates the object.
        /// </summary>
        /// <param name="gameTime">The GameTime.</param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Gets the State.
        /// </summary>
        /// <returns>TState.</returns>
        public abstract T GetState();
    }
}