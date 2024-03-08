using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media;
using System.Security;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using System.IO;

// Made by EgeSuperMine. Copyright(c) 2024. All Rights reserved.
// Version: 1.0.2

// Thank you for using EgeSupX!

namespace YourNamespace // Your Namespace goes here...
{
    public class EgeSupX
    {
        public EgeSupX() { Runtime.Start(); }

        /// <summary>
        /// Executes a .ESX File.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="System.IO.FileFormatException"></exception>
        /// <exception cref="System.IO.InvalidDataException"></exception>
        public static void Execute(string path, bool force = true)
        {
            MessageBox.Show("This Feature is unavailable for now!", "EgeSupX.Execute()", MessageBoxButton.OK);
            if (force) {
                StreamReader reader = new StreamReader(path);
                reader.ReadLine();
                reader.Dispose();
                reader.Close();
            } else {
                try { } catch (Exception) { MessageBox.Show("How'd you do this?.. Nevermind...", "EgeSuperMine", MessageBoxButton.OK); }
            }
        }

        public class Math
        {
            /// <summary>
            /// Generates a random number within the specified range.
            /// </summary>
            /// <returns>
            /// A random number within the specified range.
            /// </returns>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static double Random(double Min, double Max, bool force = false)
            {
                if (force) {
                    Random rnd = new Random();
                    double random = rnd.Next((int)Min, (int)Max + 1);
                    return random;
                } else {
                    try
                    {
                        Random rnd = new Random();
                        double random = rnd.Next((int)Min, (int)Max + 1);
                        return random;
                    } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }

                return double.NaN;
            }

            /// <summary>
            /// Generates a random decimal number within the specified range and precision.
            /// </summary>
            /// <returns>
            /// A random decimal number within the specified range, with the specified number of decimal digits.
            /// </returns>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static double RandomDouble(double Min, double Max, byte digits, bool force = false)
            {
                if (force)
                {
                    Random rnd = new Random();
                    double random = rnd.Next((int)Min, (int)Max + 1);
                    double randomDecimal;
                    if (digits <= 0) { return random; }
                    if (digits == 1) { randomDecimal = rnd.Next(1, 10); random += randomDecimal / 10; }
                    if (digits == 2) { randomDecimal = rnd.Next(10, 100); random += randomDecimal / 100; }
                    if (digits == 3) { randomDecimal = rnd.Next(100, 1000); random += randomDecimal / 1000; }
                    if (digits == 4) { randomDecimal = rnd.Next(1000, 10000); random += randomDecimal / 10000; }
                    if (digits == 5) { randomDecimal = rnd.Next(10000, 100000); random += randomDecimal / 100000; }
                    if (digits == 6) { randomDecimal = rnd.Next(100000, 1000000); random += randomDecimal / 1000000; }
                    if (digits == 7) { randomDecimal = rnd.Next(1000000, 10000000); random += randomDecimal / 10000000; }
                    if (digits == 8) { randomDecimal = rnd.Next(10000000, 100000000); random += randomDecimal / 100000000; }
                    if (digits == 9) { randomDecimal = rnd.Next(100000000, 1000000000); random += randomDecimal / 1000000000; }
                    if (digits >= 10) { MessageBox.Show($"Maximum Digit Number is 9.\n\nError: {digits} > 9\n\n\n", "EgeSupX.Math.RandomDecimal()", MessageBoxButton.OK); }
                    return random;
                }
                else
                {
                    try
                    {
                        Random rnd = new Random();
                        double random = rnd.Next((int)Min, (int)Max + 1);
                        double randomDecimal = double.NaN;
                        if (digits <= 0) { randomDecimal = 0; }
                        if (digits == 1) { randomDecimal = rnd.Next(1, 10); random += randomDecimal / 10; }
                        if (digits == 2) { randomDecimal = rnd.Next(10, 100); random += randomDecimal / 100; }
                        if (digits == 3) { randomDecimal = rnd.Next(100, 1000); random += randomDecimal / 1000; }
                        if (digits == 4) { randomDecimal = rnd.Next(1000, 10000); random += randomDecimal / 10000; }
                        if (digits == 5) { randomDecimal = rnd.Next(10000, 100000); random += randomDecimal / 100000; }
                        if (digits == 6) { randomDecimal = rnd.Next(100000, 1000000); random += randomDecimal / 1000000; }
                        if (digits == 7) { randomDecimal = rnd.Next(1000000, 10000000); random += randomDecimal / 10000000; }
                        if (digits == 8) { randomDecimal = rnd.Next(10000000, 100000000); random += randomDecimal / 100000000; }
                        if (digits == 9) { randomDecimal = rnd.Next(100000000, 1000000000); random += randomDecimal / 1000000000; }
                        if (digits >= 10) { MessageBox.Show($"Maximum Digit Number is 9.\n\nError: {digits} > 9\n\n\n", "EgeSupX.Math.RandomDecimal()", MessageBoxButton.OK); }
                        return random;
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }

                return double.NaN;
            }
        }

