# 🔐 Security Policy

## Supported Versions

This project is a demonstration console application for educational purposes. However, if adapted for production or educational environments, security should be taken seriously.

| Version | Supported |
|---------|-----------|
| 1.0     | ✅        |

---

## 🔎 Reporting a Vulnerability

If you discover a security vulnerability in this project:

1. **Do not publicly disclose the issue**.
2. Please email the maintainer or project lead directly at: `m.ssaid356@gmail.com`
3. Provide:
   - Description of the issue
   - Steps to reproduce
   - Potential impact
   - Suggestions for a fix (if known)

We will aim to respond within **48 hours**.

---

## 🛡️ Security Considerations

This project is a **console application** and not exposed to external users over a network. However, the following points should still be reviewed if extended:

- 🔐 **Input Validation**:
  - Ensure all user inputs (e.g., answers, number of questions) are validated to avoid exceptions or logic bypass.

- 📁 **File Handling**:
  - Ensure log files and saved data are stored in **secure, write-permitted paths only**.
  - Do not expose sensitive logs to unauthorized users.

- 🧾 **Sensitive Data**:
  - Avoid writing student identities or exam results in plain text for production.
  - Mask or encrypt sensitive data in future iterations.

- 👥 **Authentication/Authorization**:
  - If this is expanded to a multi-user environment, implement role-based access (e.g., students vs. teachers).

---

## 🔄 Future Improvements

- Add support for user authentication
- Enforce logging with timestamps
- Limit maximum attempts per student
- Support secure storage for questions and answers (e.g., JSON with checksum or encryption)

---

## 📢 Disclaimer

This application is built primarily for learning and academic demonstration. Do not use it in production without proper review and security enhancements.

