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

GIT: 006.Generics

GENERICS

MyShop.DataAccess.InMemory
1.	Add new class -> InMemoryRepository

MyShop.Core
1.	Models -> Add new class -> BaseEntity
2.	public abstract class BaseEntity

MyShop.WebUI
1.	Edit -> Controllers -> ProductManagerController
2.	Edit -> Controllers -> ProductCategoryManagerController

MyShop.Core
1.	Edit -> Models -> Product.cs
2.	public class Product : BaseEntity 
3.	Edit -> Models -> ProductCategory.cs
4.	public class ProductCategory : BaseEntity 

GIT: 007.DependencyInjection

DEPENDENCY INJECTION

MyShop.DataAccess.InMemory
1.	Edit -> InMemoryRepository.cs
2.	Public class InMemoryRepository -> Extract Interface
3.	IInMemoryRepository -> rename -> IRepository.cs
4.	IRepository.cs  -> rename -> class -> IRepository
5.	InMemoryRepository -> rename -> class -> IRepository

MyShop.Core
1.	Add dir -> Contracts
2.	Drag&drop -> MyShop.DataAccess.InMemory -> IRepository.cs -> + delete
3.	Edit -> IRepository.cs -> namespace MyShop.Core.Contracts
4.	MyShop.DataAccess.InMemory -> InMemoryRepository -> Quick -> IRepository

MyShop.WebUI

5.	Edit -> Controllers ->  ProductManagerController.cs -> IRepository
6.	Edit -> Controllers ->  ProductManagerController.cs -> public ProductManagerController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
7.	Constructors -> context = productContext;
8.	Constructors -> productCategories = productCategoryContext;
9.	Edit -> ProductCategoryManagerController.cs -> Constructors

GIT: 009.EntityFramework

ENTITY

Solution ‘MyShop’
1.	Manage NuGet Packages -> EntityFramework -> MyShop.DataAccess.SQL -> install

MyShop.WebUI
1.	Edit -> Web.config -> name="DefaultConnection"

MyShop.DataAccess.SQL
1.	Add new class -> DataContext.cs
2.	Copy MyShop.WebUI:Web.config -> <connectionString> TO MyShop.DataAccess.SQL:App.config BEFORE <configSections>
3.	Edit -> DataContext.cs  -> Add references ->  using NutzShop.Core
4.	--
5.	Visual studio -> View -> Other windows -> Package manager console
6.	Default project: NutzShop.DataAccess.SQL
7.	MyShop.WebUI -> Set as startup project
8.	Enable-Migrations
9.	Add-Migration Initial
10.	Update-Database

Microsoft SQL Sever Management Studio
1.	NutzShop -> Tables -> __MigrationHistory -> edit

GIT: 010.SQLRepository

SQLRepository

MyShop.DataAccess.SQL
1.	Add new class -> SQLRepository.cs
2.	IRepository -> Implement interface

MyShop.WebUI
1.	Edit -> App_Start -> Unity.config -> change InMemoryRepository -> SQLRepository

GIT: 011.UploadingImages

UploadingImages

MyShop.WebUI
1.	Edit -> Views -> ProductManger -> Create.cshtml -> Images
2.	Edit -> Views -> ProductManger -> Create.cshtml -> @using (Html.BeginForm("Create", "ProductManager", FormMethod.Post, new { encType = "multipart/form-data" }))
3.	Edit -> Views -> ProductManger -> Edit.cshtml -> the same
4.	Mkdir ProductImages -> Content
5.	Edit -> Views -> ProductManger -> Edit.cshtml -> Product
6.	Edit -> Controllers -> ProductMangerControlle -> HttpPost -> Create
7.	Edit -> Controllers -> ProductMangerControlle -> HttpPost -> Edit
8.	Edit -> Views -> Index.cshtml -> table & Model -> & delete -> <td>@Html.DisplayFor(modelItem => item.Image)</td> 

GIT: 012.ProductListing

ProductListing

MyShop.WebUI
1.	Edit -> Controllers -> ProductMangerController -> copy //var & //construtors -> HomeController
2.	Edit -> Controllers -> HomeController
3.	Edit -> Views -> Home -> Index.cshtml
4.	Add View -> Details -> Model class = Product (MyShop.Core.Models)
5.	Edit -> Views -> Home -> Details.cshtml

