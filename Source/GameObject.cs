using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    public abstract class GameObject
    {
        public abstract Vector2 Position { get; set; }
        public abstract Vector2 Origin { get; set; }
        public abstract Vector2 Scale { get; set; }
        public abstract string Tag { get; set; } 
        public abstract List<GameObject> Children { get; set; }


        public GameObject()
        {
            Children = new List<GameObject>();
            Position = new Vector2();
            Origin = new Vector2();
            Scale = new Vector2(1, 1);
            Tag = "EmptyGameObject";
            Engine.RegisterGameObjects(this);
        }

        public virtual void AddChild(GameObject child)
        {
            Children.Add(child);
        }

        public virtual void RemoveChild(GameObject child)
        {
            if(Children.Contains(child))
                Children.Remove(child);
            child.DestroySelf();
        }

        public virtual GameObject GetChild(string childTag)
        {
            foreach(GameObject child in Children)
            {
                if(childTag.Equals(child.Tag)) 
                    return child;
            }
            Log.Error($"Failed to find child with tag:{childTag} from {Tag}");
            return null;
        }

        public virtual void DestroySelf()
        {
            Engine.RemoveGameObject(this);
            if(Children.Count == 0) return;

            foreach(GameObject child in Children)
            {
                child.DestroySelf();
            }
        }

        public virtual void UpdateChildren()
        {
            foreach(GameObject child in Children)
            {
                child.Position = Position + child.Origin;
            }
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDestroy();
        

    }
}
