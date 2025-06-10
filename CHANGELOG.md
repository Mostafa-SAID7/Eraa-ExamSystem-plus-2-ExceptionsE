# 📜 CHANGELOG

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/)  
This project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html)

---

## [1.0.0] – 2025-06-10

### 🚀 Initial Release

#### Added
- Full implementation of `Exam` and `FinalExam` classes with grading logic.
- `Question` base class and derived types:
  - ✅ `TrueOrFalse`
  - 🔘 `ChooseOne`
  - 📋 `ChooseAll`
- `QuestionList` class using arrays, logging each added question to a separate file.
- `Answer` and `AnswerList` classes for capturing user responses.
- `Student` class with event-based notification when exam starts.
- `Subject` class to associate with each exam.
- `ExamMode` enum with `Starting` and `Finished` values.
- Implementation of interfaces:
  - `ICloneable`
  - `IComparable`
- Overridden methods:
  - `ToString()`
  - `Equals()`
  - `GetHashCode()`
- Constructor chaining applied across all models.
- Console UI prompts:
  - Question entry
  - Student interaction
  - Final grade output

#### Changed
- N/A

#### Deprecated
- N/A

#### Removed
- N/A

#### Fixed
- N/A

---

## 🗓️ Planned for Future Releases

### [1.1.0] – TBD
- Add file-based answer persistence
- Implement exam result encryption
- Add basic authentication for teacher/student roles
- Export grades to CSV

---

## 🛠️ Dev Notes

- Ensure all new classes use XML comments for auto-generated documentation
- Logging is handled per-question list; unique filenames by timestamp

---

