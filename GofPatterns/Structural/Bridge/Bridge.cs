using System;
using System.Collections.Generic;
using System.Text;

namespace GofPatterns.Structural.Bridge
{
    // implementation
    interface IDevice
    {
        void Enable();
        void Disable();
        bool IsEnabled();
        void SetVolume(double percent);
        double GetVolume();
    }

    //abstraction
    class Remote
    {
        protected IDevice Device;

        public Remote(IDevice device)
        {
            Device = device;
        }

        public void TurnOn()
        {
            if(!Device.IsEnabled())
                Device.Enable();
        }

        public void TurnOff()
        {
            if(Device.IsEnabled())
                Device.Disable();
        }

        public void IncreaseVolume()
        {
            var old = Device.GetVolume();
            Device.SetVolume(Math.Min(old+0.1d, 1));
        }

        public void DecreaseVolume()
        {
            var old = Device.GetVolume();
            Device.SetVolume(Math.Max(old - 0.1d, 0));
        }
    }

    // refined abstraction
    class BetterRemote : Remote
    {
        private double beforeMuted;
        public BetterRemote(IDevice device) : base(device)
        {
        }

        public void Mute()
        {
            var current = Device.GetVolume();
            if(current == 0) //was muted, restore
                Device.SetVolume(beforeMuted);
            else
            {
                beforeMuted = current;
                Device.SetVolume(0);
            }
        }
    }

    // concrete implementation
    class Television : IDevice
    {
        private bool enabled;
        private double volume;

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }

        public bool IsEnabled()
        {
            return enabled;
        }

        public void SetVolume(double percent)
        {
            volume = percent;
        }

        public double GetVolume()
        {
            return volume;
        }
    }
}
