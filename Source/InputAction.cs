using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    internal class InputAction
    {
        public string Name { get; set; }
        public Keyboard.Key Key { get; set; }
        public Keyboard.Key SecondKey { get; set; }

        public bool Pressing = false;
        public bool Pressed = false;

        public InputAction(string name, Keyboard.Key key)
        {
            Name = name;
            Key = key;
            SecondKey = Keyboard.Key.Unknown;

            Input.AllInputActions.Add(name, this);
        }

        public InputAction(string name, Keyboard.Key key, Keyboard.Key secondKey)
        {
            Name = name;
            Key = key;
            SecondKey = secondKey;
            Input.AllInputActions.Add(name, this);

        }

    }
}
