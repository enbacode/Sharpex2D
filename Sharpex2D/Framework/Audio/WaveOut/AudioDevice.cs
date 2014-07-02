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
using System.Globalization;

namespace Sharpex2D.Framework.Audio.WaveOut
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    public class AudioDevice
    {
        /// <summary>
        /// Gets the Handle.
        /// </summary>
        public IntPtr Handle { private set; get; }

        /// <summary>
        /// Gets the Name.
        /// </summary>
        public string Name { private set; get; }

        /// <summary>
        /// Gets the DriverVersion.
        /// </summary>
        public string DriverVersion { private set; get; }

        /// <summary>
        /// Gets the Channels.
        /// </summary>
        public int Channels { private set; get; }

        /// <summary>
        /// A value indicating whether the device supports stereo.
        /// </summary>
        public bool StereoSupport
        {
            get { return Channels >= 2; }
        }

        /// <summary>
        /// Gets the Manufacturer.
        /// </summary>
        public short Manufacturer { private set; get; }

        /// <summary>
        /// Gets the ProductId.
        /// </summary>
        public short ProductId { private set; get; }

        /// <summary>
        /// A value indicating whether the feature is supported.
        /// </summary>
        /// <param name="feature">The WaveCapsSupported.</param>
        /// <returns>True if supported.</returns>
        public bool IsSupported(WaveCapsSupported feature)
        {
            return _supportedfeatures.HasFlag(feature);
        }

        /// <summary>
        /// Gets the Format.
        /// </summary>
        public WaveCapsFormats Format { private set; get; }

        private readonly WaveCapsSupported _supportedfeatures;

        /// <summary>
        /// Initializes a new AudioDevice class.
        /// </summary>
        /// <param name="deviceHandle">The DeviceHandle.</param>
        /// <param name="waveOutCaps">The WaveOutCaps.</param>
        internal AudioDevice(IntPtr deviceHandle, WaveOutCaps waveOutCaps)
        {
            _supportedfeatures = waveOutCaps.dwSupport;
            Name = waveOutCaps.szPname;
            Channels = waveOutCaps.wChannels;
            DriverVersion = waveOutCaps.vDriverVersion.ToString(CultureInfo.InvariantCulture);
            Handle = deviceHandle;
            ProductId = waveOutCaps.wPid;
            Manufacturer = waveOutCaps.wMid;
            Format = waveOutCaps.dwFormats;
        }
    }
}