 # OldPhonePad Library - Architecture & Algorithm Design
 ## 1. overview
 The `OldPhonePad` library processes numeric keypad inputs and converts them into text using multi-tap input logic. This document will explain the **internal architecture**, **design choices**, and **algorithm implementation**.
 ## 2. System Design
 Keymapping and logic processes are built in `PhoneKeyPad.cs` as a library. And also have Unit tests and ShowCase for example of usage.

 ```
 PhoneKeyPadSolution/
│── PhoneKeyPad/                 # Core library implementation
│   ├── PhoneKeyPad.cs           # Main logic for keypad input processing
│   ├── PhoneKeyPad.csproj
│
│── PhoneKeyPad.Tests/           # Unit tests for the library
│   ├── PhoneKeyPadTests.cs      
│   ├── PhoneKeyPad.Tests.csproj 
│
│── ShowCase/                    # Example of usage
│   ├── Program.cs                
│   ├── PhoneKeyPad.Tests.csproj
│
│── docs/                        # Documentation files
│   ├── ARCHITECTURE.md          # Internal structure and algorithm details
│
│── .github/workflows            # workflows
│   ├── dotnet.yml               # Automate test files
│
│── README.md                    # Project documentation
│── .gitignore                   # Ignore unnecessary files
│── PhoneKeyPad.sln              # Solution file
 ```
## 3. Algorithm Breakdown
The algorithm keypad processes numeric input by iteration by each character and applying different rules.
### ASCII-Based Character cycling
 * Each numeric key is paired with the set of characters, with the first character serving as the reference. The system determines the correct character by tracking key presses and applying modulo arithmetic to cycle through the available characters.
 * When a key is pressed multiple times, a counter increments, and the character is selected using:
   ```zsh
   char selectedChar = (char)(keyNumberToCharacter[elem].BindingValue
                         + ((charCounter - 1)%keyNumberToCharacter[elem].cycleCount));
   ```
    The modulo operation ensures that exceeding the available characters wraps the selection back to the first character.

### Input Processing Flow

 1. Iterate through each character in the input string
 2. Check for special characters:
    * `#` → Stops processing and returns the result.
    * `*` → Deletes the last character.
    * `space` → Separates character groups.
 3. Track consecutive key presses and cycle through corresponding characters using modulo operations.
 4. Convert the numeric sequence to the correct character based on ASCII calculations.
 5. Store the final processed text and return it.

### Key Processing Example

| Input Sequence | Process | Output |
| -------------- | ------- | ------ |
| "33#" | 'D' → 'E' | "E" |
| "227*#" |'A' → 'B', 'P', backspace| "B" |
| "4433555 555666#" |Full multi-tap conversion|"HELLO"|
|"8 88777444666*664#"|Space separation & correction|"TURING"|

## 4. Core Classes & Method
* KeyNumber: Numeric key assigned to this set.
* BindingValue: First letter mapped to the key.
* CycleCount: The number of characters associated with the key.
```zsh
public class KeyPad
{
    public char KeyNumber { get; set; }
    public char BindingValue { get; set; }
    public Int16 CycleCount { get; set; }

    public KeyPad(char keyNumber, char bindingValue, Int16 cycleCount)
    {
        KeyNumber = keyNumber;
        BindingValue = bindingValue;
        CycleCount = cycleCount;
    }
}
```
For the full logic code check on this file [Link](https://github.com/niphitphon8bit/PhoneKeyPadSolution/blob/7350ed6ca5ff2dbaa717a49c86cc14b43a2a59cd/PhoneKeyPad/PhoneKeyPad.cs)

## 5. Future Improvements
 - Available to put numbers mixed with the text.
 - Enhanced Input Handling → Add support for predictive text or T9 input.
