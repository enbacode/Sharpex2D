﻿// Copyright (c) 2012-2014 Sharpex2D - Kevin Scholz (ThuCommix)
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

namespace Sharpex2D.Input
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    public class TouchPanel : IInputDevice
    {
        private readonly NativeInput<TouchState> _nativeTouch;

        /// <summary>
        /// Initializes a new TouchPanel class.
        /// </summary>
        /// <param name="nativeTouch">The NativeInput.</param>
        public TouchPanel(NativeInput<TouchState> nativeTouch)
        {
            _nativeTouch = nativeTouch;
        }

        /// <summary>
        /// A value indicating whether the Platform is supported.
        /// </summary>
        public bool IsPlatformSupported
        {
            get { return _nativeTouch.IsPlatformSupported; }
        }

        /// <summary>
        /// Gets the PlatformVersion.
        /// </summary>
        public Version PlatformVersion
        {
            get { return _nativeTouch.PlatformVersion; }
        }

        /// <summary>
        /// Gets the Guid.
        /// </summary>
        public Guid Guid
        {
            get { return _nativeTouch.Guid; }
        }

        /// <summary>
        /// Initializes the Device.
        /// </summary>
        public void InitializeDevice()
        {
            _nativeTouch.InitializeDevice();
        }

        /// <summary>
        /// Updates the object.
        /// </summary>
        /// <param name="gameTime">The GameTime</param>
        public void Update(GameTime gameTime)
        {
            _nativeTouch.Update(gameTime);
        }

        /// <summary>
        /// Gets the TouchState.
        /// </summary>
        /// <returns>TouchState.</returns>
        public TouchState GetState()
        {
            return _nativeTouch.GetState();
        }
    }
}