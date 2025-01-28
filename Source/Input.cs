using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LateNightGameEngine.Source
{
    static class Input
    {
        //inputs
        public static Dictionary<string, InputAction> AllInputActions = new Dictionary<string, InputAction>();

        //add input actions.  Basic functions support arrow keys
        public static InputAction Left = new("Left", Keyboard.Key.A, Keyboard.Key.Left);
        public static InputAction Right = new("Right", Keyboard.Key.D, Keyboard.Key.Right);
        public static InputAction Up = new("Up", Keyboard.Key.W, Keyboard.Key.Up);
        public static InputAction Down = new("Down", Keyboard.Key.S, Keyboard.Key.Down);
        
        public static InputAction Confirm = new("Confirm", Keyboard.Key.Enter, Keyboard.Key.E);
        public static InputAction Cancel = new("Cancel", Keyboard.Key.Q, Keyboard.Key.Space);

        public static InputAction Exit = new("Exit", Keyboard.Key.Escape, Keyboard.Key.F4);

        public static bool ActionKeyHeld(string actionName)
        {
            if(AllInputActions.ContainsKey(actionName))
            {
                return AllInputActions[actionName].Pressing; //
            }

            //TODO: Logger
            Log.Error($"Action: {actionName} not found. (This is case sensitive)! Returning False.");

            return false;
        }

        public static bool ActionOnKeyDown(string actionName)
        {
            if (AllInputActions.ContainsKey(actionName))
            {
                if (!AllInputActions[actionName].Pressed && AllInputActions[actionName].Pressing)
                {
                    AllInputActions[actionName].Pressed = true;
                    return AllInputActions[actionName].Pressed;
                }
            }
            else
            {
                //TODO: Logger
                Log.Error($"Action: {actionName} not found. (This is case sensitive)! Returning False.");
            }

            return false;
        }


        public static void GetKeyUp(KeyEventArgs e)
        {
            foreach (InputAction actions in AllInputActions.Values)
            {
                if (actions.Key == e.Code || (actions.SecondKey != Keyboard.Key.Unknown && actions.SecondKey == e.Code))
                {
                    actions.Pressing = false;
                    actions.Pressed = false;
                }
            }
        }

        public static void GetKeyDown(KeyEventArgs e)
        {
            foreach (InputAction actions in AllInputActions.Values)
            {
                if (actions.Key == e.Code || (actions.SecondKey != Keyboard.Key.Unknown && actions.SecondKey == e.Code))
                {
                    actions.Pressing = true;
                }
            }
        }
    }
}
