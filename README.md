# Jupiter

## Getting Started
This guide explains how to set up the **Jupiter Project** using C#, NUnit, and Selenium. Follow the steps below to install necessary tools, create the project, and push it to GitHub.

---

## Prerequisites
### Install an IDE
- Recommended: [Visual Studio](https://visualstudio.microsoft.com/).

### Install Git
- Download and install Git from [git-scm.com](https://git-scm.com/).  
- By default, Git is installed in `C:\Program Files`.

---

## Setup Instructions

### Step 1: Create a New NUnit Project
1. Open Visual Studio.
2. Create a new **NUnit Test Project** in C#.

---

### Step 2: Add Selenium Packages
Install the following NuGet packages in your project:

- `Selenium.WebDriver`
- `Selenium.Support`
- `Selenium.WebDriver.FirefoxDriver`
- `Selenium.WebDriver`

**To Install:**
1. Right-click on your project in Solution Explorer.
2. Select **Manage NuGet Packages**.
3. Search for the above packages and install them.

---

### Step 3: Set Up Git and Push to GitHub

#### Part 1: Initialize a Repository on GitHub
1. Navigate to [GitHub](https://github.com).
2. Create a new repository.
3. Copy the repository URL (e.g., `https://github.com/KaranjotSinghRandhawa/Jupiter`).

#### Part 2: Initialize Git in Your Local Project
1. Open Command Prompt or Terminal.
2. Navigate to your project folder:
   E.g. cd D:/IT/Projects/PlanIt/Jupiter
3. Run the following commands:
    echo "# Jupiter" >> README.md
    git init
    git add README.md
    git commit -m "Initial commit"
    git branch -M main
    git remote add origin https://github.com/KaranjotSinghRandhawa/Jupiter
    git push -u origin main

Now you're ready to develop, test, and push your code for the Jupiter Project!