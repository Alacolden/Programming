using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba1;

namespace Laba1
{
    public class Keyboard : ComputerTechnology
    {
        public enum Key
        {
            None, Membrane, Mechanical, Optical
        }

        public enum Connection
        {
            None, Wired, Wireless
        }

        string _color;
        public Key KeysType { get; protected set; }
        public Connection ConnectionType { get; protected set; }
        public bool HasBacklight { get; protected set; }

        public string Color
        {
            get { return _color; }
            set
            {
                if (value.Any(charecter => !char.IsLetter(charecter))) // цвет должен содержать только буквы
                    throw new ArgumentException("Color can't consist of anything other than letters");
                _color = value;
            }
        }

        public Keyboard(string manufacturer, string color, Key keysType, Connection connectionType, bool hasBacklight)
            : base(manufacturer)
        {
            if (!color.All(char.IsLetter))
                throw new ArgumentException("Color can't consist of anything other than letters");

            _color = color;
            KeysType = keysType;
            ConnectionType = connectionType;
            HasBacklight = hasBacklight;
        }

        public Keyboard(string manufacturer, string color, string keysType, string connectionType, bool hasBacklight)
            : this(manufacturer, color, Key.None, Connection.None, hasBacklight)
        {
            // парсинг строк в enum с обработкой ошибок
            if (!Enum.TryParse(keysType, ignoreCase: true, out Key parsedKey))
                parsedKey = Key.None;
            KeysType = parsedKey;

            if (!Enum.TryParse(connectionType, ignoreCase: true, out Connection parsedConnection))
                parsedConnection = Connection.None;
            ConnectionType = parsedConnection;

        }

        public override void Print()
        {
            // массивы для преобразования enum в читаемые строки
            string[] KeysTypeLiterals = { "none", "membrane", "mechanical", "optical" };
            string[] ConnectionTypeLiterals = { "none", "wired", "wireless" };

            Console.WriteLine($"Manufacturer: {Manufacturer}, color: {_color}, type of keys: {KeysTypeLiterals[(int)KeysType]}, " +
                $"connection type: {ConnectionTypeLiterals[(int)ConnectionType]}, has Backlight: {HasBacklight.ToString().ToLower()}");
        }
    }
}

