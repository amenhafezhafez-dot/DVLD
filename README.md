# DVLD — Driver & Vehicle License Department System

A desktop application for managing the full lifecycle of driving licenses: people, applications, tests, local and international licenses, drivers, and detained licenses. Built with **C# WinForms + ADO.NET (.NET Framework)** using a layered architecture and a unified modern UI theme.

---

## Features

- **People management** — add, edit, search, and view people by ID, national number, or name.
- **User management** — manage system users with an activation status.
- **Applications** — create and manage driving license applications and application types.
- **Local driving licenses** — issue first-time licenses after passing the required tests.
- **International licenses** — issue, renew, and replace (lost / damaged) licenses.
- **Tests** — schedule and take vision, written, and street tests, with pass/fail tracking.
- **Detained licenses** — detain and release licenses, with fine-fee handling.
- **Drivers** — view drivers and their license history.
- **Modern unified UI** — a single theme engine styles every screen: blue sidebar dashboard, white cards, readable high-contrast text, and clean data grids.

---

## Architecture

The project follows a simple layered design:

- **Presentation layer** — WinForms UserControls and forms (`People_Manage`, `ShowLDLControl`, `Add_Inter_License`, `DashboardForm`, etc.).
- **Data access layer** — a central `clsReciveDatabase` class that handles all database reads and writes using ADO.NET.
- **UI theme layer** — `clsUITheme`, a global styling engine that auto-applies the design system (colors, fonts, sizing) to every form and control.

The main entry point is `Program.cs`, which installs the global theme hook and opens the dashboard after login.

---

## Screens overview

| Screen | Purpose |
|--------|---------|
| `DashboardForm` | Main shell: blue sidebar navigation + content host |
| `People_Manage` | Manage people and system users |
| `ShowLDLControl` | Manage local driving license applications |
| `Add_Inter_License` | Issue / renew / replace international licenses |
| `Add_Local_part2` | Add a new local driving license |
| `Manage_Tests` | Manage and take tests |
| `Vision_Test_Appoinment` | Schedule and record test appointments |
| `Manage_Detainted` | Detain and release licenses |
| `DriversControl` | View drivers |
| `IDDriver` | Issue a driving license to a driver |

---

## Getting started

### Requirements
- Windows
- Visual Studio 2019 or later
- .NET Framework
- SQL Server 2019

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/amenhafezhafez-dot/DVLD-System.git
   ```
2. Open `DVLD.sln` in Visual Studio.
3. Restore the database:
   - Attach the provided database backup / run the SQL script (add your `.bak` file or `.sql` script to the repo and name it here).
4. Update the connection string used by `clsReciveDatabase` to point to your SQL Server instance.
5. Press **F5** to build and run.

---

## The UI theme (`clsUITheme`)

All screens share one design system so the look stays consistent:

- Royal-blue sidebar and primary buttons
- White cards on a light background
- Automatic text-contrast (labels pick a readable color based on their background)
- Styled data grids, inputs, and buttons
- Over-sized forms are clamped to the screen and made scrollable

`clsUITheme.InstallGlobalHook()` (called once in `Program.cs`) themes every form automatically, and `clsUITheme.ApplyToControl(...)` themes controls hosted inside the dashboard.

---

## Project structure

```
DVLD/
├─ Program.cs                 # Entry point
├─ DashboardForm.cs           # Main dashboard shell
├─ Global/
│  └─ clsUITheme.cs           # UI theme engine
├─ User Control/              # All screens (People, Licenses, Tests, ...)
└─ DVLD.sln
```

---

## Notes & known limitations

- Some legacy screens were laid out manually; the theme fixes colors and contrast, not layout.
- Placeholder values (fees, current user ID) should be replaced with real configuration and the logged-in user's session.

---

## Author

**Ameen Hafez** — [GitHub profile](https://github.com/amenhafezhafez-dot)

## Project history

Originally built in 2024 as a driving-license management system. In 2026 it was 
revisited and improved: fixing several bugs, adding proper exception handling, and 
redesigning the entire UI with a unified modern theme.
