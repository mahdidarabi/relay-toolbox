using System.Device.Gpio;

namespace Relay.Utilities;

class RelayUtility
{

    //this values are in BCM mode   25, 27, 27, 22
    //in Board mode those are       22, 11, 13, 15
    private List<int> _reservedPins = new List<int>() { 25, 17, 27, 22 };
    public List<int> Pins { get; set; }
    private GpioController _controller;

    public RelayUtility()
    {
        Pins = _reservedPins;
        _controller = new GpioController();
    }

    public RelayUtility(int pinCount)
    {
        Pins = new List<int>();

        for (int i = 0; i < pinCount; i++)
        {
            Pins.Add(_reservedPins[i]);
        }

        _controller = new GpioController();
    }

    public bool SetPinsValues(List<bool> values)
    {
        for (int i = 0; i < Pins.Count; i++)
        {
            try
            {
                _controller.OpenPin(Pins[i], PinMode.Output);

                _controller.Write(Pins[i], values[i] ? PinValue.Low : PinValue.High);
                Thread.Sleep(100);
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        return true;
    }

}