MyShop.WebUI.Tests
1.	Edit -> Controllers -> HomerControllerTest -> Index -> Comment out
2.	Edit -> Controllers -> HomerControllerTest -> About & Contact -> Delete

GIT: 013.ProductFilter

ProductFilter

MyShop.Core
1.	Add new class -> ViewModels -> ProductListViewModel

MyShop.WebUI
1.	Edit -> Controllers -> HomeController -> Index
2.	Edit -> Views -> Home -> Index.cshtml

GIT: 014.BasketModel

BasketModel

MyShop.Core
1.	Add new class -> Model -> Basket.cs
2.	Add new class -> Model -> BasketItem.cs


MyShop.DataAccess.SQL
1.	Edit -> DataContext.cs
2.	MyShop.WebUI -> Set as startup project
3.	Visual studio -> View -> Other windows -> Package manager console
4.	Default project: NutzShop.DataAccess.SQL
5.	Add-Migration AddBasket
6.	Update-Database
7.	SQL Sever Management Studio -> Databases -> Tables -> Edit

GIT: 015.BasketService

BasketService

NutzShop.Services
1.	Reference -> Add -> NutzShop.Core
2.	Add new class -> Model -> BasketService.cs
3.	Reference -> Add -> Assemblies -> System.Web

NutzShop.Core
1.	MyShop.Core -> ViewModels -> Add new class -> BasketItemViewModel.cs

NutzShop.Services
1.	Edit -> BasketService.cs

NutzShop.Core
1.	MyShop.Core -> ViewModels -> Add new class -> BasketSummaryViewModel.cs

NutzShop.Services
1.	Edit -> BasketService.cs

NutzShop.Core
1.	Contract -> Add new class -> Interface -> IBasket.Service.cs

NutzShop.Services
1.	Edit -> BasketService.cs -> Extracts Interface

GIT: 016.BasketUI

BasketUI

NutzShop.WebUI
1.	Edit -> App_Start -> UnityConfig.cs
2.	Controllers -> Add Controllers -> MVC 5 Controller – Empty -> BasketController
3.	Edit -> Controllers -> BasketController.cs
4.	Index -> Add view -> Template = List -> Model class = BasketItemViewModel (NutzShop.Core.ViewModels)
5.	Edit -> Views -> Basket -> Index.cshtml
6.	View -> Basket -> Add view -> View name -> BasketSummary -> Empty -> Create as a partial view
7.	Edit -> Views -> Basket -> BasketSummary.cshtml
8.	Edit -> Views -> Home -> Index.cshtml
9.	Edit -> Views -> Home -> Details.cshtml
10.	Edit -> Views -> Shared -> _Layout.cshtml

GIT: 017.BasketTests

BasketTests

NutzShop.WebUI.Tests

Creating Mocks
1.	Edit -> Controllers -> HomeControllerTest.cs
2.	Add -> New floder -> Mocks
3.	Mocks -> Add new class -> MockContext.cs
3.	Edit -> MockContext.cs
4.	Reference -> Add -> All
5.	Copy -> NutzShop.DataAccess.InMemory -> InMemoryRepository.cs -> to MockContext.cs
6.	Edit -> MockContext.cs
7.	Edit -> HomeControllerTest.cs
8.	Visual Studio -> Test -> Test Explorer
9.	Mocks -> Add new class -> MockHttpContext.cs
10.	Edit -> MockHttpContext.cs
11.	Add -> Controllers -> Unit Test -> BasketControllerTests.cs
12.	Edit -> BasketControllerTests.cs

Basket tests

13.	Edit -> Controllers -> BasketControllerTest.cs

GIT: 018.CustomerModels

CustomerModels

NutzShop.Core
1.	Add new class -> Model -> Customer.cs
2.	Edit -> Customer.cs

MyShop.DataAccess.SQL
1.	Edit -> DataContext.cs
2.	--
3.	Visual studio -> View -> Other windows -> Package manager console
4.	Default project: NutzShop.DataAccess.SQL
5.	Add-Migration AddCustomers
6.	Update-Database

NutzShop.WebUI
1.	Edit -> Models -> AccountViewModels.cs -> RegisterViewModel
2.	Edit -> Controllers -> AccountController.cs -> Register(RegisterViewModel) & Authorize
3.	Edit -> View -> Account -> Register.cshtml
4.	Update -> Controllers -> AccountController.cs -> Authorize
5.	Update -> App_Strat -> Unity.Config.cs
6.	Remove -> Constructors -> AccountController & ManageController
