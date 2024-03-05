using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

// v Setup v
#region ! Setup !
/*

PUT THIS CODE BELOW TO YOUR MAIN WINDOW CLASS OR EGESUPX WONT WORK!

* public static MainWindow RootWindow;

That's all you gotta do to Setup EgeSupX. Thank you for using this!
 
*/
#endregion
// ^ Setup ^

namespace EgeSupX_Workspace // Your Namespace goes here...
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

            /// Random Decimal. Disabled due to an undetectable error. Please don't enable this.

            /*
            public static double RandomDecimal(double Min, double Max, byte digits, bool force = false)
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
            */
        }

        public class Media
        {
            public static void Play(MediaPlayer player, string uri, TimeSpan time, double volume = 100, double playbackrate = 1, bool force = false)
            {
                if (force)
                {
                    player.Open(new Uri(uri));
                    player.Position = time;
                    player.Volume = volume / 200;
                    player.SpeedRatio = playbackrate;
                    player.Play();
                }
                else
                {
                    try
                    {
                        player.Open(new Uri(uri));
                        player.Position = time;
                        player.Volume = volume / 200;
                        player.SpeedRatio = playbackrate;
                        player.Play();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }

            public static void Stop(MediaPlayer player)
            {
                player.Stop();
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
            public static void WindowStyle(WindowStyle style) { Application.Current.Dispatcher.Invoke(() => { MainWindow.RootWindow.WindowStyle = style; }); }
            public static void WindowState(WindowState state) { Application.Current.Dispatcher.Invoke(() => { MainWindow.RootWindow.WindowState = state; }); }
            public static void ResizeMode(ResizeMode mode) { Application.Current.Dispatcher.Invoke(() => { MainWindow.RootWindow.ResizeMode = mode; }); }
            public static void WindowTransparent(bool _) { Application.Current.Dispatcher.Invoke(() => { MainWindow.RootWindow.AllowsTransparency = _; }); }
        }
    }
}