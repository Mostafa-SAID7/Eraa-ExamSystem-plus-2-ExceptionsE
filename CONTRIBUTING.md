# 🤝 Contributing to Examination System (C# Console App)

First off, thank you for considering contributing to this project!  
Your time and effort help make this open-source educational platform better.

---

## 📦 Project Overview

The **Examination System** is a C# console application that simulates an exam experience. It uses object-oriented design with custom question types, grading logic, student notification via events, and array-based storage (no `List<T>`).

---

## 🛠️ How to Contribute

We welcome all kinds of contributions, including:

- 🐛 Bug reports and fixes
- ✨ New features (e.g., timer, save/load state, GUI version)
- 🧪 Improving testability and user feedback
- 📚 Documentation updates and enhancements

---

## 🧑‍💻 Code Style Guide

- Use **PascalCase** for class names and public members.
- Use **camelCase** for private variables and method parameters.
- Follow **C# conventions** (indentation, brackets, naming).
- Use **constructor chaining** where appropriate.
- Prefer **XML comments** for public methods and classes.

Example:

```csharp
/// <summary>
/// Represents a true or false question.
/// </summary>
public class TrueFalse : Question
{
    public bool CorrectAnswer { get; set; }
    // ...
}
```
## 🧪 Testing the Project

-To run and test the app:

Open the solution in Visual Studio or VS Code.

Run the application:
```
dotnet run
```
- When prompted, enter how many questions you want (e.g., 6).
- Proceed through the exam and verify:
- Student notification appears.
- Each question type is shown correctly.
- Answers are collected and graded.
- Logs are written to a file.

## 🔁 Submitting a Pull Request
 
 Before opening a PR:
 
- Fork the repo and create a new branch: feature/my-feature or fix/my-bug
- Ensure your code builds successfully
- Follow the PULL_REQUEST_TEMPLATE.md
- Link related issues using Closes #issue-number
- Submit your PR for review

## 📋 Checklist Before Submitting
 
 - My changes follow the code style of the project
 - I’ve added or updated XML comments where needed
 - I’ve tested the code manually in the console
 - I’ve added no breaking changes to the main logic
 - I’ve followed the pull request template

## 🙋 Questions or Suggestions?
Open an issue or start a discussion!
We’re happy to help.

Thank you for contributing! 🚀
