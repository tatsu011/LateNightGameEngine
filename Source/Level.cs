using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    internal abstract class Level
    {
        public abstract string Name { get; set; }
        public abstract bool Init {  get; set; }



        public Level(string name)
        {
            this.Name = name;
            Init = false;
            LevelManager.Levels.Add(this);
        }

        public abstract void OnLoad();

        public abstract void OnUpdate();

        public virtual void OnDestroy()
        {
            foreach (GameObject obj in Engine.gameObjects)
            {
                obj.DestroySelf();
            }
        }


    }
}
