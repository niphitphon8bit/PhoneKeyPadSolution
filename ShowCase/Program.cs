using System;
using PhoneKeyPad;  // Import the namespace

public class Program
{
    public static void Main()
    {
        // example of usage
        string input = "4433555 555666096667775553#";
        string result = OldPhone.OldPhonePad(input);

        Console.WriteLine("output: " + result);
    }
}
