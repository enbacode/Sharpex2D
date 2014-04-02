﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SharpexGL.Framework.Game;
using SharpexGL.Framework.Game.Timing;
using SharpexGL.Framework.Rendering;

namespace SharpexGL.Framework.Input.Devices
{
    public class Win32Keyboard : IKeyboard, IGameHandler
    {
        #region IDevice Implementation

        /// <summary>
        /// A value indicating whether the device is enabled.
        /// </summary>
        public bool IsEnabled
        {
            set; get;
        }
        /// <summary>
        /// Gets the Guid-Identifer of the device.
        /// </summary>
        public Guid Guid { get; private set; }
        /// <summary>
        /// Gets the device description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Initializes the Device.
        /// </summary>
        public void InitializeDevice()
        {

        }

        #endregion

        #region IGameHandler Implementation
        /// <summary>
        /// Called if the component should get updated.
        /// </summary>
        /// <param name="elapsed">The Elapsed.</param>
        public void Tick(float elapsed)
        {
            if (IsEnabled)
            {
                _lastkeystate.Clear();
                foreach (var current in _keystate)
                {
                    _lastkeystate.Add(current.Key, current.Value);
                }
            }
        }

        /// <summary>
        /// Processes a Render.
        /// </summary>
        /// <param name="renderer">The GraphicRenderer.</param>
        /// <param name="elapsed">The Elapsed.</param>
        public void Render(IRenderer renderer, float elapsed)
        {

        }

        /// <summary>
        /// Called if the component get initialized.
        /// </summary>
        public void Construct()
        {
            SGL.Components.Get<IGameLoop>().Subscribe(this);
        }

        #endregion

        #region Win32

        [DllImport("user32.dll")]
        private static extern int SetWindowsHookEx(HookType code, HookProc func, IntPtr hInstance, int threadID);

        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(int hhk, int nCode, IntPtr wParam, IntPtr lParam);

        private enum HookType
        {
            WH_KEYBOARD = 2,
            WH_MOUSE = 7,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }

        delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnhookWindowsHookEx(int hhk);

        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYUP = 0x0105;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        /// <summary>
        /// The Hookcallback.
        /// </summary>
        /// <param name="code">The Status.</param>
        /// <param name="wParam">The Handle.</param>
        /// <param name="lParam">The Handle.</param>
        private int HookCallback(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code < 0)
            {
                return CallNextHookEx(_hook, code, wParam, lParam); 
            }

            var vkcode = Marshal.ReadInt32(lParam);
            if (wParam == (IntPtr) WM_KEYUP || wParam == (IntPtr) WM_SYSKEYUP)
            {
                SetKeyState((Keys)vkcode, false);
            }
            if (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
            {
                SetKeyState((Keys)vkcode, true);
            }
            return CallNextHookEx(_hook, code, wParam, lParam);
        }

        #endregion

        private readonly int _hook;
        private readonly HookProc _hookCallback;

        private readonly Dictionary<Keys, bool> _keystate;
        private readonly Dictionary<Keys, bool> _lastkeystate;

        /// <summary>
        /// Initializes a new Keyboard class.
        /// </summary>
        [Obsolete("Use the standard keyboard provided in InputManager.")]
        public Win32Keyboard()
        {
            Guid = new Guid("CD23E9C3-CF0B-497E-985D-CB6C49D2E612");
            Description = "KeyboardDeviceWin32";
            _keystate = new Dictionary<Keys, bool>();
            _lastkeystate = new Dictionary<Keys, bool>();
            _hookCallback = new HookProc(HookCallback);
            GC.SuppressFinalize(_hookCallback);
            var hModule = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
           _hook = SetWindowsHookEx(HookType.WH_KEYBOARD_LL, _hookCallback,  hModule, 0);
        }

        /// <summary>
        /// Sets the internal KeyState.
        /// </summary>
        /// <param name="key">The Key.</param>
        /// <param name="state">The State.</param>
        private void SetKeyState(Keys key, bool state)
        {
            if (!_keystate.ContainsKey(key))
            {
                _keystate.Add(key, state);
            }
            _keystate[key] = state;
        }

        /// <summary>
        /// Determines, if a specific key is pressed down.
        /// </summary>
        /// <param name="key">The Key.</param>
        /// <returns>Boolean</returns>
        public bool IsKeyDown(Keys key)
        {
            return _keystate.ContainsKey(key) && _keystate[key];
        }
        /// <summary>
        /// Determines, if a specific key is pushed up.
        /// </summary>
        /// <param name="key">The Key.</param>
        /// <returns>Boolean</returns>
        public bool IsKeyUp(Keys key)
        {
            return !_keystate.ContainsKey(key) || !_keystate[key];
        }
        /// <summary>
        /// Determines, if a specific key is pressed.
        /// </summary>
        /// <param name="key">The Key.</param>
        /// <returns>Boolean</returns>
        public bool IsKeyPressed(Keys key)
        {
            return (!_lastkeystate.ContainsKey(key) || !_lastkeystate[key]) && _keystate.ContainsKey(key) && _keystate[key];
        }
        /// <summary>
        /// Deconstructs the Keyboard class.
        /// </summary>
        ~Win32Keyboard()
        {
            UnhookWindowsHookEx(_hook);
        }

    }
}
