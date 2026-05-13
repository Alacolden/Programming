using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    public class MonitorTech : ComputerTechnology
    {
        List<uint> _resolution = new List<uint>();
        float _screenSize;
        int _refreshRate;

        public MonitorTech(string manufacturer, List<uint> resolution, float screenSize, int refreshRate)
            : base(manufacturer)
        {
            if (resolution.Count != 2 || resolution[0] < 1 || resolution[1] < 1)
                throw new ArgumentException("The resolution must be represented by two positive integers.");
            _resolution = resolution;

            if (screenSize <= 0)
                throw new ArgumentException("Screen size must be a positive float number");
            _screenSize = screenSize;

            if (refreshRate < 1)
                throw new ArgumentException("Refresh rate must be a positive integer");
            _refreshRate = refreshRate;
        }

        public List<uint> Resolution
        {
            get => new List<uint>(_resolution);
            set
            {
                if (value.Count != 2 || value[0] < 1 || value[1] < 1)
                    throw new ArgumentException("The resolution must be represented by two positive integers.");

                _resolution = new List<uint>(value);
            }
        }

        public void SetResolution(uint width, uint height)
        {
            if (width < 1 || height < 1)
                throw new ArgumentException("Resolution consists of two positive integers");
            _resolution = new List<uint> { width, height };
        }

        public float ScreenSize
        {
            get { return _screenSize; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Screen size must be a positive float number");

                _screenSize = value;
            }
        }

        public int RefreshRate
        {
            get { return _refreshRate; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("Refresh rate must be a positive integer");

                _refreshRate = value;
            }
        }

        public override void Print()
        {
            Console.WriteLine($"Manufacturer: {Manufacturer}, resolution: {_resolution[0]} x {_resolution[1]}, " +
                $"screen size: {_screenSize},\n refresh rate: {_refreshRate} Hz");
        }
    }

}
