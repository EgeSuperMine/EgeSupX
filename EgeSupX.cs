using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;

// Made by EgeSuperMine. Copyright(c) 2024. All Rights reserved.

namespace YourNamespace // Your Namespace goes here...
{
    public class EgeSupX
    {
        public class Math
        {
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

            public static void Play(MediaPlayer player)
            {
                player.Play();
            }

            public static void Stop(MediaPlayer player)
            {
                player.Stop();
            }

            public static void Open(MediaPlayer player, string uri)
            {
                player.Open(new Uri(uri));
            }

            public static void Position(MediaPlayer player, TimeSpan time)
            {
                player.Position = time;
            }

            public static void Volume(MediaPlayer player, double volume)
            {
                player.Volume = volume / 200;
            }

            public static void PlaySpeed(MediaPlayer player, double speed)
            {
                player.SpeedRatio = speed;
            }
        }

        public class Security
        {
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

        public class UI
        {
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
            public static WindowStyle GetStyle(MainWindow window, bool force = false)
            {
                if (force) { Application.Current.Dispatcher.Invoke(() => { return window.WindowStyle; }); } else {
                    try { Application.Current.Dispatcher.Invoke(() => { return window.WindowStyle; }); } catch (Exception ex) { Console.WriteLine(ex); }
                }

                return WindowStyle.None;
            }

            public static void SetStyle(MainWindow window, WindowStyle style, bool force = false)
            {
                if (force) { Application.Current.Dispatcher.Invoke(() => { window.WindowStyle = style; }); } else {
                    try { Application.Current.Dispatcher.Invoke(() => { window.WindowStyle = style; }); } catch (Exception ex) { Console.WriteLine(ex); }
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            public static WindowState GetState(MainWindow window, bool force = false)
            {
                if (force) { Application.Current.Dispatcher.Invoke(() => { return window.WindowState; }); } else {
                    try { Application.Current.Dispatcher.Invoke(() => { return window.WindowState; }); } catch (Exception ex) { Console.WriteLine(ex); }
                }

                return WindowState.Normal;
            }

            public static void SetState(MainWindow window, WindowState state, bool force = false)
            {
                if (force) { Application.Current.Dispatcher.Invoke(() => { window.WindowState = state; }); } else {
                    try { Application.Current.Dispatcher.Invoke(() => { window.WindowState = state; }); } catch (Exception ex) { Console.WriteLine(ex); }
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            public static ResizeMode GetResizeMode(MainWindow window, bool force = false)
            {
                if (force) { Application.Current.Dispatcher.Invoke(() => { return window.ResizeMode; }); } else {
                    try { Application.Current.Dispatcher.Invoke(() => { return window.ResizeMode; }); } catch (Exception ex) { Console.WriteLine(ex); }
                }

                return ResizeMode.NoResize;
            }

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
