// See https://aka.ms/new-console-template for more information
using Relay.Utilities;

Console.WriteLine("App Started...");

var pinCount = 4;
RelayUtility relayUtility = new RelayUtility(pinCount);

try
{
    var values = new List<bool>() { true, true, false, true };
    var result = relayUtility.SetPinsValues(values);
    System.Console.WriteLine(result.ToString());
}
catch (System.Exception)
{

    System.Console.WriteLine("ERROR"); ;
}
