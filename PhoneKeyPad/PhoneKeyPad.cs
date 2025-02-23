using System;
using System.Collections;
using System.Collections.Generic;

namespace PhoneKeyPad
{
    public class KeyPad
    {
        public char KeyNumber {get; set;}
        public char BindingValue {get; set;}
        public Int16 cycleCount {get; set;}

        public KeyPad(char keynumber,char bindingvalue, Int16 cyclecount){
            KeyNumber = keynumber;
            BindingValue = bindingvalue;
            cycleCount = cyclecount;
        }
    }
    public static class OldPhone
    {
        public static string OldPhonePad(string input){
            
            string result = string.Empty;

            try{
                Dictionary<char, KeyPad> keyNumberToCharacter = new()
                {
                    { '0', new KeyPad('0', ' ', 1) },
                    { '1', new KeyPad('1', '&', 3) },
                    { '2', new KeyPad('2', 'A', 3) },
                    { '3', new KeyPad('3', 'D', 3) },
                    { '4', new KeyPad('4', 'G', 3) },
                    { '5', new KeyPad('5', 'J', 3) },
                    { '6', new KeyPad('6', 'M', 3) },
                    { '7', new KeyPad('7', 'P', 4) },
                    { '8', new KeyPad('8', 'T', 3) },
                    { '9', new KeyPad('9', 'W', 4) },
                };

                int charCounter = 0;
                string previousChar = "";
                int index = 0;
                List<char> listChar = new List<char>();
                
                foreach(var elem in input){
                    // Console.WriteLine("Index: " + index + ", element: " + elem);
                    if(elem == '#') break;
                    if(elem == ' '){
                        previousChar = "";
                        charCounter = 0;
                        index++;
                        continue;
                    }
                    if(elem == '*'){
                        if(listChar.Count > 0){
                            listChar.RemoveAt(listChar.Count - 1);
                        }
                        previousChar = "";
                        charCounter = 0;
                        index++;
                        continue;
                    }
                    if(index == 0 || elem.ToString() != previousChar){
                        previousChar = elem.ToString();
                        charCounter = 1;
                    }else if(elem.ToString() == previousChar){
                        charCounter++;
                        listChar.RemoveAt(listChar.Count - 1);
                    }
                    KeyPad keyPad = keyNumberToCharacter[elem];
                    listChar.Add((char)(keyNumberToCharacter[elem].BindingValue + ((charCounter - 1)%keyNumberToCharacter[elem].cycleCount)));
                    index++;
                }
                
                result = new String(listChar.ToArray());
                                
            }catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
                return result;
            }
            return result;
        }
    }
}