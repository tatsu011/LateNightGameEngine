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

        //gameobjects.
        public static List<GameObject> gameObjects = new List<GameObject>();
        public static List<GameObject> gameObjectsToAdds = new List<GameObject>();
        public static List<GameObject> gameObjectsToRemove = new List<GameObject>();

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
            Input.GetKeyUp(e);
        }

        private void App_KeyPressed(object? sender, KeyEventArgs e)
        {
            Input.GetKeyDown(e);
        }

        public static void RegisterGameObjects(GameObject gameObject)
        {
            gameObjectsToAdds.Add(gameObject);
        }

        public static void RemoveGameObject(GameObject gameObject)
        {
            gameObjectsToRemove.Add(gameObject);
        }

        void GameLoop()
        {
            LoadObjects();
            OnLoad();
            while(App.IsOpen)
            {
                App.DispatchEvents();
                App.Clear(WindowColor);

                UpdateObjects();
                OnUpdate();
                App.Display();
            }
        }

        public void LoadObjects()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.OnLoad();
            }
        }

        public void UpdateObjects()
        {
            if (gameObjects == null)
            {
                return;
            }

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].OnUpdate();
                gameObjects[i].UpdateChildren();
            }

            if (gameObjectsToAdds.Count > 0)
            {
                for (int i = 0; i < gameObjectsToAdds.Count; i++)
                {
                    gameObjectsToAdds[i].OnLoad();
                    gameObjects.Add(gameObjectsToAdds[i]);
                }
                gameObjectsToAdds.Clear();
            }

            if(gameObjectsToRemove.Count > 0)
            {
                for(int i = 0;i < gameObjectsToRemove.Count; i++)
                {
                    gameObjectsToRemove[i].OnDestroy();
                    gameObjects.Remove(gameObjectsToRemove[i]);
                }
                gameObjectsToRemove.Clear();
            }

        }

        public abstract void OnLoad();

        public virtual void OnUpdate() 
        {
            
            if(Input.ActionOnKeyDown("Cancel"))
            {
                foreach (GameObject gameObject in gameObjects) 
                    {
                        Log.Info($"Gameobject: {gameObject.Tag} at {gameObject.Position.X}, {gameObject.Position.Y}");
                    }
            }

            if (Input.ActionKeyHeld("Confirm"))
            {
                Console.WriteLine("Charging!");
            }
        
        }

        public abstract void OnUnload();
    }
}
