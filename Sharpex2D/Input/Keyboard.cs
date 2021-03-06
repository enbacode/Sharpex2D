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
    public class Keyboard : IInputDevice
    {
        private readonly NativeInput<KeyboardState> _nativeKeyboard;

        /// <summary>
        /// Initializes a new Keyboard class.
        /// </summary>
        /// <param name="nativeKeyboard">The NativeInput.</param>
        public Keyboard(NativeInput<KeyboardState> nativeKeyboard)
        {
            _nativeKeyboard = nativeKeyboard;
        }

        /// <summary>
        /// A value indicating whether the Platform is supported.
        /// </summary>
        public bool IsPlatformSupported
        {
            get { return _nativeKeyboard.IsPlatformSupported; }
        }

        /// <summary>
        /// Gets the PlattformVersion.
        /// </summary>
        public Version PlatformVersion
        {
            get { return _nativeKeyboard.PlatformVersion; }
        }

        /// <summary>
        /// Gets the Guid.
        /// </summary>
        public Guid Guid
        {
            get { return _nativeKeyboard.Guid; }
        }

        /// <summary>
        /// Initializes the Device.
        /// </summary>
        public void InitializeDevice()
        {
            _nativeKeyboard.InitializeDevice();
        }

        /// <summary>
        /// Updates the object.
        /// </summary>
        /// <param name="gameTime">The GameTime.</param>
        public void Update(GameTime gameTime)
        {
            _nativeKeyboard.Update(gameTime);
        }

        /// <summary>
        /// Gets the KeyboardState.
        /// </summary>
        /// <returns>KeyboardState.</returns>
        public KeyboardState GetState()
        {
            return _nativeKeyboard.GetState();
        }
    }
}