# NutzShop

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

GIT: 004.ProductManagementPages

CONTROLLERS

MyShop.WebUI

ProductManager
1.	Controllers -> Add Controllers -> MVC 5 Controller – Empty -> ProductManagerController
2.	Reference -> Add -> All - Except Test
3.	using MyShop.Core.Models
4.	using MyShop.DataAccess.InMemory;
5.	Index -> Add view -> Template = List -> Model class = Product (MyShop.Core.Models)
6.	Index.cshtml -> @Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }) |
7.	Create -> ActionResult -> Add view -> Template = Create -> Model class = Product (MyShop.Core.Models)
8.	Edit -> ActionResult -> Add view -> Template = Edit -> Model class = Product (MyShop.Core.Models)
9.	Delete -> Add view -> Template = Delete -> Model class = Product (MyShop.Core.Models)
10.	Shared -> _Layout.csHtml -> Add -> <li>@Html.ActionLink("Product Admin", "Index", "ProductManager")</li>
11.	Solution ‘NutzShop’ -> Manage NuGet Packages -> Downgrade Microsoft.CodeDom.Providers.DotNetCompilerPlatform -> 2.0.1

GIT: 005.ProductGrouping

ProductCategoryManager
1.	MyShop.Core -> Models -> Add new class -> ProductCategory
2.	Controllers -> Add Controllers -> MVC 5 Controller – Empty -> ProductCategoryManagerController

MyShop.DataAccess.InMemory
1.	Add new class -> ProductCategoryRepository

ProductCategoryManagerController

3.	Index -> Add view -> Template = List -> Model class = ProductCategory (MyShop.Core.Models)
4.	Index.cshtml -> @Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }) |
5.	Create -> Add view -> Template = Create -> Model class = ProductCategory (MyShop.Core.Models)
6.	Edit -> Add view -> Template = Edit -> Model class = ProductCategory (MyShop.Core.Models)
7.	Delete -> Add view -> Template = Delete -> Model class = ProductCategory (MyShop.Core.Models)
8.	_Layout.csHtml -> Add -> <li>@Html.ActionLink("Category Admin", "Index", "ProductCategoryManager")</li>

ViewModels
1.	MyShop.Core -> Add new dir -> ViewModels
2.	MyShop.Core -> ViewModels -> Add new class -> ProductManagerViewModel
3.	Edit -> WebUI -> Controller -> ProductManagerController -> Create & Edit
4.	WebUI -> Views -> ProductManager -> Edit -> Create.cshtml -> MyShop.Core.ViewModels.ProductManagerViewModel
5.	WebUI -> Views -> ProductManager -> Edit -> Edit.cshtml -> MyShop.Core.ViewModels.ProductManagerViewModel
