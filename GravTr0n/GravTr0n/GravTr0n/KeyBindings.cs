using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework.Input;

namespace GravTr0n
{
    public static class KeyBindings
    {
        static string keybindingsFilePath;
        static List<KeyEventBinding> keybindings = new List<KeyEventBinding>();

        /// <summary>
        /// Generate the keybindings according to the xml document
        /// </summary>
        /// <param name="filePath">the filepath to the xml document (needs to be a un compiled xml document)</param>
        public static void GenerateKeyBindingsFromXmlFile(string filePath)
        {
            XmlTextReader textReader = new XmlTextReader(filePath);
            bool bReadKeyBindings = false;

            keybindings = new List<KeyEventBinding>();
            keybindingsFilePath = filePath;
            while (textReader.Read())
            {
                if (textReader.NodeType == XmlNodeType.Element)
                {
                    //This is to prevent misreading the root element
                    if (textReader.Name.Equals("KeyBindings"))
                        bReadKeyBindings = true;
                    else if (bReadKeyBindings == true)
                        AddKeyBinding(textReader.Name, textReader.ReadString());
                }
            }
            textReader.Close();
        }

        /// <summary>
        /// This creates a new KeyEventBinding and adds it to the key bindings list.
        /// </summary>
        /// <param name="eventName">A string with the name of the event</param>
        /// <param name="keyName">A string with the name of the key</param>
        public static void AddKeyBinding(string eventName, string keyName)
        {
            KeyEventBinding newKeyBinding;

            try
            {
                Keys key = (Keys)Enum.Parse(typeof(Keys), keyName, true);
                Events keyEvent = (Events)Enum.Parse(typeof(Events), eventName, true);
                newKeyBinding = new KeyEventBinding(key, keyEvent);
                for (int i = 0; i < keybindings.Count; i++)
                {
                    if (keybindings[i].eventName.ToString() == eventName)
                        keybindings.RemoveAt(i);
                }
                keybindings.Add(newKeyBinding);
            }
            catch (InvalidCastException e)
            {
                System.Console.WriteLine("WARNING: Key or Event does not exist!");
                System.Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Creates a list of the current events that are activated (determined by the keys that are pressed)
        /// </summary>
        /// <returns>List of Events</returns>
        public static List<Events> GetActivatedEvents()
        {
            List<Events> activatedEvents = new List<Events>();

            foreach (Keys key in Keyboard.GetState().GetPressedKeys())
            {
                foreach (KeyEventBinding binding in keybindings)
                {
                    if (key == binding.key)
                    {
                        //System.Console.WriteLine(binding.key);
                        activatedEvents.Add(binding.eventName);
                        break;
                    }
                }
            }
            return activatedEvents;
        }

        /// <summary>
        /// Returns true if the specified event is activated (if the key bound to the event is pressed)
        /// </summary>
        /// <param name="keyEvent">Events</param>
        /// <returns>boolean</returns>
        public static bool IsEventActivated(Events keyEvent)
        {
            foreach (KeyEventBinding binding in keybindings)
            {
                if (binding.eventName == keyEvent)
                {
                    if (Keyboard.GetState().IsKeyDown(binding.key))
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
