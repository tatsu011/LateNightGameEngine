using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    abstract class Engine
    {
        //x/y
        public uint Height = 720, Width = 1280;

        //window title
        public string Title = "Late Night Game Engine";

        //window color
        public Color WindowColor = Color.Black;

        //window renderer
        public static RenderWindow App;

        public Engine(uint width,  uint height, string title, Color windowColor)
        {
            //Assign variables.
            Width = width;
            Height = height;
            Title = title;
            WindowColor = windowColor;

            //initialize the app.
            App = new RenderWindow(new VideoMode(Width, Height), Title, style: Styles.Resize | Styles.Close);

            //Assign Events
            App.KeyPressed += App_KeyPressed;
            App.KeyReleased += App_KeyReleased;
            App.Closed += App_Closed;
            App.Resized += App_Resized;
            App.SetFramerateLimit(60);

            GameLoop();
        }

        private void App_Resized(object? sender, SizeEventArgs e)
        {
            if (sender != null)
            {
                RenderWindow window = (RenderWindow)sender;
                FloatRect drawSpace = new FloatRect(0,0, e.Width, e.Height);
                window.SetView(new View(drawSpace));

                //also call any corresponding update function for this.
            }

        }

        private void App_Closed(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                RenderWindow window = (RenderWindow)sender;
                window.Close();
            }
        }

        private void App_KeyReleased(object? sender, KeyEventArgs e)
        {
        }

        private void App_KeyPressed(object? sender, KeyEventArgs e)
        {
        }

        void GameLoop()
        {
            while(App.IsOpen)
            {
                App.DispatchEvents();
                App.Clear(WindowColor);
                OnUpdate();
                App.Display();
            }
        }

        public abstract void OnLoad();

        public virtual void OnUpdate() { }

        public abstract void OnUnload();
    }
}
