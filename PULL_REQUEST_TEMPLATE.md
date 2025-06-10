# 📌 Pull Request – Examination System (C# Console App)

Thank you for contributing to the Examination System! Please provide the following details to help us review your pull request efficiently.

---

## ✅ Description

This pull request adds the full implementation of a C# console-based Examination System.

The project allows a teacher to define a set of exam questions (True/False, Choose One, Choose All), administer a final exam, accept and evaluate student answers, and log results.

Key features include:
- Array-based question management
- Event-driven student notification
- Final exam handling and grading logic
- Use of inheritance, interfaces, file I/O, and enums

---

## 🧪 Related Issue(s)

- Implements core exam functionality (#1)
- Adds support for different question types (#2)
- Handles student notifications (#3)
- Provides basic CLI interface (#4)

---

## 📸 Screenshots / Output

How many questions do you want? 6

Start Exam...
Student Ali has been notified: Exam Started!
Student Sara has been notified: Exam Started!

TF Header
TF Q1
(True / False)
Your answer: true

...

Your grade: 40 from 60

markdown
Copy
Edit

A file named `questions_XXXXXXXX.txt` is generated with the logged question content.

---

## 🔍 Changes Made

- [x] Added `Question.cs` with base `Question` class and 3 derived types
- [x] Created `QuestionList.cs` with array-based question storage and file logging
- [x] Implemented `Exam.cs` and `FinalExam.cs` with grading and display logic
- [x] Created `Answer.cs` and `AnswerList.cs` for student responses
- [x] Added `Student.cs` with event notification
- [x] Added `Subject.cs` to associate with the exam
- [x] Added `Enums.cs` to define `ExamMode`
- [x] Updated `Program.cs` to tie everything together and run the exam flow

---

## 🚦 Testing Steps

To test the project:

1. Open the solution in Visual Studio or VS Code.
2. Run the project (`dotnet run`).
3. Enter the number of exam questions when prompted (e.g., `6`).
4. Answer all displayed questions.
5. Verify:
   - Student notification messages are printed at the start.
   - Questions display correctly.
   - Grade is calculated and printed.
   - File named like `questions_*.txt` is created with question logs.

---

## 📎 Checklist

- [x] My code follows the project’s coding style
- [x] I have tested the project using the console interface
- [x] I have included XML comments for all public types and methods
- [x] I verified that question logs are written to separate files
- [x] I tested the exam grading and answer validation
- [x] I have used array types instead of `List<T>` as required
- [x] I used constructor chaining, `ICloneable`, `IComparable`, and overridden `ToString()`, `Equals()`, `GetHashCode()`
- [x] No breaking changes introduced to the exam interface or core logic

---

## 📝 Additional Notes

- The event model used for student notifications is based on C# delegates.
- File naming for question logs uses timestamps for uniqueness.
- Project is currently console-only, but can be upgraded to WPF or ASP.NET in future versions.
