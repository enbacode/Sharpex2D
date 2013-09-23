﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpexGL.Framework.Components;

namespace SharpexGL.Framework.Game.Timing
{
    public interface IGameLoop<in T> : IComponent
    {
        /// <summary>
        /// Starts the GameLoop.
        /// </summary>
        void Start();
        /// <summary>
        /// Stops the GameLoop.
        /// </summary>
        void Stop();
        /// <summary>
        /// Gets the TargetFrameTime.
        /// </summary>
        float TargetFrameTime { get; }
        /// <summary>
        /// Gets the TargetUpdateTime.
        /// </summary>
        float TargetUpdateTime {  get; }
        /// <summary>
        /// Indicates whether the GameLoop is running.
        /// </summary>
        bool IsRunning { get; }
        /// <summary>
        /// Gets or sets the Target FPS.
        /// </summary>
        float TargetFramesPerSecond { set; get; }
        /// <summary>
        /// Subscribes a T GameHandler to the IGameLoop.
        /// </summary>
        /// <param name="gameHandler">The GameHandler</param>
        void Subscribe(T gameHandler);
        /// <summary>
        /// Unsubscribes a T GameHandler from the IGameLoop.
        /// </summary>
        /// <param name="gameHandler">The GameHandler</param>
        void Unsubscribe(T gameHandler);
    }
}