        public class Media
        {
            /// <summary>
            /// <para><i>No Description provided.</i></para>
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void Play(MediaPlayer player, string uri, TimeSpan time, double volume = 100, double playspeed = 1, bool force = false)
            {
                if (force)
                {
                    player.Open(new Uri(uri));
                    if (time != TimeSpan.Zero) { player.Position = time; }
                    if (volume != 100) { player.Volume = volume / 200; }
                    if (playspeed != 1) { player.SpeedRatio = playspeed; }
                    player.Play();
                }
                else
                {
                    try
                    {
                        player.Open(new Uri(uri));
                        if (time != TimeSpan.Zero) { player.Position = time; }
                        if (volume != 100) { player.Volume = volume / 200; }
                        if (playspeed != 1) { player.SpeedRatio = playspeed; }
                        player.Play();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }

            /// <summary>
            /// Plays Media through the MediaPlayer.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void Play(MediaPlayer player)
            {
                player.Play();
            }

            /// <summary>
            /// Stops the MediaPlayer.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void Stop(MediaPlayer player)
            {
                player.Stop();
            }

            /// <summary>
            /// Sets the Path for the MediaPlayer.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void Open(MediaPlayer player, string uri)
            {
                player.Open(new Uri(uri));
            }

            /// <summary>
            /// Sets the Position of the MediaPlayer.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void Position(MediaPlayer player, TimeSpan time)
            {
                player.Position = time;
            }

            /// <summary>
            /// Sets the Volume of the MediaPlayer.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void Volume(MediaPlayer player, double volume)
            {
                player.Volume = volume / 200;
            }

            /// <summary>
            /// Sets the Speed of the MediaPlayer.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void PlaySpeed(MediaPlayer player, double speed)
            {
                player.SpeedRatio = speed;
            }
        }

        public class Security
        {
            /// <summary>
            /// Gets if the Application is running as Administrator.
            /// </summary>
            /// <returns>
            /// True if the Application is running as Administrator, otherwise False.
            /// </returns>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="SecurityException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static bool IsAdministrator(bool force = false)
            {
                if (force) {
                    WindowsIdentity identity = WindowsIdentity.GetCurrent();
                    WindowsPrincipal principal = new WindowsPrincipal(identity);
                    return principal.IsInRole(WindowsBuiltInRole.Administrator);
                } else {
                    try {
                        WindowsIdentity identity = WindowsIdentity.GetCurrent();
                        WindowsPrincipal principal = new WindowsPrincipal(identity);
                        return principal.IsInRole(WindowsBuiltInRole.Administrator);
                    } catch (Exception ex) { Console.WriteLine(ex); }
                }

                return false;
            }
        }

        public class Runtime
        {
            public static double runtime = 0;
            public static double runtime_s = 0;
            public static double runtime_m = -1;
            public static double runtime_h = -1;
            public static double runtime_d = -1;
            static readonly Thread _runtime = new Thread(t => { runtime += 0.1; Thread.Sleep(100); });
            static readonly Thread _runtimes = new Thread(t => { runtime_s += 1; Thread.Sleep(1000); });
            static readonly Thread _runtimem = new Thread(t => { runtime_m += 1; Thread.Sleep(60000); });
            static readonly Thread _runtimeh = new Thread(t => { runtime_h += 1; Thread.Sleep(3600000); });
            static readonly Thread _runtimed = new Thread(t => { runtime_d += 1; Thread.Sleep(86400000); });

            /// <summary>
            /// Starts tracking the runtime of the application.
            /// </summary>
            public static void Start() { _runtime.Start(); _runtimes.Start(); _runtimem.Start(); _runtimeh.Start(); _runtimed.Start(); }

            /// <summary>
            /// Gets the runtime of the application in the specified time unit.
            /// </summary>
            /// <returns>
            /// The runtime of the application. If a time unit is specified, returns the runtime in that unit; otherwise, returns the total runtime in seconds.
            /// </returns>
            public static double GetRuntime(string _as = null)
            {
                if (_as == null) { return runtime; }
                else if (_as.ToLower() == "seconds" || _as.ToLower() == "s") { return runtime_s; }
                else if (_as.ToLower() == "minutes" || _as.ToLower() == "m") { return runtime_m; }
                else if (_as.ToLower() == "hours" || _as.ToLower() == "h") { return runtime_h; }
                else if (_as.ToLower() == "days" || _as.ToLower() == "d") { return runtime_d; }
                else { MessageBox.Show("Invalid [as] Type.", "EgeSupX.Runtime.GetRuntime()", MessageBoxButton.OK); }

                return runtime;
            }
        }

        public class UI
        {
            /// <summary>
            /// Sets the Position of the UI Element.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void Move(UIElement element, double x, double y, bool force = false)
            {
                if (force)
                {
                    Application.Current.Dispatcher.Invoke(() => {
                        Canvas.SetLeft(element, x);
                        Canvas.SetTop(element, y);
                    });
                }
                else
                {
                    try
                    {
                        Application.Current.Dispatcher.Invoke(() => {
                            Canvas.SetLeft(element, x);
                            Canvas.SetTop(element, y);
                        });
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }

            /// <summary>
            /// Gets the X (Left) Position of the UI Element.
            /// </summary>
            /// <returns>
            /// The X (Left) Position of the Window.
            /// </returns>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static double GetX(UIElement element, bool force = false)
            {
                double i = -1;

                if (force)
                {
                    Application.Current.Dispatcher.Invoke(() => {
                        i = Canvas.GetLeft(element);
                    });
                }
                else
                {
                    try
                    {
                        Application.Current.Dispatcher.Invoke(() => {
                            i = Canvas.GetLeft(element);
                        });
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }

                return i;
            }

            /// <summary>
            /// Gets the Y (Top) Position of the UI Element.
            /// </summary>
            /// <returns>
            /// The Y (Top) Position of the Window.
            /// </returns>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static double GetY(UIElement element, bool force = false)
            {
                double i = -1;

                if (force)
                {
                    Application.Current.Dispatcher.Invoke(() => {
                        i = Canvas.GetTop(element);
                    });
                }
                else
                {
                    try
                    {
                        Application.Current.Dispatcher.Invoke(() => {
                            i = Canvas.GetTop(element);
                        });
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }

                return i;
            }

            /// <summary>
            /// Sets the Size of the UI Element.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void Resize(UIElement element, double width, double height, bool force = false)
            {
                if (force)
                {
                    Application.Current.Dispatcher.Invoke(() => {
                        if (element is FrameworkElement elementF)
                        {
                            elementF.Width = width;
                            elementF.Height = height;
                        }
                    });
                }
                else
                {
                    try
                    {
                        Application.Current.Dispatcher.Invoke(() => {
                            if (element is FrameworkElement elementF)
                            {
                                elementF.Width = width;
                                elementF.Height = height;
                            }
                        });
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }

            /// <summary>
            /// Gets the Width of the UI Element.
            /// </summary>
            /// <returns>
            /// The Width of the UI Element.
            /// </returns>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static double GetWidth(UIElement element, bool force = false)
            {
                if (force)
                {
                    double i = double.NaN;

                    Application.Current.Dispatcher.Invoke(() => { if (element is FrameworkElement elementF) { i = elementF.Width; }});
                    return i;
                }
                else
                {
                    try
                    {
                        double i = double.NaN;

                        Application.Current.Dispatcher.Invoke(() => { if (element is FrameworkElement elementF) { i = elementF.Width; } });
                        return i;
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }

                return double.NaN;
            }

            /// <summary>
            /// Gets the Height of the UI Element.
            /// </summary>
            /// <returns>
            /// The Height of the UI Element.
            /// </returns>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static double GetHeight(UIElement element, bool force = false)
            {
                if (force)
                {
                    double i = double.NaN;

                    Application.Current.Dispatcher.Invoke(() => { if (element is FrameworkElement elementF) { i = elementF.Height; } });
                    return i;
                }
                else
                {
                    try
                    {
                        double i = double.NaN;

                        Application.Current.Dispatcher.Invoke(() => { if (element is FrameworkElement elementF) { i = elementF.Height; } });
                        return i;
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }

                return double.NaN;
            }
        }

        public class Window
        {
            /// <summary>
            /// Gets the Current Style of the Window.
            /// </summary>
            /// <returns>
            /// The Current Style of the Window.
            /// </returns>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static WindowStyle GetStyle(MainWindow window, bool force = false)
            {
                if (force) { Application.Current.Dispatcher.Invoke(() => { return window.WindowStyle; }); } else {
                    try { Application.Current.Dispatcher.Invoke(() => { return window.WindowStyle; }); } catch (Exception ex) { Console.WriteLine(ex); }
                }

                return WindowStyle.None;
            }

            /// <summary>
            /// Sets the Current Style of the Window.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void SetStyle(MainWindow window, WindowStyle style, bool force = false)
            {
                if (force) { Application.Current.Dispatcher.Invoke(() => { window.WindowStyle = style; }); } else {
                    try { Application.Current.Dispatcher.Invoke(() => { window.WindowStyle = style; }); } catch (Exception ex) { Console.WriteLine(ex); }
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /// <summary>
            /// Gets the Current State of the Window.
            /// </summary>
            /// <returns>
            /// The Current State of the Window.
            /// </returns>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static WindowState GetState(MainWindow window, bool force = false)
            {
                if (force) { Application.Current.Dispatcher.Invoke(() => { return window.WindowState; }); } else {
                    try { Application.Current.Dispatcher.Invoke(() => { return window.WindowState; }); } catch (Exception ex) { Console.WriteLine(ex); }
                }

                return WindowState.Normal;
            }

            /// <summary>
            /// Sets the Current State of the Window.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void SetState(MainWindow window, WindowState state, bool force = false)
            {
                if (force) { Application.Current.Dispatcher.Invoke(() => { window.WindowState = state; }); } else {
                    try { Application.Current.Dispatcher.Invoke(() => { window.WindowState = state; }); } catch (Exception ex) { Console.WriteLine(ex); }
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /// <summary>
            /// Gets the Resize Mode of the Window.
            /// </summary>
            /// <returns>
            /// The Resize Mode of the Window.
            /// </returns>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static ResizeMode GetResizeMode(MainWindow window, bool force = false)
            {
                if (force) { Application.Current.Dispatcher.Invoke(() => { return window.ResizeMode; }); } else {
                    try { Application.Current.Dispatcher.Invoke(() => { return window.ResizeMode; }); } catch (Exception ex) { Console.WriteLine(ex); }
                }

                return ResizeMode.NoResize;
            }

            /// <summary>
            /// Sets the Resize Mode of the Window.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void SetResizeMode(MainWindow window, ResizeMode mode, bool force = false)
            {
                if (force) { Application.Current.Dispatcher.Invoke(() => { window.ResizeMode = mode; }); } else {
                    try { Application.Current.Dispatcher.Invoke(() => { window.ResizeMode = mode; }); } catch (Exception ex) { Console.WriteLine(ex); }
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /*  // Sadly, Transparency() is Disabled from now on because 'AllowsTransparency' can only be changed through XAML, not C#.
                // You have the option to change it to True or False but it doesn't let you change it when the Window is Loaded.
                // So, R.I.P. to Transparency(). 

            public static void Transparency(MainWindow window, bool _, bool force = false)
            {
                if (force) { Application.Current.Dispatcher.Invoke(() => { window.AllowsTransparency = _; }); } else {
                    try { Application.Current.Dispatcher.Invoke(() => { window.AllowsTransparency = _; }); } catch (Exception ex) { Console.WriteLine(ex); }
                }
            }

            */
        }
    }
}
