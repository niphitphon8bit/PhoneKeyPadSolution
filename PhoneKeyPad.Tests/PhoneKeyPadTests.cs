using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneKeyPad;

namespace PhoneKeyPad.Tests {
    
    [TestClass]
    public class PhoneKeyPadTests 
    {
        [TestMethod]
        public void Test_SingleLetter_Input()
        {
            string input = "2";
            string expected = "A";
            string result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_MultiplePresses_SameKey()
        {
            string input = "222";
            string expected = "C";
            string result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_CyclePresses_SameKey()
        {
            string input = "22222";
            string expected = "B";
            string result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_Space_Input()
        {
            string input = "0";
            string expected = " ";
            string result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_DeleteLastCharacter()
        {
            string input = "22*2";
            string expected = "A";
            string result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_MixedInput()
        {
            string input = "4433555 555666096667775553";
            string expected = "HELLO WORLD";
            string result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_HashStopsInput()
        {
            string input = "4433555#666";
            string expected = "HEL";
            string result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_EmptyInput()
        {
            string input = "";
            string expected = "";
            string result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_InvalidCharacters()
        {
            string input = "abc123";
            string expected = "";
            string result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_MultipleBackspaces()
        {
            string input = "22**33";
            string expected = "E";
            string result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_LongInput()
        {
            string input = new string('2', 1000);
            string expected = "A";
            string result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }
    }
}