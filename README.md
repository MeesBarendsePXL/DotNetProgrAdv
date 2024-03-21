# Guts-DotNetProgrAdv-23-24
In this repository you can find (visual studio) start solutions for the exercises of the **.NET Programming Advanced** course of **PXL-Digital**.

The exercises are grouped by chapter. There is a (Visual Studio) solution for each chapter.
A chapter solution contains multiple projects:

- A WPF project for each exercise. E.g. *Exercise01*
- A test project for each WPF project. E.g. *Exercise01.Tests*

![alt text][img_projects]

The WPF projects are (mostly) empty and waiting for you to complete them.
The matching test projects contain **automated tests** that can be run to check if your solution is correct.

## Chapters
The assignments for each chapter can be found in de README.md in the folder of the chapter or by clicking on one of the links below:
* [Chapter 1a - WPF Controls](Chapter1a_WPF_Controls/README.md)
* [Chapter 1b - WPF Layout](Chapter1b_WPF_Layout/README.md)
* [Chapter 2 - C# Language features](Chapter2_Language_Features/README.md)
* [Chapter 3-4 - Databinding, MVVM, Resources, Data Templates](Chapter3-4_DatabindingMVVM_ResourcesDataTemplates/README.md)
* [Chapter 5 - Onion archtecture](Chapter5_Onion_Architecture/README.md)
* [Chapter 6 - Entity Framework](Chapter6_EF/readme.md)
* [Chapter 7 - TDD](Chapter7_TDD/readme.md)

## Getting Started

### Accept the GitHub Classroom assignment
We will work with GitHub Classroom for the Guts PE.
The idea is that you make an online copy of the repository containing the startcode of the exercises. Only you (and the lectors) will have access to this online copy.

To proceed you need a GitHub account. If you don't have one yet, register youself via https://github.com. 

Now go to **https://classroom.github.com/a/HZnSbgEb**

Accept the assignment and GitHub will make that online copy of the repository containing the startcode. 
GitHub Classroom will show you the url of your repository. Navigate to this url and mark it as a favorite in your browser.

### Clone the repository

Start Visual Studio and select "Clone or check out code".

- Click on the *Clone or Download* button in the upper right corner of this webpage
- Copy the url of this repository

![alt text][img_clone_url]

- Paste the url you copied earlier into the field "Repository Location"
- Choose a local path, this is a local folder where the files will be copied to
- Click on the *Clone* button

![alt text][img_clone_vs]

Now you have a local copy of the online repository in which you can complete your exercises.

### Make a link with the original repository of the lectors (upstream)
Exercises will be added and changes will be made during the course. These changes will happen in the original repository made by the lectors (your online repository is a copy of this repository). We will call the original repository of the lectors the **upstream** repository.
Your personal online repository will be called the **origin** from now on.

You need a way to pull changes in the *upstream* repository into the *origin* repository. Follow the instructions below to make this possible. 

> [!IMPORTANT] 
> **It is important that you execute the instructions before pushing your first own commit to the origin!!**

* In Visual Studio, navigate in the menu to *Git -> Manage Remotes...*
* The *origin* (your personal online repo) is already configured
* Add a new remote named **upstream** that points to the original online repository made by the lectors.
     * Click on the *Add* button
          * Name: *upstream*
          * Fetch: *https://github.com/pxlit-projects/Guts-DotNetProgrAdv-23-24*
          * Push: *https://github.com/pxlit-projects/Guts-DotNetProgrAdv-23-24*
     * Click on *Save*
     * Open a command prompt and navigate to the folder that contains your local copy of the *origin* repository. Tip: in Visual Studio you can open a command prompt in the correct folder via the menu: *Git -> Open in Command Prompt*
     * Execute the command **git pull upstream main --allow-unrelated-histories**. This command downloads the commits made by the lectors and tries to merge them with your last local commit.
     * Execute the command **git push orgin main**. This commands will push (upload) the local commits to your online repository (*origin*).  

### Register on [guts-web.pxl.be](https://guts-web.pxl.be)

To be able to send your tests results to the Guts servers you need to register via [guts-web.pxl.be](https://guts-web.pxl.be/register).
After registration you will have the credentials you need to succesfully run automated tests for an exercise.

#### Start working on an exercise

1. Open the solution of the exercise. You can do this by doubleclicking on the **.sln** file from an explorer window or by opening visual studio, clicking on *File &rightarrow; Open a project or solution* and selecting the **.sln** file.

2. **Build the solution** (Menu: Build &rightarrow; Build Solution or Ctrl+Shift+B)

3. Write the code you need to write

#### Run the automated tests

1. Open the *Test Explorer* window (Menu: Test &rightarrow; Test Explorer)
2. In the top right corner, click on the *group by* button and make sure the automated tests are grouped by project (see the picture below). If you don't see any tests appearing, you probably should (re)build your solution.

![alt text][img_group_tests]

3. Right click on the project that matches your exercise and click on *Run* to execute the tests.
4. The first time you run a test a browser window will appear asking you to log in. You should fill in your credentials from [guts-web.pxl.be](https://guts-web.pxl.be).

![alt text][img_login_vs]

##### FAQ

**Why won't my tests run?**

The first time it can happen that you see the tests in the *Test Explorer* but if you run the tests, nothing happens. 
Try to clean your solution (**Build &rightarrow; Clean Solution**) and then to rebuild your solution (**Build &rightarrow; Rebuild solution**).

**Why can't I see my test results on the Guts website? Locally all my tests are green.**

After the tests are run, the testrunner will try to send your results to the server. In the *Output Window* you can see a log of the steps that are taken.
If anything goes wrong, you should be able to find more info in the *Output Window*.

The test results will only be sent to the server when you run all te tests of an exercise at once. If you run the tests one by one the results will not be sent to the servers.

#### Inspect the test results

Tests that pass will be green. Tests that don't pass will be red.

The *name of the test* gives an indication of what is tested in the automated test.
If you click on a test you can also read more detailed messages that may help you to find out what is going wrong.

![alt text][img_test_detail]

Although it is not a guarantee, having all tests green is a good indication that you completed the exercise correctly.

#### Check your results online

Test results of all students are sent to the Guts servers.
You can check your progress and compare with the averages of other students via [guts-web.pxl.be](https://guts-web.pxl.be).
Login, go to ".NET Advanced" in the navigation bar and select the chapter (module) you want to view.

![alt text][img_chapter_contents]

#### Save (commit) your work

It could happen that the code in the online repository changes and that you need to pull (download) a new version of the start code in your local repository.
The online repository does not contain your solutions. Pulling a new version of the code could result in you losing your work.

To avoid this you should regularly commit (save) your work in your local git database. If you have commited your work an you pull a new version, git will be able to automatically merge your work with the online changes.
It is recommended to **do a git commit every time you complete an exercise**.

- Go to *Git Changes* 

![alt text][img_git_changes]

- In the *Git Changes* screen you get an overview of the changes you made locally. Fill in a commit message (describing what you did) and click on the *Commit All* button. Your changes are now saved in your local git database.

![alt text][img_commit_your_work]

- By clicking on the *Solution Explorer* tab you go back to the main view for this local repository

#### Get a new version of the start code

It could happen that the lecturers fix bugs in the automated tests of the startcode or add new exercises and/or tests. These changes will happen in the **upstream** repository and you will need to get those changes in the **origin** repository.
Follow the steps below to get the new version of the code:

- Commit your work locally (see previous section)
- Open a command prompt and navigate to the folder that contains your local copy of the *origin* repository. Tip: in Visual Studio you can open a command prompt in the correct folder via the menu: *Git -> Open in Command Prompt*
- Enter the command *git pull upstream main*. This command downloads the new commits from the *upstream* repository and tries to merge them with your last local commit.
- Attention: local changes that were not in a local commit will get lost doing a pull
- Close the command prompt. Navigate to the *Branch History* window (*Git -> View Branch History*). You should see the commits (your local commits, the commits of the lectors and a merge commit). Push (upload) these local commits to your online repository (*origin*) by clicking on the *Push* link

[img_projects]:images/projects.png "Solution for chapter five with its projects"
[img_clone_vs]:images/clone_vs.png "Clone a project in Visual Studio"
[img_clone_url]:images/Clone_url.png "Copy repository url"
[img_cloned_repo_overview]:images/cloned_repo_overview.png "Cloned repository overview"
[img_startup_project]:images/startup_project.png "Choose startup project"
[img_group_tests]:images/group_tests.png "Group tests by project"
[img_test_detail]:images/test_detail.png "Details of a test result"
[img_login_vs]:images/login_vs.png "Visual studio login"
[img_chapter_contents]:images/chaptercontents.png "Chapter contents"
[img_commit_your_work]:images/commit_your_work.png "Commit your work"
[img_git_changes]:images/git_changes.png "Git Changes"
