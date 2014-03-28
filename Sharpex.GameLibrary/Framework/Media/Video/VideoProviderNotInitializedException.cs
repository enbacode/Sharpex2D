﻿using System;

namespace SharpexGL.Framework.Media.Video
{
    public class VideoProviderNotInitializedException : Exception
    {
        public override string Message
        {
            get
            {
                return "IVideoProvider is not initialized. Use IVideoInitializer to initialize the VideoManager.";
            }
        }
    }
}
