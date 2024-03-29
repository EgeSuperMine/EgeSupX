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
using System.Net.Http;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Management;
using System.Windows.Media.Effects;
using System.Drawing;
using System.ComponentModel;

// Made by EgeSuperMine. Copyright(c) 2024. All Rights reserved.
// Version: 1.1.1

// SETUP: \\
// 1. Put the code below to your Main Window:

// public static MainWindow rwindow;

// 2. Put the code below to your Loaded Event:

// rwindow = this;
// _ = new EgeSupX();

// /!\ You have to enable System.Windows.Forms and System.Drawing or EgeSupX won't work!
// Your Main Window has to be called "MainWindow" or EgeSupX won't work!

///////////////////////////////////////////////////////

// Thank you for using EgeSupX!


namespace EgeSupX_Workspace // Your Namespace goes here...
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

        /// <summary>
        /// Kills the current Process.
        /// </summary>
        public static void Shutdown() { Process.GetCurrentProcess().Kill(); }
        
        /// <summary>
        /// EgeSupX Time Unit.
        /// </summary>
        public enum TimeUnit
        {
            [Description("The Default EgeSupX Time Unit.")]
            Default,

            [Description("EgeSupX Time Unit in Seconds.")]
            Seconds,

            [Description("EgeSupX Time Unit in Minutes.")]
            Minutes,

            [Description("EgeSupX Time Unit in Hours.")]
            Hours,

            [Description("EgeSupX Time Unit in Days.")]
            Days
        }

        public class Error : System.Windows.Forms.Form
        {
            public static string _Text;
            public static string _Title;
            public static bool canIgnore;
            public static bool isOpen;
            public static ThreadStart OnIgnore;

            #region Error.Create()

            public static void Create(MainWindow window, string text, string title, bool CanIgnore, ThreadStart onIgnore = null)
            {
                isOpen = true;
                Application.Current.Dispatcher.Invoke(() => { window.WindowState = System.Windows.WindowState.Minimized; });
                if (onIgnore == null) { onIgnore = new ThreadStart(() => { return; }); }
                Thread FREEZE = new Thread(() => {
                    while (isOpen)
                    {
                        Application.Current.Dispatcher.Invoke(() => { window.WindowState = System.Windows.WindowState.Minimized; });
                        Thread.Sleep(100);
                }   }); FREEZE.Start();
                OnIgnore = onIgnore;

                _Text = text;
                if (title != null && title != "" && title != " ") { _Title = title; } else { _Title = "EgeSupX"; }
                canIgnore = CanIgnore;
                SetText(text);
                if (title != null && title != "" && title != " ") { SetTitle(title); } else { SetTitle("EgeSupX"); }
                System.Windows.Forms.Application.Run(new Error());
            }

            #endregion

            private static void SetText(string text) { _Text = text; }
            private static void SetTitle(string title) { if (_Title != "EgeSupX") { _Title = "EgeSupX." + title; } else { _Title = "EgeSupX"; } }
            public void BuildCreate() { errormsg.Text = _Text; if (!canIgnore) { bt_ignore.Visible = false; bt_ignore.Enabled = false; } }
            public Error() { InitializeComponent(); if (!canIgnore) { bt_ignore.Visible = false; bt_ignore.Enabled = false; } }

            private const int CP_DISABLE_CLOSE_BUTTON = 0x200;
            protected override System.Windows.Forms.CreateParams CreateParams {
                get {
                    System.Windows.Forms.CreateParams cp = base.CreateParams;
                    cp.ClassStyle |= CP_DISABLE_CLOSE_BUTTON;
                    return cp;
                }
            }

            #region InitializeComponent() - Do not touch this.
            private void InitializeComponent()
            {
                this.errormsg = new System.Windows.Forms.RichTextBox();
                this.bt_abort = new System.Windows.Forms.Button();
                this.bt_ignore = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // errormsg
                // 
                this.errormsg.Location = new System.Drawing.Point(12, 12);
                this.errormsg.Name = "errormsg";
                this.errormsg.ReadOnly = true;
                this.errormsg.Size = new System.Drawing.Size(585, 438);
                this.errormsg.TabIndex = 0;
                this.errormsg.Text = "Error.";
                // 
                // bt_abort
                // 
                this.bt_abort.Location = new System.Drawing.Point(522, 456);
                this.bt_abort.Name = "bt_abort";
                this.bt_abort.Size = new System.Drawing.Size(75, 23);
                this.bt_abort.TabIndex = 1;
                this.bt_abort.Text = "Abort";
                this.bt_abort.UseVisualStyleBackColor = true;
                this.bt_abort.Click += new System.EventHandler(this.Bt_abort_Click);
                // 
                // bt_ignore
                // 
                this.bt_ignore.Location = new System.Drawing.Point(441, 456);
                this.bt_ignore.Name = "bt_ignore";
                this.bt_ignore.Size = new System.Drawing.Size(75, 23);
                this.bt_ignore.TabIndex = 2;
                this.bt_ignore.Text = "Ignore";
                this.bt_ignore.UseVisualStyleBackColor = true;
                this.bt_ignore.Click += new System.EventHandler(this.Bt_ignore_Click);
                // 
                // ErrorFormB
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(609, 491);
                this.Controls.Add(this.bt_ignore);
                this.Controls.Add(this.bt_abort);
                this.Controls.Add(this.errormsg);
                this.DoubleBuffered = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "ErrorForm";
                this.ShowIcon = false;
                this.ShowInTaskbar = false;
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "EgeSupX";
                this.TopMost = true;
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ErrorForm_Closing);
                this.Load += new EventHandler(this.ErrorForm_Loaded);
                this.ResumeLayout(false);
            }

            private System.Windows.Forms.RichTextBox errormsg;
            private System.Windows.Forms.Button bt_abort;
            private System.Windows.Forms.Button bt_ignore;

            #endregion

            bool allowClose = false;
            private void Bt_abort_Click(object sender, EventArgs e) { Process.GetCurrentProcess().Kill(); }
            private void Bt_ignore_Click(object sender, EventArgs e) { Thread _n = new Thread(OnIgnore); _n.Start(); allowClose = true; isOpen = false; Close(); }
            private void ErrorForm_Loaded(object sender, EventArgs e) { errormsg.Text = _Text; this.Text = _Title; }
            private void ErrorForm_Closing(object sender, System.Windows.Forms.FormClosingEventArgs e) { isOpen = false; if (!allowClose) { this.Text = "EgeSupX"; e.Cancel = true; return; } }
        }

        public class Graphics
        {
            #region Graphics.Blur() - Creates a Blur Effect. The Default is 5.

            /// <summary>
            /// Creates a Blur Effect. The Default is 5.
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>
            public static void Blur(Grid target, byte range = 5, bool force = false)
            {
                try
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        BlurEffect blurEffect = new BlurEffect { Radius = range };
                        target.Effect = blurEffect;
                    });
                } catch (Exception ex)
                {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"target\" cannot be null." +
                        $"\n\n{ex}", "Graphics.Blur()", !force);
                    }
                    else {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Graphics.Blur()\n\n{ex}", "Graphics.Blur()", !force);
                    }
                }
            }

            #endregion
            #region Graphics.DropShadow() - Creates a Drop Shadow Effect.

            /// <summary>
            /// Creates a Drop Shadow Effect.
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>
            public static void DropShadow(UIElement target, byte depth = 5, System.Windows.Media.Color colors = default, byte radius = 5,
                ushort direction = 315, bool force = false)
            {
                try {
                    Application.Current.Dispatcher.Invoke(() => {
                        DropShadowEffect dropShadowEffect = new DropShadowEffect
                        {
                            ShadowDepth = depth,
                            Color = colors == default ? Colors.Black : colors,
                            BlurRadius = radius,
                            Direction = direction
                        };
                        target.Effect = dropShadowEffect;
                    });
                } catch (Exception ex)
                {
                    if (ex is NullReferenceException) {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"target\" cannot be null." +
                        $"\n\n{ex}", "Graphics.DropShadow()", !force);
                    }
                    else {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Graphics.DropShadow()\n\n{ex}", "Graphics.DropShadow()", !force);
                    }
                }
            }

            #endregion
            #region Graphics.Emboss() - Creates an Emboss Effect.

            /// <summary>
            /// Creates a Glow Effect.
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>
            public static void Emboss(UIElement target, System.Windows.Media.Color lightColor = default,
                System.Windows.Media.Color darkColor = default, byte embossDepth = 5, byte opacity = 1, bool force = false)
            {
                try
                {
                    Console.Title = null;

                    Application.Current.Dispatcher.Invoke(() => {
                        DropShadowEffect embossEffect = new DropShadowEffect
                        {
                            Color = lightColor,
                            ShadowDepth = embossDepth,
                            BlurRadius = 0,
                            Direction = 0,
                            Opacity = opacity
                        }; target.Effect = embossEffect;

                        DropShadowEffect darkEffect = new DropShadowEffect
                        {
                            Color = darkColor,
                            ShadowDepth = -embossDepth,
                            BlurRadius = 0,
                            Direction = 0,
                            Opacity = opacity
                        }; target.Effect = darkEffect;
                    });
                }
                catch (Exception) { Error.Create(MainWindow.rwindow, "Error: EgeSupX no longer supports this Graphic.", "Graphics.Emboss()", !force); }
            }

            #endregion
            #region Graphics.Glow() - Creates a Glow Effect.

            /// <summary>
            /// Creates a Glow Effect.
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>
            public static void Glow(UIElement target, System.Windows.Media.Color color = default, byte radius = 5, byte opacity = 1, bool force = false)
            {
                try {
                    Application.Current.Dispatcher.Invoke(() => {
                        DropShadowEffect glowEffect = new DropShadowEffect {
                            Color = color == default ? Colors.Black : color,
                            BlurRadius = radius,
                            Opacity = opacity
                        }; target.Effect = glowEffect;
                    });
                } catch (Exception ex) {
                    if (ex is NullReferenceException) {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"target\" cannot be null." +
                        $"\n\n{ex}", "Graphics.Glow()", !force);
                    }
                    else {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Graphics.Glow()\n\n{ex}", "Graphics.Glow()", !force);
                    }
                }
            }
            #endregion
            #region Graphics.OuterGlow() - Creates an Outer Glow Effect.

            /// <summary>
            /// Creates an Outer Glow Effect.
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>
            public static void OuterGlow(UIElement target, System.Windows.Media.Color color = default, byte radius = 5, byte depth = 5, byte opacity = 1, bool force = false)
            {
                try {
                    Application.Current.Dispatcher.Invoke(() => {
                        DropShadowEffect outerGlowEffect = new DropShadowEffect {
                            Color = color == default ? Colors.Black : color,
                            BlurRadius = radius,
                            ShadowDepth = depth,
                            Opacity = opacity
                        }; target.Effect = outerGlowEffect;
                    });
                } catch (Exception ex) {
                    if (ex is NullReferenceException) {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"target\" cannot be null." +
                        $"\n\n{ex}", "Graphics.OuterGlow()", !force);
                    } else {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Graphics.OuterGlow()\n\n{ex}", "Graphics.OuterGlow()", !force);
                    }
                }
            }

            #endregion
            #region Graphics.Reflection() - Creates a Reflection Effect.

            /// <summary>
            /// Creates a Reflection Effect.
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>
            public static void Reflection(UIElement target, bool force = false)
            {
                try {
                    Application.Current.Dispatcher.Invoke(() => {
                        VisualBrush reflectionBrush = new VisualBrush { Visual = target };

                        System.Windows.Shapes.Rectangle reflectionRect = new System.Windows.Shapes.Rectangle {
                            Width = target.RenderSize.Width,
                            Height = target.RenderSize.Height,
                            Fill = reflectionBrush
                        };

                        ScaleTransform flipTransform = new ScaleTransform { ScaleY = -1 };
                        reflectionRect.RenderTransform = flipTransform;
                        UI.Resize(reflectionRect, UI.GetWidth(reflectionRect), UI.GetHeight(reflectionRect) + target.RenderSize.Height);
                        if (VisualTreeHelper.GetParent(target) is Panel parent) { parent.Children.Add(reflectionRect); }
                    });
                } catch (Exception ex) {
                    if (ex is NullReferenceException) {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"target\" cannot be null." +
                        $"\n\n{ex}", "Graphics.Reflection()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Graphics.Reflection()\n\n{ex}", "Graphics.Reflection()", !force);
                    }
                }
            }

            #endregion
        }

        public class IO
        {
            #region IO.Write() - Writes the specified array of text lines to a file at the specified path...

            /// <summary>
            /// Writes the specified array of text lines to a file at the specified path. If the file exists, its contents are overwritten.
            /// </summary>
            public static void Write(string path, string[] text, bool force = false)
            {
                try {
                    if (File.Exists(path)) {
                        File.WriteAllBytes(path, new byte[0]);
                        StreamWriter writer = new StreamWriter(path, true); int line = 0;
                        while (line < text.Length) { writer.WriteLine(text[line]); line++; }
                        writer.Dispose();
                        writer.Close();
                    } else { Error.Create(MainWindow.rwindow, $"Error: File does not exist.\n\n", "IO.Write()", !force); }
                } catch (Exception ex) {
                    if (ex is IOException) {
                        Error.Create(MainWindow.rwindow, $"Error: Cannot access the file.\n\n{ex}", "IO.Write()", !force);
                    } else { Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.IO.Write()\n\n{ex}", "IO.Write()", !force); }
                }
            }

            #endregion
            #region IO.ReadLine() - Reads the specified line from a file at the specified path. Starts from Zero (0).

            /// <summary>
            /// Reads the specified line from a file at the specified path. Starts from Zero (0).
            /// </summary>
            /// <returns>The specified line from the file at the specified path.</returns>
            public static object ReadLine(string path, int lines, bool force = false)
            {
                try {
                    if (File.Exists(path)) {
                        StreamReader reader = new StreamReader(path, true); int line = 0;
                        while (line < lines) { Console.WriteLine(line); reader.ReadLine(); line++; }
                        object d0ne = reader.ReadLine();
                        reader.Dispose();
                        reader.Close();

                        return d0ne;
                    } else { Error.Create(MainWindow.rwindow, "Error: File does not exist.", "IO.ReadLine()", !force); }
                }
                catch (Exception ex)
                {
                    if (ex is IOException) {
                        Error.Create(MainWindow.rwindow, $"Error: Cannot access the file.\n\n{ex}", "IO.ReadLine()", !force);
                    }
                    else { Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.IO.ReadLine()\n\n{ex}", "IO.ReadLine()", !force); }
                }

                return 0;
            }

            #endregion
        }

        public class Math
        {
            #region Math.Random() - Generates a random number within the specified range.

            /// <summary>
            /// Generates a random number within the specified range.
            /// </summary>
            /// <returns>
            /// A random number within the specified range.
            /// </returns>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static double Random(double Min, double Max, bool force = false)
            {
                try
                {
                    Random rnd = new Random();
                    double random = rnd.Next((int)Min, (int)Max + 1);
                    return random;
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentOutOfRangeException) {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"Max\" must be bigger than parameter \"Min\". " +
                        $"--> [Min ({Min}) > Max ({Max})]\n\n{ex}", "Math.Random()", !force);
                    } else {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Math.Random()\n\n{ex}", "Math.Random()", !force);
                    }
                }

                return double.NaN;
            }

            #endregion
            #region Math.RandomDouble() - Generates a random decimal number within the specified range and precision.
            /// <summary>
            /// Generates a random decimal number within the specified range and precision.
            /// </summary>
            /// <returns>
            /// A random decimal number within the specified range, with the specified number of decimal digits.
            /// </returns>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static double RandomDouble(double Min, double Max, byte digits, bool force = false)
            {
                try
                {
                    Random rnd = new Random();
                    double random = rnd.Next((int)Min, (int)Max + 1);
                    double randomDecimal = double.NaN;
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
                    if (digits == 10) { randomDecimal = (double)(rnd.Next(0, 10) * 1e9) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 11) { randomDecimal = (double)(rnd.Next(0, 10) * 1e10) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 12) { randomDecimal = (double)(rnd.Next(0, 10) * 1e11) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 13) { randomDecimal = (double)(rnd.Next(0, 10) * 1e12) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 14) { randomDecimal = (double)(rnd.Next(0, 10) * 1e13) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 15) { randomDecimal = (double)(rnd.Next(0, 10) * 1e14) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 16) { randomDecimal = (double)(rnd.Next(0, 10) * 1e15) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 17) { randomDecimal = (double)(rnd.Next(0, 10) * 1e16) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 18) { randomDecimal = (double)(rnd.Next(0, 10) * 1e17) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 19) { randomDecimal = (double)(rnd.Next(0, 10) * 1e18) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 20) { randomDecimal = (double)(rnd.Next(0, 10) * 1e19) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 21) { randomDecimal = (double)(rnd.Next(0, 10) * 1e20) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 22) { randomDecimal = (double)(rnd.Next(0, 10) * 1e21) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 23) { randomDecimal = (double)(rnd.Next(0, 10) * 1e22) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits == 24) { randomDecimal = (double)(rnd.Next(0, 10) * 1e23) + rnd.Next(0, 1000000000); random += randomDecimal / 1e10; }
                    if (digits >= 24)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"digits\" must be lower than 24. " +
                        $"--> [digits ({digits}) > 9]\n\n", "Math.Random()", !force);
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentOutOfRangeException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"Max\" must be bigger than parameter \"Min\". " +
                        $"--> [Min ({Min}) > Max ({Max})]\n\n{ex}", "Math.RandomDouble()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Math.RandomDouble()\n\n{ex}", "Math.RandomDouble()", !force);
                    }
                }

                return double.NaN;
            }

            #endregion
            #region Math.RandomString() - Generates a random string within the specified length.

            /// <summary>
            /// Random String Generation Type.
            /// </summary>
            public enum StringType
            {
                [Description("Uppercase and Lowercase Letters with Numbers.")]
                BothNumbers,

                [Description("Uppercase and Lowercase Letters.")]
                BothOnly,

                [Description("Uppercase Letters with Numbers.")]
                UppercaseNumbers,

                [Description("Uppercase Letters.")]
                UppercaseOnly,

                [Description("Lowercase Letters with Numbers.")]
                LowercaseNumbers,

                [Description("Lowercase Letters.")]
                LowercaseOnly,

                [Description("Just Numbers.")]
                NumbersOnly,

                Null = -1
            }

            /// <summary>
            /// Generates a random string within the specified length.
            /// </summary>
            /// <returns>A random string within the specified length.</returns>
            /// <exception cref="OutOfMemoryException"></exception>
            /// <exception cref="IndexOutOfRangeException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            public static string RandomString(int length, StringType type = StringType.BothNumbers, string include = null, bool force = false)
            {
                try
                {
                    if (length <= 0) { Error.Create(MainWindow.rwindow, $"Error: Parameter \"length\" must be bigger than 0. --> [length ({length}) < 1]", "Math.RandomString()", !force); return null; }
                    Random random = new Random();
                    string BothNumbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789" + include;
                    string BothOnly = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" + include;
                    string UppercaseNumbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" + include;
                    string UppercaseOnly = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + include;
                    string LowercaseNumbers = "abcdefghijklmnopqrstuvwxyz0123456789" + include;
                    string LowercaseOnly = "abcdefghijklmnopqrstuvwxyz" + include;
                    string NumbersOnly = "0123456789" + include;
                    StringBuilder stringBuilder = new StringBuilder(length);

                    for (int i = 0; i < length; i++)
                    {
                        if (type == StringType.BothNumbers) { stringBuilder.Append(BothNumbers[random.Next(BothNumbers.Length)]); }
                        else if (type == StringType.BothOnly) { stringBuilder.Append(BothOnly[random.Next(BothOnly.Length)]); }
                        else if (type == StringType.UppercaseNumbers) { stringBuilder.Append(UppercaseNumbers[random.Next(UppercaseNumbers.Length)]); }
                        else if (type == StringType.UppercaseOnly) { stringBuilder.Append(UppercaseOnly[random.Next(UppercaseOnly.Length)]); }
                        else if (type == StringType.LowercaseNumbers) { stringBuilder.Append(LowercaseNumbers[random.Next(LowercaseNumbers.Length)]); }
                        else if (type == StringType.LowercaseOnly) { stringBuilder.Append(LowercaseOnly[random.Next(LowercaseOnly.Length)]); }
                        else if (type == StringType.NumbersOnly) { stringBuilder.Append(NumbersOnly[random.Next(NumbersOnly.Length)]); }
                        else if (type == StringType.Null) { stringBuilder.Append(include[random.Next(include.Length)]); }
                    }

                    return stringBuilder.ToString();
                }
                catch (Exception ex)
                {
                    if (ex is OutOfMemoryException) {
                        Error.Create(MainWindow.rwindow, $"Error: Out of Memory. " +
                        $"\n\n{ex}", "Math.RandomString()", !force);
                    }
                    else if (ex is IndexOutOfRangeException) {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"include\" cannot be Empty. " +
                        $"\n\n{ex}", "Math.RandomString()", !force);
                    }
                    else if (ex is NullReferenceException) {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"include\" cannot be null. " +
                        $"\n\n{ex}", "Math.RandomString()", !force);
                    } else {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Math.RandomString()\n\n{ex}", "Math.RandomString()", !force);
                    }
                }
                return null;
            }

            #endregion
            #region Math.Pi() - Returns the value of Pi (π) with the specified number of digits.

            /// <summary>
            /// Returns the value of Pi (π) with the specified number of digits.
            /// </summary>
            /// <returns>The value of Pi (π) with the specified number of decimal digits.</returns>
            public static decimal Pi(sbyte digits = 0, bool force = false)
            {
                if (digits <= 0) { return 3.14159265358979323846264338327950288419716939937510m; }
                if (digits > 0 && digits < 52) { return System.Math.Round(3.14159265358979323846264338327950288419716939937510m, digits); }
                if (digits > 52) { Error.Create(MainWindow.rwindow, "Error: Parameter \"digits\" must be lower than 52.", "Math.Pi()", !force); }

                return 3.14159265358979323846264338327950288419716939937510m;
            }

            #endregion
        }

        public class Media
        {
            #region Media.Play() - No Description provided.

            /// <summary>
            /// <para><i>No Description provided.</i></para>
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UriFormatException"></exception>
            public static void Play(MediaPlayer player, string uri, TimeSpan time, double volume = 100, double playspeed = 1, bool force = false)
            {
                try
                {
                    player.Open(new Uri(uri));
                    if (time != TimeSpan.Zero) { player.Position = time; }
                    player.Volume = volume / 100;
                    if (playspeed != 1) { player.SpeedRatio = playspeed; }
                    Application.Current.Dispatcher.Invoke(() => { player.Play(); });
                }
                catch (Exception ex)
                {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"player\" cannot be null." +
                        $"\n\n{ex}", "Media.Open()", !force);
                    }
                    else if (ex is UriFormatException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Uri Format not recognized or is empty." +
                        $"\n\n{ex}", "Media.Open()", !force);
                    }
                    else if (ex is ArgumentNullException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Uri cannot be null." +
                        $"\n\n{ex}", "Media.Open()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Media.Play()\n\n{ex}", "Media.Play()", !force);
                    }
                }
            }

            #endregion
            #region Media.Play() - Plays Media through the MediaPlayer.

            /// <summary>
            /// Plays Media through the MediaPlayer.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void Play(MediaPlayer player, bool force = false)
            {
                try { Application.Current.Dispatcher.Invoke(() => { player.Play(); }); }
                catch (Exception ex)
                {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"player\" cannot be null." +
                        $"\n\n{ex}", "Media.Play()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Media.Play()\n\n{ex}", "Media.Play()", !force);
                    }
                }
            }

            #endregion
            #region Media.Stop() - Stops the MediaPlayer.

            /// <summary>
            /// Stops the MediaPlayer.
            /// </summary>
            /// <exception cref="InvalidOperationException"></exception>
            /// <exception cref="ArgumentException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void Stop(MediaPlayer player, bool force = false)
            {
                try { player.Stop(); } catch (Exception ex) {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"player\" cannot be null." +
                        $"\n\n{ex}", "Media.Stop()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Media.Stop()\n\n{ex}", "Media.Stop()", !force);
                    }
                }
            }

            #endregion
            #region Media.Open() - Sets the Path for the MediaPlayer.

            /// <summary>
            /// Sets the Path for the MediaPlayer.
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>
            /// <exception cref="UriFormatException"></exception>
            /// <exception cref="ArgumentNullException"></exception>
            public static void Open(MediaPlayer player, string uri, bool force = false)
            {
                try { player.Open(new Uri(uri)); } catch (Exception ex) {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"player\" cannot be null." +
                        $"\n\n{ex}", "Media.Open()", !force);
                    }
                    else if (ex is UriFormatException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Uri Format not recognized or is empty." +
                        $"\n\n{ex}", "Media.Open()", !force);
                    }
                    else if (ex is ArgumentNullException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Uri cannot be null." +
                        $"\n\n{ex}", "Media.Open()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Media.Open()\n\n{ex}", "Media.Open()", !force);
                    }
                }
            }

            #endregion
            #region Media.Position() - Sets the Position of the MediaPlayer.

            /// <summary>
            /// Sets the Position of the MediaPlayer.
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>
            public static void Position(MediaPlayer player, TimeSpan time, bool force = false)
            {
                try { player.Position = time; } catch (Exception ex) {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"player\" cannot be null." +
                        $"\n\n{ex}", "Media.Position()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Media.Position()\n\n{ex}", "Media.Position()", !force);
                    }
                }
            }

            #endregion
            #region Media.Volume() - Sets the Volume of the MediaPlayer.

            /// <summary>
            /// Sets the Volume of the MediaPlayer.
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>

            public static void Volume(MediaPlayer player, double volume, bool force = false)
            {
                try { player.Volume = volume / 100; } catch (Exception ex)
                {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"player\" cannot be null." +
                        $"\n\n{ex}", "Media.Volume()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Media.Position()\n\n{ex}", "Media.Position()", !force);
                    }
                }
            }

            #endregion
            #region Media.PlaySpeed() - Sets the Speed of the MediaPlayer.

            /// <summary>
            /// Sets the Speed of the MediaPlayer.
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>
            public static void PlaySpeed(MediaPlayer player, double speed, bool force = false)
            {
                try { player.SpeedRatio = speed; }catch (Exception ex)
                {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"player\" cannot be null." +
                        $"\n\n{ex}", "Media.PlaySpeed()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Media.PlaySpeed()\n\n{ex}", "Media.PlaySpeed()", !force);
                    }
                }
            }

            #endregion
        }

        public class Security
        {
            #region Security.IsAdministrator() - Gets if the Application is running as Administrator.

            /// <summary>
            /// Gets if the Application is running as Administrator.
            /// </summary>
            /// <returns>
            /// True if the Application is running as Administrator, otherwise False.
            /// </returns>
            /// <exception cref="SecurityException">Thrown when the caller does not have the required permission to access the Windows user information or perform the operation.</exception>
            /// <exception cref="NotSupportedException">Thrown if the platform does not support the operation.</exception>
            /// <exception cref="PlatformNotSupportedException">Thrown if the platform does not support Windows identity or role management.</exception>
            /// <exception cref="OutOfMemoryException">Thrown if there is insufficient memory to perform the operation.</exception>
            /// <exception cref="SystemException">Thrown for various system-related errors, such as out-of-memory conditions or corrupted states.</exception>
            public static bool IsAdministrator(bool force = false)
            {
                try
                {
                    WindowsIdentity identity = WindowsIdentity.GetCurrent();
                    WindowsPrincipal principal = new WindowsPrincipal(identity);
                    return principal.IsInRole(WindowsBuiltInRole.Administrator);
                } catch (Exception ex)
                {
                    if (ex is SecurityException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Permission Declined.\n\n{ex}", "Security.IsAdministrator()", !force);
                    }
                    else if (ex is NotSupportedException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Operation not supported.\n\n{ex}", "Security.IsAdministrator()", !force);
                    }
                    else if (ex is PlatformNotSupportedException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Platform not supported.\n\n{ex}", "Security.IsAdministrator()", !force);
                    }
                    else if (ex is OutOfMemoryException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Out of Memory.\n\n{ex}", "Security.IsAdministrator()", !force);
                    }
                    else if (ex is SystemException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: System Failure.\n\n{ex}", "Security.IsAdministrator()", !force);
                    }
                    else { Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Security.IsAdministrator()\n\n{ex}", "Security.IsAdministrator()", !force); }
                }

                return false;
            }

            #endregion
        }

        public class Task
        {
            #region Task.Start() - Starts a new Task.

            /// <summary>
            /// Starts a new Task.
            /// </summary>
            /// <exception cref="ThreadStartException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            public static void Start(ThreadStart t, Thread id = null, bool force = false)
            {
                try { Application.Current.Dispatcher.Invoke(() => { id = new Thread(t); id.Start(); }); } catch (Exception ex)
                {
                    if (ex is ThreadStartException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Failed to Start Task.\n\n{ex}", "Task.Start()", !force);
                    }
                    else if (ex is NotSupportedException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Operation not supported.\n\n{ex}", "Task.Start()", !force);
                    }
                    else { Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Task.Start()\n\n{ex}", "Task.Start()", !force); }
                }
            }

            #endregion
            #region Task.Abort() - Aborts a Task.

            /// <summary>
            /// Starts a new Task.
            /// </summary>
            /// <exception cref="ThreadAbortException"></exception>
            /// <exception cref="NotSupportedException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            public static void Abort(Thread id, bool force = false)
            {
                try { Application.Current.Dispatcher.Invoke(() => { id.Abort(); }); } catch (Exception ex) {
                    if (ex is ThreadAbortException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Failed to Abort Task.\n\n{ex}", "Task.Abort()", !force);
                    }
                    else if (ex is NotSupportedException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Operation not supported.\n\n{ex}", "Task.Abort()", !force);
                    }
                    else if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"id\" cannot be null.\n\n{ex}", "Task.Abort()", !force);
                    }
                    else { Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Task.Abort()\n\n{ex}", "Task.Abort()", !force); }
                }
            }

            #endregion
            #region Task.GetStatus() - Gets if the Task is running or not.

            /// <summary>
            /// Gets if the Task is running or not.
            /// </summary>
            /// <returns>
            /// True if the Task is Runnning, otherwise False.
            /// </returns>
            /// <exception cref="NotSupportedException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            public static bool GetStatus(Thread id, bool force = false)
            {
                try { Application.Current.Dispatcher.Invoke(() => { return id.IsAlive; }); } catch (Exception ex) {
                    if (ex is NotSupportedException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Operation not supported.\n\n{ex}", "Task.GetStatus()", !force);
                    }
                    else if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"id\" cannot be null.\n\n{ex}", "Task.GetStatus()", !force);
                    }
                    else { Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Task.GetStatus()\n\n{ex}", "Task.GetStatus()", !force); }
                }

                return false;
            }

            #endregion
            #region Task.GetState() - Gets the State of the Task.

            /// <summary>
            /// Gets the State of the Task.
            /// </summary>
            /// <returns>
            /// The State of the Task.
            /// </returns>
            /// <exception cref="NotSupportedException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            public static System.Threading.ThreadState GetState(Thread id, bool force = false)
            {
                try { Application.Current.Dispatcher.Invoke(() => { return id.ThreadState; }); }
                catch (Exception ex)
                {
                    if (ex is NotSupportedException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Operation not supported.\n\n{ex}", "Task.GetState()", !force);
                    }
                    else if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"id\" cannot be null.\n\n{ex}", "Task.GetState()", !force);
                    }
                    else { Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Task.GetState()\n\n{ex}", "Task.GetState()", !force); }
                }

                return System.Threading.ThreadState.Unstarted;
            }

            #endregion
            #region Task.GetApartmentState() - Gets the Apartment State of the Task.

            /// <summary>
            /// Gets the Apartment State of the Task.
            /// </summary>
            /// <returns>
            /// The Apartment State of the Task.
            /// </returns>
            /// <exception cref="NotSupportedException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            public static ApartmentState GetApartmentState(Thread id, bool force = false)
            {
                try { Application.Current.Dispatcher.Invoke(() => { return id.GetApartmentState(); }); }
                catch (Exception ex)
                {
                    if (ex is NotSupportedException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Operation not supported.\n\n{ex}", "Task.GetApartmentState()", !force);
                    }
                    else if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"id\" cannot be null.\n\n{ex}", "Task.GetApartmentState()", !force);
                    }
                    else { Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Task.GetApartmentState()\n\n{ex}", "Task.GetApartmentState()", !force); }
                }

                return ApartmentState.Unknown;
            }

            #endregion
            #region Task.SetApartmentState() - Sets the Apartment State of the Task.

            /// <summary>
            /// Sets the Apartment State of the Task.
            /// </summary>
            /// <exception cref="NotSupportedException"></exception>
            /// <exception cref="NullReferenceException"></exception>
            public static void SetApartmentState(Thread id, ApartmentState state, bool force = false)
            {
                try { Application.Current.Dispatcher.Invoke(() => { id.SetApartmentState(state); }); } catch (Exception ex) {
                    if (ex is NotSupportedException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Operation not supported.\n\n{ex}", "Task.SetApartmentState()", !force);
                    }
                    else if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"id\" cannot be null.\n\n{ex}", "Task.SetApartmentState()", !force);
                    }
                    else { Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Task.SetApartmentState()\n\n{ex}", "Task.SetApartmentState()", !force); }
                }
            }

            #endregion
        }

        public class Runtime
        {
            public static double runtime = 0;
            public static double runtime_s = -1;
            public static double runtime_m = -1;
            public static double runtime_h = -1;
            public static double runtime_d = -1;
            static readonly Thread _runtime = new Thread(t => {
                long lastTick = Stopwatch.GetTimestamp(); long ticksPerMillisecond = Stopwatch.Frequency / 1000; while (true) {
                    long currentTick = Stopwatch.GetTimestamp(); if (currentTick - lastTick >= ticksPerMillisecond) { runtime += 1;
                        lastTick = currentTick;
                    }
                }
            });
            static readonly Thread _runtimes = new Thread(t => { while (true) { runtime_s += 1; Thread.Sleep(1000); } });
            static readonly Thread _runtimem = new Thread(t => { while (true) { runtime_m += 1; Thread.Sleep(60000); } });
            static readonly Thread _runtimeh = new Thread(t => { while (true) { runtime_h += 1; Thread.Sleep(3600000); } });
            static readonly Thread _runtimed = new Thread(t => { while (true) { runtime_d += 1; Thread.Sleep(86400000); } });

            #region Runtime.Start() - Starts tracking the runtime of the application.

            /// <summary>
            /// Starts tracking the runtime of the application.
            /// </summary>
            /// <exception cref="ThreadStateException">Thrown if the thread is in an invalid state for the requested operation.</exception>
            /// <exception cref="OutOfMemoryException">Thrown if there is insufficient memory to create or start a new thread.</exception>
            /// <exception cref="PlatformNotSupportedException">Thrown if the platform does not support the creation or management of threads.</exception>
            public static void Start()
            {
                try { _runtime.Start(); _runtimes.Start(); _runtimem.Start(); _runtimeh.Start(); _runtimed.Start(); } catch (Exception ex) {
                    if (ex is ThreadStateException)
                    {
                        if (ex is ThreadStartException && ex is ThreadAbortException) {
                            Error.Create(MainWindow.rwindow, $"Error: Thread State invalid." +
                            $"\n\n{ex}", "Runtime.Start()", false);
                        } else { return; }
                    }
                    else if (ex is OutOfMemoryException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Out of Memory." +
                        $"\n\n{ex}", "Runtime.Start()", false);
                    }
                    else if (ex is PlatformNotSupportedException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Platform not supported." +
                        $"\n\n{ex}", "Runtime.Start()", false);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Runtime.Start()\n\n{ex}", "Runtime.Start()", false);
                    }
                }
            }

            #endregion
            #region Runtime.GetRuntime() - Gets the runtime of the application in the specified time unit.

            /// <summary>
            /// Gets the runtime of the application in the specified time unit.
            /// </summary>
            /// <returns>
            /// The runtime of the application. If a time unit is specified, returns the runtime in that unit; otherwise, returns the total runtime in seconds.
            /// </returns>
            public static double GetRuntime(TimeUnit _as = TimeUnit.Default, bool force = false)
            {
                try
                {
                    if (_as == TimeUnit.Default) { return runtime; }
                    else if (_as == TimeUnit.Seconds) { return runtime_s; }
                    else if (_as == TimeUnit.Minutes) { return runtime_m; }
                    else if (_as == TimeUnit.Hours) { return runtime_h; }
                    else if (_as == TimeUnit.Days) { return runtime_d; }
                    else { Error.Create(MainWindow.rwindow, "Error: TimeUnit not recognized.\n\n", "Runtime.GetRuntime()", !force); }
                } catch (Exception ex) { Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Runtime.GetRuntime()\n\n{ex}", "Runtime.GetRuntime()", !force); }

                return runtime;
            }

            #endregion
        }

        public class UI
        {
            #region UI.Move() - Sets the Position of the UI Element.

            /// <summary>
            /// Sets the Position of the UI Element.
            /// </summary>
            /// <exception cref="ArgumentNullException">Thrown if the provided element is null.</exception>
            public static void Move(UIElement element, double x, double y, bool force = false)
            {
                try
                {
                    Application.Current.Dispatcher.Invoke(() => {
                        Canvas.SetLeft(element, x);
                        Canvas.SetTop(element, y);
                    });
                } catch (Exception ex)
                {
                    if (ex is ArgumentNullException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"element\" cannot be null." +
                        $"\n\n{ex}", "UI.Move()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.UI.Move()\n\n{ex}", "UI.Move()", !force);
                    }
                }
            }

            #endregion
            #region UI.GetX() - Gets the X (Left) Position of the UI Element.

            /// <summary>
            /// Gets the X (Left) Position of the UI Element.
            /// </summary>
            /// <returns>
            /// The X (Left) Position of the Window.
            /// </returns>
            /// <exception cref="ArgumentNullException"></exception>
            public static double GetX(UIElement element, bool force = false)
            {
                double i = -1;

                try {
                    Application.Current.Dispatcher.Invoke(() => {
                        i = Canvas.GetLeft(element);
                    }); return i;
                } catch (Exception ex) {
                    if (ex is ArgumentNullException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"element\" cannot be null." +
                        $"\n\n{ex}", "UI.GetX()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.UI.GetX()\n\n{ex}", "UI.GetX()", !force);
                    }
                }

                return i;
            }

            #endregion
            #region UI.GetY() - Gets the Y (Top) Position of the UI Element.

            /// <summary>
            /// Gets the Y (Top) Position of the UI Element.
            /// </summary>
            /// <returns>
            /// The Y (Top) Position of the Window.
            /// </returns>
            /// <exception cref="ArgumentNullException"></exception>
            public static double GetY(UIElement element, bool force = false)
            {
                double i = -1;

                try {
                    Application.Current.Dispatcher.Invoke(() => {
                        i = Canvas.GetTop(element);
                    }); return i;
                } catch (Exception ex) {
                    if (ex is ArgumentNullException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"element\" cannot be null." +
                        $"\n\n{ex}", "UI.GetY()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.UI.GetY()\n\n{ex}", "UI.GetY()", !force);
                    }
                }

                return i;
            }

            #endregion

            #region UI.Resize() - Sets the Size of the UI Element.

            /// <summary>
            /// Sets the Size of the UI Element.
            /// </summary>
            /// <exception cref="ArgumentNullException"></exception>
            public static void Resize(UIElement element, double width, double height, bool force = false)
            {
                try {
                    Application.Current.Dispatcher.Invoke(() => {
                        if (element is FrameworkElement elementF)
                        {
                            elementF.Width = width;
                            elementF.Height = height;
                        }
                    });
                } catch (Exception ex) {
                    if (ex is ArgumentNullException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"element\" cannot be null." +
                        $"\n\n{ex}", "UI.Resize()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.UI.Resize()\n\n{ex}", "UI.Resize()", !force);
                    }
                }
            }

            #endregion
            #region UI.GetWidth() - Gets the Width of the UI Element.

            /// <summary>
            /// Gets the Width of the UI Element.
            /// </summary>
            /// <returns>
            /// The Width of the UI Element.
            /// </returns>
            /// <exception cref="ArgumentNullException"></exception>
            public static double GetWidth(UIElement element, bool force = false)
            {
                try {
                    double i = double.NaN;

                    Application.Current.Dispatcher.Invoke(() => { if (element is FrameworkElement elementF) { i = elementF.Width; } });
                    return i;
                } catch (Exception ex) {
                    if (ex is ArgumentNullException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"element\" cannot be null." +
                        $"\n\n{ex}", "UI.GetWidth()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.UI.GetWidth()\n\n{ex}", "UI.GetWidth()", !force);
                    }
                }

                return double.NaN;
            }

            #endregion
            #region UI.GetHeight() - Gets the Height of the UI Element.

            /// <summary>
            /// Gets the Height of the UI Element.
            /// </summary>
            /// <returns>
            /// The Height of the UI Element.
            /// </returns>
            /// <exception cref="ArgumentNullException"></exception>
            public static double GetHeight(UIElement element, bool force = false)
            {
                try {
                    double i = double.NaN;

                    Application.Current.Dispatcher.Invoke(() => { if (element is FrameworkElement elementF) { i = elementF.Height; } });
                    return i;
                } catch (Exception ex) {
                    if (ex is ArgumentNullException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"element\" cannot be null." +
                        $"\n\n{ex}", "UI.GetHeight()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.UI.GetHeight()\n\n{ex}", "UI.GetHeight()", !force);
                    }
                }

                return double.NaN;
            }

            #endregion
        }

        public class Window
        {
            #region Window.GetStyle() - Gets the Current Style of the Window.

            /// <summary>
            /// Gets the Current Style of the Window.
            /// </summary>
            /// <returns>
            /// The Current Style of the Window.
            /// </returns>
            /// <exception cref="NullReferenceException"></exception>
            public static WindowStyle GetStyle(MainWindow window, bool force = false)
            {
                try { Application.Current.Dispatcher.Invoke(() => { return window.WindowStyle; }); } catch (Exception ex) {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"window\" cannot be null." +
                        $"\n\n{ex}", "Window.GetStyle()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Window.GetStyle()\n\n{ex}", "Window.GetStyle()", !force);
                    }
                }

                return WindowStyle.None;
            }

            #endregion
            #region Window.SetStyle() - Sets the Current Style of the Window.

            /// <summary>
            /// Sets the Current Style of the Window.
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>
            public static void SetStyle(MainWindow window, WindowStyle style, bool force = false)
            {
                try { Application.Current.Dispatcher.Invoke(() => { window.WindowStyle = style; }); } catch (Exception ex) {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"window\" cannot be null." +
                        $"\n\n{ex}", "Window.SetStyle()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Window.SetStyle()\n\n{ex}", "Window.SetStyle()", !force);
                    }
                }
            }

            #endregion

            #region Window.GetState() - Gets the Current State of the Window.

            /// <summary>
            /// Gets the Current State of the Window.
            /// </summary>
            /// <returns>
            /// The Current State of the Window.
            /// </returns>
            /// <exception cref="NullReferenceException"></exception>
            public static WindowState GetState(MainWindow window, bool force = false)
            {
                try { Application.Current.Dispatcher.Invoke(() => { return window.WindowState; }); } catch (Exception ex) {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"window\" cannot be null." +
                        $"\n\n{ex}", "Window.GetState()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Window.GetState()\n\n{ex}", "Window.GetState()", !force);
                    }
                }

                return WindowState.Normal;
            }

            #endregion
            #region Window.SetState() - Sets the Current State of the Window.

            /// <summary>
            /// Sets the Current State of the Window.
            /// </summary>
            /// <exception cref="NullReferenceException"></exception>
            public static void SetState(MainWindow window, WindowState state, bool force = false)
            {
                try { Application.Current.Dispatcher.Invoke(() => { window.WindowState = state; }); } catch (Exception ex) {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"window\" cannot be null." +
                        $"\n\n{ex}", "Window.SetState()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Window.SetState()\n\n{ex}", "Window.SetState()", !force);
                    }
                }
            }

            #endregion

            #region Window.GetResizeMode() - Gets the Resize Mode of the Window.

            /// <summary>
            /// Gets the Resize Mode of the Window.
            /// </summary>
            /// <returns>
            /// The Resize Mode of the Window.
            /// </returns>
            /// <exception cref="NullReferenceException"></exception>
            public static ResizeMode GetResizeMode(MainWindow window, bool force = false)
            {
                try { Application.Current.Dispatcher.Invoke(() => { return window.ResizeMode; }); } catch (Exception ex) {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"window\" cannot be null." +
                        $"\n\n{ex}", "Window.GetResizeMode()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Window.GetResizeMode()\n\n{ex}", "Window.GetResizeMode()", !force);
                    }
                }

                return ResizeMode.NoResize;
            }

            #endregion
            #region Window.SetResizeMode() - Sets the Resize Mode of the Window.

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
                try { Application.Current.Dispatcher.Invoke(() => { window.ResizeMode = mode; }); } catch (Exception ex) {
                    if (ex is NullReferenceException)
                    {
                        Error.Create(MainWindow.rwindow, $"Error: Parameter \"window\" cannot be null." +
                        $"\n\n{ex}", "Window.SetResizeMode()", !force);
                    }
                    else
                    {
                        Error.Create(MainWindow.rwindow, $"Unknown Error at EgeSupX.Window.SetResizeMode()\n\n{ex}", "Window.SetResizeMode()", !force);
                    }
                }
            }

            #endregion

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
