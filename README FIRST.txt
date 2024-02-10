Previous requirements:

DEFAULT BROWSER, GOOGLE CHROME.
Visual Studio 2022.
SQL Server 19.1
SQL Server Management Studio.

----------------------

WHAT'S THIS APPLICATION ABOUT?

I built this application to analyze the basic CRUD operations included in the 
ASP.NET Web Application MVC 4 project template of Visual Studio 2013. Also I've made an analysis of how long would it take me to manually create a classic 3-Tier
monolithic Web application using the mentioned template.
I've recently upgraded this application so it can run on Visual Studio 2022.

----------------------

HOW TO RUN IT LOCALLY?

1- Open the Visual Studio solution "\\MVC48_CRUD EF6\DEMO MVCEF6\MVCEF6.sln"
2- Run the solution.
3- Explore the Test Model CRUD operations at http://localhost:6046/Testmodel

----------------------

Highlights:


    - This a monolithic 3-tier application:
         First Tier: UI (MVCEF6.Web)
         Second Tier: Business Logic (MVCEF6.BL)
         Third Tier: Data Access (MVCEF6.Model)

    - This application implements EF6 Code First Data Base technology. Which
      allows rapid deployment on any computer. The Database "MVCEF6Context" gets created on your local installation of SQL Server the first time you run the Visual Studio solution on your computer.

    - The ASP.NET MVC Template creates a set of default components to give you a 
      headstart for your new MVC Architecture-based Web Application.

    - The UI is written entirely with RAZOR

