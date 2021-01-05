# NutzShop

GIT: Change -> Master
GIT: Git Repository -> Master -> Merge

GIT: 001.InitalSetup

SETUP
Setup
1.	CORE
•	Project -> Empty Project (.NET Framework) -> Blank
•	Extensions -> GitHub -> Git Changes
•	Add -> New Protjet -> Class Library (.NET Framework) -> MyShop.Core

2.	SERVICES
•	Class Library (.NET Framework) -> MyShop.Services

3.	DATAACCESS.SQL
•	Class Library (.NET Framework) -> MyShop.DataAccess.SQL

4.	DATAACCESS.INMERORY
•	Class Library (.NET Framework) -> MyShop.DataAccess.InMerory

5.	DATAACCESS.WEBUI
•	ASP.NET Web Application (.NET Framework) -> MyShop.WebUI
•	MVC -> Also create a project for unit tests 
•	MVC -> Authentication -> Individual User Accounts

GIT: 002.BaseProject

Nuget
6.	Solution ‘NutzShop’ -> Manage NuGet Packages -> Updates
7.	Except Bootstrap

GIT: 003.ModelsAndStorage

MODELS
MyShop.Core
1.	Add new folder -> Models
2.	Add new class -> Product 
3.	using System.ComponentModel;
4.	using System.ComponentModel.DataAnnotations;

INMEMORY
MyShop.DataAccess.InMemory
1.	Reference -> Add -> Assemblies -> System.Runtime.Caching
2.	Projects -> Solution -> Add -> MyShop.Core
3.	Add new class -> ProductRepository
4.	using System.Runtime.Caching;
5.	using MyShop.Core.Models;
