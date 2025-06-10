# Eraa-ExamSystem-plus-2-Exceptions

This project is a console-based Examination System written in C#. It allows teachers to define exams consisting of different question types and lets students take and get graded on the exam.

---

## 📌 Features

- Object-oriented design with inheritance and polymorphism
- Supports three question types:
  - ✅ True/False
  - 🔘 Choose One
  - 📋 Choose All That Apply
- Questions and Answers are associated and evaluated
- Logs all added questions to a file
- Uses enums for exam mode (`Starting`, `Finished`)
- Implements `ICloneable`, `IComparable`, and overrides:
  - `ToString()`
  - `Equals()`
  - `GetHashCode()`
- Custom student notification system using delegates and events

---

## 🚀 How to Run

1. **Open the project in Visual Studio or Visual Studio Code.**
2. **Ensure all `.cs` files are included in the project.**
3. **Build and run the application.**
4. On execution, the program will:
   - Ask how many questions you want.
   - Add different types of questions automatically.
   - Start the exam.
   - Notify all registered students.
   - Accept student answers and calculate the grade.

---

## 📖 Key Concepts Used

- **Abstract Classes & Inheritance**
- **Interfaces (`ICloneable`, `IComparable`)**
- **Array-based collections (not using `List<T>`)**
- **Event Handling & Delegates**
- **File Logging**
- **XML Documentation Comments**
- **Exam Correction with a `Dictionary<Question, Answer>`**

---

## 🔧 Customization Ideas

- Add more question types.
- Save exam results to a CSV or database.
- Implement timers.
- Build a GUI version using WinForms or WPF.
- Allow dynamic question creation instead of hardcoded ones.

---

## 📄 License

This project is provided for educational purposes. Free to use and modify.
