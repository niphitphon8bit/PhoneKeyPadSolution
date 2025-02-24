# OldPhonePad Library

A C# library that simulates text input on old mobile phone keypad from number to text.

## 📌Feature

✅ Converts numeric keypad inputs into readable text.

✅ Supports backspace (*) and input stopping (#).

✅ Handles spaces correctly between characters.

## 🔍 How It Works

Each key corresponds to a set of characters, and pressing a key multiple times cycles through its options. For example:

| Key  | Characters |
| ---- | ---------- |
| 2  | A B C |
| 3  | D E F |
| 4  | G H I |
| 5  | J K L |
| 6  | M N O |
| 7  | P Q R S |
| 8  | T U V |
| 9  | W X Y Z |
| 0  | (space) |

Special Characters

\* → Deletes the last entered character.

\# → Terminates input and returns the result.

Example Input: "4433555 555666#" → Output: "HELLO"

## Getting Started

before we start, ensure you have the following installed:

.NET SDK 8.0 or later → [Download .NET SDK](https://dotnet.microsoft.com/en-us/download)

Git (optional, for cloning) → [Download Git](https://git-scm.com/downloads)

Visual Studio Community/Visual Studio Code (with C# Dev Kit) or JetBrains Rider (optional, for development)

These instructions will demonstrate how to install the OldPhoneKeyPad project and library and run them on your local machine for development and testing purposes.

### Installation

1. Clone the repository

       git clone https://github.com/niphitphon8bit/PhoneKeyPadSolution

2. Go inside the directory

       cd PhoneKeyPad

3. Restore the dependencies

       dotnet restore

4. Run test to ensure that everying is working

        dotnet test


## 📁 Project Structure
```zsh
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

# 📖 Using as a Library
To use OldPhoneKeyPad on your own C# project by add a reference to the project.

## install via NuGet Package
    dotnet add package PhoneKeyPad

## Add to Local Project Reference
    dotnet add reference ../PhoneKeyPad/PhoneKeyPad.csproj

## Example of usage
```zsh
using PhoneKeyPad;

class Program
{
    static void Main()
    {
        string result = OldPhone.OldPhonePad("4433555 555666#");
        Console.WriteLine(result); // Output: HELLO
    }
}
```

# Architecture

For more information, go to this link [ARCHITECTURE.md](doc/ARCHITECTURE.md)

## References
  - Github format [Link](https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax)
  - README.md Template [Link](https://www.readme-templates.com/)
