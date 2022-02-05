using System.Device.Gpio;

namespace Relay.Utilities;

class RelayUtility
{

    //this values are in BCM mode   25, 27, 27, 22
    //in Board mode those are       22, 11, 13, 15
    private List<int> _reservedPins = new List<int>() { 25, 17, 27, 22 };
    private List<int> _pins { get; set; }
    private GpioController _controller;

    public RelayUtility()
    {
        _pins = _reservedPins;
        _controller = new GpioController();
    }

    public RelayUtility(int pinCount)
    {
        _pins = new List<int>();

        for (int i = 0; i < pinCount; i++)
        {
            _pins.Add(_reservedPins[i]);
        }

        _controller = new GpioController();
    }

    public bool SetPinsValues(List<bool> values)
    {
        for (int i = 0; i < _pins.Count; i++)
        {
            try
            {
                _controller.OpenPin(_pins[i], PinMode.Output);

                _controller.Write(_pins[i], values[i] ? PinValue.Low : PinValue.High);
                Thread.Sleep(100);
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        return true;
    }

    public bool ResetPins()
    {
        for (int i = 0; i < _pins.Count; i++)
        {
            try
            {
                _controller.OpenPin(_pins[i], PinMode.Output);

                _controller.Write(_pins[i], PinValue.High);
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