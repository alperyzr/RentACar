
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/26/2020 21:22:45
-- Generated from EDMX file: C:\Users\HC\source\repos\RentACar\Arackiralama\Arackiralama\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AracKiralama];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Car_CarPointScale1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Car] DROP CONSTRAINT [FK_Car_CarPointScale1];
GO
IF OBJECT_ID(N'[dbo].[FK_Car_Company]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Car] DROP CONSTRAINT [FK_Car_Company];
GO
IF OBJECT_ID(N'[dbo].[FK_Car_ExtraMaterial1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Car] DROP CONSTRAINT [FK_Car_ExtraMaterial1];
GO
IF OBJECT_ID(N'[dbo].[FK_CarLocation_Car]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarLocation] DROP CONSTRAINT [FK_CarLocation_Car];
GO
IF OBJECT_ID(N'[dbo].[FK_CarLocation_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarLocation] DROP CONSTRAINT [FK_CarLocation_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Cities_Countries_CountryID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cities] DROP CONSTRAINT [FK_Cities_Countries_CountryID];
GO
IF OBJECT_ID(N'[dbo].[FK_CityTranslations_Cities_CityID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CityTranslations] DROP CONSTRAINT [FK_CityTranslations_Cities_CityID];
GO
IF OBJECT_ID(N'[dbo].[FK_CityTranslations_Cultures_CultureID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CityTranslations] DROP CONSTRAINT [FK_CityTranslations_Cultures_CultureID];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactInfoTranslation_ContactInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactInfoTranslation] DROP CONSTRAINT [FK_ContactInfoTranslation_ContactInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactInfoTranslation_Cultures]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactInfoTranslation] DROP CONSTRAINT [FK_ContactInfoTranslation_Cultures];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactInfoTranslation_Language]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactInfoTranslation] DROP CONSTRAINT [FK_ContactInfoTranslation_Language];
GO
IF OBJECT_ID(N'[dbo].[FK_Contacts_Accounts_AccountID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contacts] DROP CONSTRAINT [FK_Contacts_Accounts_AccountID];
GO
IF OBJECT_ID(N'[dbo].[FK_CountryTranslations_Countries_CountryID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CountryTranslations] DROP CONSTRAINT [FK_CountryTranslations_Countries_CountryID];
GO
IF OBJECT_ID(N'[dbo].[FK_CountryTranslations_Cultures_CultureID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CountryTranslations] DROP CONSTRAINT [FK_CountryTranslations_Cultures_CultureID];
GO
IF OBJECT_ID(N'[dbo].[FK_Cultures_Currencies_CurrencyID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cultures] DROP CONSTRAINT [FK_Cultures_Currencies_CurrencyID];
GO
IF OBJECT_ID(N'[dbo].[FK_FAQTranslation_Cultures]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FAQTranslation] DROP CONSTRAINT [FK_FAQTranslation_Cultures];
GO
IF OBJECT_ID(N'[dbo].[FK_FAQTranslation_FAQ]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FAQTranslation] DROP CONSTRAINT [FK_FAQTranslation_FAQ];
GO
IF OBJECT_ID(N'[dbo].[FK_FAQTranslation_Language]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FAQTranslation] DROP CONSTRAINT [FK_FAQTranslation_Language];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderHistory_Car]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderHistory] DROP CONSTRAINT [FK_OrderHistory_Car];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderHistory_CarLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderHistory] DROP CONSTRAINT [FK_OrderHistory_CarLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderHistory_Company]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderHistory] DROP CONSTRAINT [FK_OrderHistory_Company];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderHistory_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderHistory] DROP CONSTRAINT [FK_OrderHistory_User];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderHistoryDetail_Car]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderHistoryDetail] DROP CONSTRAINT [FK_OrderHistoryDetail_Car];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderHistoryDetail_CarLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderHistoryDetail] DROP CONSTRAINT [FK_OrderHistoryDetail_CarLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderHistoryDetail_CarPointScale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderHistoryDetail] DROP CONSTRAINT [FK_OrderHistoryDetail_CarPointScale];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderHistoryDetail_Company]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderHistoryDetail] DROP CONSTRAINT [FK_OrderHistoryDetail_Company];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderHistoryDetail_User1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderHistoryDetail] DROP CONSTRAINT [FK_OrderHistoryDetail_User1];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_Contacts_ContactID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Contacts_ContactID];
GO
IF OBJECT_ID(N'[dbo].[FK_PrivacyPolicyTranslation_Cultures]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrivacyPolicyTranslation] DROP CONSTRAINT [FK_PrivacyPolicyTranslation_Cultures];
GO
IF OBJECT_ID(N'[dbo].[FK_PrivacyPolicyTranslation_Language]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrivacyPolicyTranslation] DROP CONSTRAINT [FK_PrivacyPolicyTranslation_Language];
GO
IF OBJECT_ID(N'[dbo].[FK_PrivacyPolicyTranslation_PrivacyPolicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrivacyPolicyTranslation] DROP CONSTRAINT [FK_PrivacyPolicyTranslation_PrivacyPolicy];
GO
IF OBJECT_ID(N'[dbo].[FK_Regions_Cities_CityID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Regions] DROP CONSTRAINT [FK_Regions_Cities_CityID];
GO
IF OBJECT_ID(N'[dbo].[FK_RegionTranslations_Cultures_CultureID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegionTranslations] DROP CONSTRAINT [FK_RegionTranslations_Cultures_CultureID];
GO
IF OBJECT_ID(N'[dbo].[FK_RegionTranslations_Regions_RegionID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegionTranslations] DROP CONSTRAINT [FK_RegionTranslations_Regions_RegionID];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Rol]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Rol];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleOrders_Currencies_CurrencyID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VehicleOrders] DROP CONSTRAINT [FK_VehicleOrders_Currencies_CurrencyID];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleOrders_Orders_OrderID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VehicleOrders] DROP CONSTRAINT [FK_VehicleOrders_Orders_OrderID];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleOtherPassengers_Orders_OrderID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VehicleOtherPassengers] DROP CONSTRAINT [FK_VehicleOtherPassengers_Orders_OrderID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Car]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Car];
GO
IF OBJECT_ID(N'[dbo].[CarLocation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarLocation];
GO
IF OBJECT_ID(N'[dbo].[CarPointScale]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarPointScale];
GO
IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[CityTranslations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CityTranslations];
GO
IF OBJECT_ID(N'[dbo].[Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company];
GO
IF OBJECT_ID(N'[dbo].[ContactInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactInfo];
GO
IF OBJECT_ID(N'[dbo].[ContactInfoTranslation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactInfoTranslation];
GO
IF OBJECT_ID(N'[dbo].[Contacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contacts];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO
IF OBJECT_ID(N'[dbo].[CountryTranslations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CountryTranslations];
GO
IF OBJECT_ID(N'[dbo].[Cultures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cultures];
GO
IF OBJECT_ID(N'[dbo].[Currencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Currencies];
GO
IF OBJECT_ID(N'[dbo].[ExtraMaterial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExtraMaterial];
GO
IF OBJECT_ID(N'[dbo].[FAQ]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FAQ];
GO
IF OBJECT_ID(N'[dbo].[FAQTranslation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FAQTranslation];
GO
IF OBJECT_ID(N'[dbo].[Language]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Language];
GO
IF OBJECT_ID(N'[dbo].[OrderHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderHistory];
GO
IF OBJECT_ID(N'[dbo].[OrderHistoryDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderHistoryDetail];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[PrivacyPolicy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrivacyPolicy];
GO
IF OBJECT_ID(N'[dbo].[PrivacyPolicyTranslation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrivacyPolicyTranslation];
GO
IF OBJECT_ID(N'[dbo].[Regions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Regions];
GO
IF OBJECT_ID(N'[dbo].[RegionTranslations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegionTranslations];
GO
IF OBJECT_ID(N'[dbo].[Rol]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rol];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserSearchLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSearchLogs];
GO
IF OBJECT_ID(N'[dbo].[VehicleOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleOrders];
GO
IF OBJECT_ID(N'[dbo].[VehicleOtherPassengers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleOtherPassengers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleID] int  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [HitAt] datetime  NULL,
    [CreatedAt] datetime  NULL,
    [GovermentNo] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NULL,
    [CellPhone] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL,
    [CompanyID] int  NULL,
    [PartnerID] int  NULL,
    [ZipCode] nvarchar(max)  NULL,
    [CityName] nvarchar(max)  NULL,
    [RegionName] nvarchar(max)  NULL,
    [FaxNumber] nvarchar(max)  NULL,
    [UniqueKey] nvarchar(max)  NULL,
    [Status] smallint  NOT NULL,
    [LastLoginDate] datetime  NULL,
    [AvatarResim] nvarchar(max)  NULL,
    [Gender] nvarchar(50)  NULL,
    [BirthDate] datetime  NULL,
    [IsActive] nvarchar(50)  NULL,
    [DateOfRegistration] datetime  NULL,
    [DateOfUpdate] datetime  NULL,
    [RecordPerson] nvarchar(50)  NULL,
    [UpdatedPerson] nvarchar(50)  NULL,
    [PasswordAgain] nvarchar(50)  NULL
);
GO

-- Creating table 'Car'
CREATE TABLE [dbo].[Car] (
    [ID] uniqueidentifier  NOT NULL,
    [CompanyID] int  NULL,
    [Marka] nvarchar(50)  NULL,
    [Model] nvarchar(50)  NULL,
    [Sinif] nvarchar(50)  NULL,
    [Segment] nvarchar(50)  NULL,
    [Resim] nvarchar(max)  NULL,
    [KisiSayisi] nvarchar(50)  NULL,
    [BagajKapasitesi] nvarchar(50)  NULL,
    [KapiSaysi] nvarchar(50)  NULL,
    [Sanzuman] nvarchar(50)  NULL,
    [YakitTuru] nvarchar(50)  NULL,
    [CarPoitScaleID] int  NULL,
    [CarExtraMaterialID] int  NULL,
    [KiralamaTutari] float  NULL,
    [EklendigiTarih] datetime  NULL,
    [EkleyenKisi] nvarchar(50)  NULL,
    [GuncellendigiTarih] datetime  NULL,
    [GuncelleyenKisi] nvarchar(50)  NULL,
    [IsActive] nvarchar(50)  NULL
);
GO

-- Creating table 'CarLocation'
CREATE TABLE [dbo].[CarLocation] (
    [ID] uniqueidentifier  NOT NULL,
    [CarID] uniqueidentifier  NULL,
    [MemberID] uniqueidentifier  NULL,
    [KiralandigiYer] nvarchar(max)  NULL,
    [KiralandigiTarih] datetime  NULL,
    [KiralandigiSaat] nvarchar(50)  NULL,
    [TeslimEdildigiYer] nvarchar(max)  NULL,
    [TeslimEdildigiTarih] datetime  NULL,
    [TeslimEdildigiSaat] nvarchar(50)  NULL,
    [KiralandigiTutar] int  NULL
);
GO

-- Creating table 'CarPointScale'
CREATE TABLE [dbo].[CarPointScale] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PuanAraligi] nvarchar(50)  NULL,
    [PuanIfadesi] nvarchar(50)  NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CountryID] int  NOT NULL,
    [Code] nvarchar(max)  NULL,
    [IsCapital] bit  NOT NULL,
    [Latitude] decimal(20,15)  NULL,
    [Longitude] decimal(20,15)  NULL,
    [RefID] int  NULL,
    [Distance] int  NOT NULL,
    [SearchRadius] int  NOT NULL
);
GO

-- Creating table 'CityTranslations'
CREATE TABLE [dbo].[CityTranslations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CityID] int  NOT NULL,
    [CultureID] int  NOT NULL,
    [Name] nvarchar(99)  NOT NULL,
    [Slug] nvarchar(99)  NOT NULL,
    [Information] nvarchar(333)  NULL,
    [MetaKeyWord] nvarchar(333)  NULL,
    [MetaDescription] nvarchar(333)  NULL,
    [Html] nvarchar(max)  NULL,
    [Title] nvarchar(99)  NULL
);
GO

-- Creating table 'Company'
CREATE TABLE [dbo].[Company] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Logo] nvarchar(max)  NULL,
    [SirketAdi] nvarchar(50)  NULL,
    [TicariUnvani] nvarchar(max)  NULL,
    [VergiDairesi] nvarchar(max)  NULL,
    [VergiNo] nvarchar(50)  NULL,
    [SirketTuru] nvarchar(50)  NULL,
    [SirketSahibi] nvarchar(50)  NULL,
    [EklendigiTarih] datetime  NULL,
    [EkleyenKisi] nvarchar(50)  NULL,
    [GuncellendigiTarih] datetime  NULL,
    [GuncelleyenKisi] nvarchar(50)  NULL,
    [IsActive] nvarchar(50)  NULL
);
GO

-- Creating table 'ContactInfo'
CREATE TABLE [dbo].[ContactInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CreatedAt] datetime  NULL,
    [CreatedBy] nvarchar(50)  NULL,
    [UpdatedAt] datetime  NULL,
    [UpdatedBy] nvarchar(50)  NULL,
    [IsActive] nvarchar(50)  NULL
);
GO

-- Creating table 'ContactInfoTranslation'
CREATE TABLE [dbo].[ContactInfoTranslation] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CultureID] int  NULL,
    [ContactInfoID] int  NULL,
    [Title] nvarchar(max)  NULL,
    [Explanation] nvarchar(max)  NULL,
    [IsActive] nvarchar(50)  NULL
);
GO

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AccountID] int  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NULL,
    [IsDomestic] bit  NOT NULL,
    [RefID] int  NULL
);
GO

-- Creating table 'CountryTranslations'
CREATE TABLE [dbo].[CountryTranslations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CountryID] int  NOT NULL,
    [CultureID] int  NOT NULL,
    [Name] nvarchar(99)  NOT NULL,
    [Slug] nvarchar(99)  NOT NULL
);
GO

-- Creating table 'Cultures'
CREATE TABLE [dbo].[Cultures] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [IsDefault] bit  NOT NULL,
    [CurrencyID] int  NULL,
    [Currency_ID] int  NULL
);
GO

-- Creating table 'Currencies'
CREATE TABLE [dbo].[Currencies] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(4)  NOT NULL,
    [Name] nvarchar(25)  NOT NULL,
    [IsDefault] bit  NOT NULL,
    [RefID] int  NULL
);
GO

-- Creating table 'ExtraMaterial'
CREATE TABLE [dbo].[ExtraMaterial] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Icon] nvarchar(max)  NULL,
    [Materyal] nvarchar(50)  NULL,
    [Aciklama] nvarchar(250)  NULL,
    [MinDeger] int  NULL,
    [MaxDeger] int  NULL,
    [EklendigiTarih] datetime  NULL,
    [EkleyenKisi] nvarchar(50)  NULL,
    [GuncellemeTarihi] datetime  NULL,
    [GuncelleyenKisi] nvarchar(50)  NULL,
    [IsActive] nvarchar(50)  NULL
);
GO

-- Creating table 'FAQ'
CREATE TABLE [dbo].[FAQ] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CreatedAt] datetime  NULL,
    [CreatedBy] nvarchar(50)  NULL,
    [UpdatedAt] datetime  NULL,
    [UpdatedBy] nvarchar(50)  NULL,
    [IsActive] nvarchar(50)  NULL
);
GO

-- Creating table 'FAQTranslation'
CREATE TABLE [dbo].[FAQTranslation] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CultureID] int  NULL,
    [FAQID] int  NULL,
    [Question] nvarchar(max)  NULL,
    [Answer] nvarchar(max)  NULL,
    [IsActiive] nvarchar(50)  NULL
);
GO

-- Creating table 'Language'
CREATE TABLE [dbo].[Language] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [LanguageTitle] nvarchar(max)  NULL,
    [IsActive] nvarchar(50)  NULL
);
GO

-- Creating table 'OrderHistory'
CREATE TABLE [dbo].[OrderHistory] (
    [ID] uniqueidentifier  NOT NULL,
    [UserID] uniqueidentifier  NULL,
    [CompanyID] int  NULL,
    [CarID] uniqueidentifier  NULL,
    [CarLocationID] uniqueidentifier  NULL
);
GO

-- Creating table 'OrderHistoryDetail'
CREATE TABLE [dbo].[OrderHistoryDetail] (
    [ID] uniqueidentifier  NOT NULL,
    [UserID] uniqueidentifier  NULL,
    [CompanyID] int  NULL,
    [CarID] uniqueidentifier  NULL,
    [CarPointScaleID] int  NULL,
    [CarLocationID] uniqueidentifier  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrderedAt] datetime  NOT NULL,
    [Identifier] uniqueidentifier  NOT NULL,
    [ContactID] int  NOT NULL,
    [Total] decimal(18,2)  NULL,
    [CommisionStatus] int  NOT NULL,
    [ReservationStatus] int  NOT NULL,
    [OrderType] nvarchar(max)  NULL
);
GO

-- Creating table 'PrivacyPolicy'
CREATE TABLE [dbo].[PrivacyPolicy] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CreatedAt] datetime  NULL,
    [CreatedBy] nvarchar(50)  NULL,
    [UpdatedAt] datetime  NULL,
    [UpdatedBy] nvarchar(50)  NULL,
    [IsActive] nvarchar(50)  NULL
);
GO

-- Creating table 'PrivacyPolicyTranslation'
CREATE TABLE [dbo].[PrivacyPolicyTranslation] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CultureID] int  NULL,
    [PrivacyPolicyID] int  NULL,
    [Title] nvarchar(max)  NULL,
    [Explanation] nvarchar(max)  NULL,
    [IsActive] nvarchar(50)  NULL
);
GO

-- Creating table 'Regions'
CREATE TABLE [dbo].[Regions] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CityID] int  NOT NULL,
    [Latitude] decimal(20,14)  NULL,
    [Longitude] decimal(20,15)  NULL,
    [Coordinate] nvarchar(max)  NULL,
    [IsCenter] bit  NOT NULL,
    [IsShow] int  NOT NULL,
    [SearchRating] int  NOT NULL,
    [Distance] int  NOT NULL,
    [SearchRadius] int  NOT NULL,
    [RefID] int  NOT NULL
);
GO

-- Creating table 'RegionTranslations'
CREATE TABLE [dbo].[RegionTranslations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RegionID] int  NOT NULL,
    [CultureID] int  NOT NULL,
    [Name] nvarchar(99)  NOT NULL,
    [Slug] nvarchar(99)  NOT NULL
);
GO

-- Creating table 'Rol'
CREATE TABLE [dbo].[Rol] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RolAciklama] nvarchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [ID] uniqueidentifier  NOT NULL,
    [AvatarResim] nvarchar(max)  NULL,
    [Ad] nvarchar(50)  NULL,
    [Soyad] nvarchar(50)  NULL,
    [Telefon] nvarchar(50)  NULL,
    [DogumTarihi] datetime  NULL,
    [Adres] nvarchar(max)  NULL,
    [EPosta] nvarchar(50)  NULL,
    [Sifre] nvarchar(max)  NULL,
    [SifreTekrar] nvarchar(max)  NULL,
    [Cinsiyet] nvarchar(50)  NULL,
    [SonGirisTarihi] datetime  NULL,
    [KayitTarihi] datetime  NULL,
    [KayıtEdenKisi] nvarchar(50)  NULL,
    [GuncellemeTarihi] datetime  NULL,
    [GuncelleyenKisi] nvarchar(50)  NULL,
    [RolID] int  NULL,
    [IsActive] nvarchar(50)  NULL
);
GO

-- Creating table 'UserSearchLogs'
CREATE TABLE [dbo].[UserSearchLogs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [LeaveCity] nvarchar(max)  NULL,
    [ReturnCity] nvarchar(max)  NULL,
    [InsertedDate] datetime  NOT NULL,
    [LogType] int  NOT NULL,
    [StartAt] datetime  NOT NULL,
    [EndAt] datetime  NULL
);
GO

-- Creating table 'VehicleOrders'
CREATE TABLE [dbo].[VehicleOrders] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [VehicleID] int  NOT NULL,
    [StartAt] datetime  NOT NULL,
    [EndAt] datetime  NOT NULL,
    [PaymentStatusID] int  NOT NULL,
    [PaymentIdentifier] nvarchar(max)  NULL,
    [TotalRate] decimal(18,2)  NOT NULL,
    [CurrencyID] int  NOT NULL,
    [OrderID] int  NOT NULL,
    [FlightNumber] nvarchar(max)  NULL,
    [StartTime] nvarchar(max)  NULL,
    [EndTime] nvarchar(max)  NULL,
    [VehicleExtraFee] nvarchar(max)  NULL,
    [CreditCardNumber] nvarchar(max)  NULL,
    [CreditCardNameandSurname] nvarchar(max)  NULL,
    [CreditCardType] nvarchar(max)  NULL,
    [CreditCardExpirationMonth] nvarchar(max)  NULL,
    [CreditCardExpirationYear] nvarchar(max)  NULL,
    [CreditCardSecurityCode] nvarchar(max)  NULL,
    [Identifier] nvarchar(max)  NULL,
    [StartOfficeName] nvarchar(max)  NOT NULL,
    [EndOfficeName] nvarchar(max)  NOT NULL,
    [OfficeAddress] nvarchar(max)  NULL,
    [OfficePhone] nvarchar(max)  NULL,
    [VehicleName] nvarchar(max)  NULL,
    [VehicleRefID] int  NOT NULL,
    [StartOfficeID] int  NOT NULL,
    [EndOfficeID] int  NOT NULL,
    [PaymentTypeID] int  NOT NULL,
    [ConfirmedID] nvarchar(max)  NULL,
    [EndOfficeAddress] nvarchar(max)  NULL,
    [EndOfficePhone] nvarchar(max)  NULL,
    [ThumImage] nvarchar(max)  NULL
);
GO

-- Creating table 'VehicleOtherPassengers'
CREATE TABLE [dbo].[VehicleOtherPassengers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrderID] int  NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL,
    [FlightNumber] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL
);
GO

-- Creating table 'sysdiagrams1Set'
CREATE TABLE [dbo].[sysdiagrams1Set] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [PK_Car]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CarLocation'
ALTER TABLE [dbo].[CarLocation]
ADD CONSTRAINT [PK_CarLocation]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CarPointScale'
ALTER TABLE [dbo].[CarPointScale]
ADD CONSTRAINT [PK_CarPointScale]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CityTranslations'
ALTER TABLE [dbo].[CityTranslations]
ADD CONSTRAINT [PK_CityTranslations]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [PK_Company]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ContactInfo'
ALTER TABLE [dbo].[ContactInfo]
ADD CONSTRAINT [PK_ContactInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ContactInfoTranslation'
ALTER TABLE [dbo].[ContactInfoTranslation]
ADD CONSTRAINT [PK_ContactInfoTranslation]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CountryTranslations'
ALTER TABLE [dbo].[CountryTranslations]
ADD CONSTRAINT [PK_CountryTranslations]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Cultures'
ALTER TABLE [dbo].[Cultures]
ADD CONSTRAINT [PK_Cultures]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Currencies'
ALTER TABLE [dbo].[Currencies]
ADD CONSTRAINT [PK_Currencies]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ExtraMaterial'
ALTER TABLE [dbo].[ExtraMaterial]
ADD CONSTRAINT [PK_ExtraMaterial]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FAQ'
ALTER TABLE [dbo].[FAQ]
ADD CONSTRAINT [PK_FAQ]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FAQTranslation'
ALTER TABLE [dbo].[FAQTranslation]
ADD CONSTRAINT [PK_FAQTranslation]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Language'
ALTER TABLE [dbo].[Language]
ADD CONSTRAINT [PK_Language]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrderHistory'
ALTER TABLE [dbo].[OrderHistory]
ADD CONSTRAINT [PK_OrderHistory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrderHistoryDetail'
ALTER TABLE [dbo].[OrderHistoryDetail]
ADD CONSTRAINT [PK_OrderHistoryDetail]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PrivacyPolicy'
ALTER TABLE [dbo].[PrivacyPolicy]
ADD CONSTRAINT [PK_PrivacyPolicy]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PrivacyPolicyTranslation'
ALTER TABLE [dbo].[PrivacyPolicyTranslation]
ADD CONSTRAINT [PK_PrivacyPolicyTranslation]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Regions'
ALTER TABLE [dbo].[Regions]
ADD CONSTRAINT [PK_Regions]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RegionTranslations'
ALTER TABLE [dbo].[RegionTranslations]
ADD CONSTRAINT [PK_RegionTranslations]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Rol'
ALTER TABLE [dbo].[Rol]
ADD CONSTRAINT [PK_Rol]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserSearchLogs'
ALTER TABLE [dbo].[UserSearchLogs]
ADD CONSTRAINT [PK_UserSearchLogs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'VehicleOrders'
ALTER TABLE [dbo].[VehicleOrders]
ADD CONSTRAINT [PK_VehicleOrders]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'VehicleOtherPassengers'
ALTER TABLE [dbo].[VehicleOtherPassengers]
ADD CONSTRAINT [PK_VehicleOtherPassengers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams1Set'
ALTER TABLE [dbo].[sysdiagrams1Set]
ADD CONSTRAINT [PK_sysdiagrams1Set]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountID] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [FK_Contacts_Accounts_AccountID]
    FOREIGN KEY ([AccountID])
    REFERENCES [dbo].[Accounts]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Contacts_Accounts_AccountID'
CREATE INDEX [IX_FK_Contacts_Accounts_AccountID]
ON [dbo].[Contacts]
    ([AccountID]);
GO

-- Creating foreign key on [CarPoitScaleID] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [FK_Car_CarPointScale1]
    FOREIGN KEY ([CarPoitScaleID])
    REFERENCES [dbo].[CarPointScale]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Car_CarPointScale1'
CREATE INDEX [IX_FK_Car_CarPointScale1]
ON [dbo].[Car]
    ([CarPoitScaleID]);
GO

-- Creating foreign key on [CompanyID] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [FK_Car_Company]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[Company]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Car_Company'
CREATE INDEX [IX_FK_Car_Company]
ON [dbo].[Car]
    ([CompanyID]);
GO

-- Creating foreign key on [CarExtraMaterialID] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [FK_Car_ExtraMaterial1]
    FOREIGN KEY ([CarExtraMaterialID])
    REFERENCES [dbo].[ExtraMaterial]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Car_ExtraMaterial1'
CREATE INDEX [IX_FK_Car_ExtraMaterial1]
ON [dbo].[Car]
    ([CarExtraMaterialID]);
GO

-- Creating foreign key on [CarID] in table 'CarLocation'
ALTER TABLE [dbo].[CarLocation]
ADD CONSTRAINT [FK_CarLocation_Car]
    FOREIGN KEY ([CarID])
    REFERENCES [dbo].[Car]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarLocation_Car'
CREATE INDEX [IX_FK_CarLocation_Car]
ON [dbo].[CarLocation]
    ([CarID]);
GO

-- Creating foreign key on [CarID] in table 'OrderHistory'
ALTER TABLE [dbo].[OrderHistory]
ADD CONSTRAINT [FK_OrderHistory_Car]
    FOREIGN KEY ([CarID])
    REFERENCES [dbo].[Car]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderHistory_Car'
CREATE INDEX [IX_FK_OrderHistory_Car]
ON [dbo].[OrderHistory]
    ([CarID]);
GO

-- Creating foreign key on [CarID] in table 'OrderHistoryDetail'
ALTER TABLE [dbo].[OrderHistoryDetail]
ADD CONSTRAINT [FK_OrderHistoryDetail_Car]
    FOREIGN KEY ([CarID])
    REFERENCES [dbo].[Car]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderHistoryDetail_Car'
CREATE INDEX [IX_FK_OrderHistoryDetail_Car]
ON [dbo].[OrderHistoryDetail]
    ([CarID]);
GO

-- Creating foreign key on [MemberID] in table 'CarLocation'
ALTER TABLE [dbo].[CarLocation]
ADD CONSTRAINT [FK_CarLocation_User]
    FOREIGN KEY ([MemberID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarLocation_User'
CREATE INDEX [IX_FK_CarLocation_User]
ON [dbo].[CarLocation]
    ([MemberID]);
GO

-- Creating foreign key on [CarLocationID] in table 'OrderHistory'
ALTER TABLE [dbo].[OrderHistory]
ADD CONSTRAINT [FK_OrderHistory_CarLocation]
    FOREIGN KEY ([CarLocationID])
    REFERENCES [dbo].[CarLocation]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderHistory_CarLocation'
CREATE INDEX [IX_FK_OrderHistory_CarLocation]
ON [dbo].[OrderHistory]
    ([CarLocationID]);
GO

-- Creating foreign key on [CarLocationID] in table 'OrderHistoryDetail'
ALTER TABLE [dbo].[OrderHistoryDetail]
ADD CONSTRAINT [FK_OrderHistoryDetail_CarLocation]
    FOREIGN KEY ([CarLocationID])
    REFERENCES [dbo].[CarLocation]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderHistoryDetail_CarLocation'
CREATE INDEX [IX_FK_OrderHistoryDetail_CarLocation]
ON [dbo].[OrderHistoryDetail]
    ([CarLocationID]);
GO

-- Creating foreign key on [CarPointScaleID] in table 'OrderHistoryDetail'
ALTER TABLE [dbo].[OrderHistoryDetail]
ADD CONSTRAINT [FK_OrderHistoryDetail_CarPointScale]
    FOREIGN KEY ([CarPointScaleID])
    REFERENCES [dbo].[CarPointScale]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderHistoryDetail_CarPointScale'
CREATE INDEX [IX_FK_OrderHistoryDetail_CarPointScale]
ON [dbo].[OrderHistoryDetail]
    ([CarPointScaleID]);
GO

-- Creating foreign key on [CountryID] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK_Cities_Countries_CountryID]
    FOREIGN KEY ([CountryID])
    REFERENCES [dbo].[Countries]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cities_Countries_CountryID'
CREATE INDEX [IX_FK_Cities_Countries_CountryID]
ON [dbo].[Cities]
    ([CountryID]);
GO

-- Creating foreign key on [CityID] in table 'CityTranslations'
ALTER TABLE [dbo].[CityTranslations]
ADD CONSTRAINT [FK_CityTranslations_Cities_CityID]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[Cities]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityTranslations_Cities_CityID'
CREATE INDEX [IX_FK_CityTranslations_Cities_CityID]
ON [dbo].[CityTranslations]
    ([CityID]);
GO

-- Creating foreign key on [CityID] in table 'Regions'
ALTER TABLE [dbo].[Regions]
ADD CONSTRAINT [FK_Regions_Cities_CityID]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[Cities]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Regions_Cities_CityID'
CREATE INDEX [IX_FK_Regions_Cities_CityID]
ON [dbo].[Regions]
    ([CityID]);
GO

-- Creating foreign key on [CultureID] in table 'CityTranslations'
ALTER TABLE [dbo].[CityTranslations]
ADD CONSTRAINT [FK_CityTranslations_Cultures_CultureID]
    FOREIGN KEY ([CultureID])
    REFERENCES [dbo].[Cultures]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityTranslations_Cultures_CultureID'
CREATE INDEX [IX_FK_CityTranslations_Cultures_CultureID]
ON [dbo].[CityTranslations]
    ([CultureID]);
GO

-- Creating foreign key on [CompanyID] in table 'OrderHistory'
ALTER TABLE [dbo].[OrderHistory]
ADD CONSTRAINT [FK_OrderHistory_Company]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[Company]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderHistory_Company'
CREATE INDEX [IX_FK_OrderHistory_Company]
ON [dbo].[OrderHistory]
    ([CompanyID]);
GO

-- Creating foreign key on [CompanyID] in table 'OrderHistoryDetail'
ALTER TABLE [dbo].[OrderHistoryDetail]
ADD CONSTRAINT [FK_OrderHistoryDetail_Company]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[Company]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderHistoryDetail_Company'
CREATE INDEX [IX_FK_OrderHistoryDetail_Company]
ON [dbo].[OrderHistoryDetail]
    ([CompanyID]);
GO

-- Creating foreign key on [ContactInfoID] in table 'ContactInfoTranslation'
ALTER TABLE [dbo].[ContactInfoTranslation]
ADD CONSTRAINT [FK_ContactInfoTranslation_ContactInfo]
    FOREIGN KEY ([ContactInfoID])
    REFERENCES [dbo].[ContactInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactInfoTranslation_ContactInfo'
CREATE INDEX [IX_FK_ContactInfoTranslation_ContactInfo]
ON [dbo].[ContactInfoTranslation]
    ([ContactInfoID]);
GO

-- Creating foreign key on [CultureID] in table 'ContactInfoTranslation'
ALTER TABLE [dbo].[ContactInfoTranslation]
ADD CONSTRAINT [FK_ContactInfoTranslation_Cultures]
    FOREIGN KEY ([CultureID])
    REFERENCES [dbo].[Cultures]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactInfoTranslation_Cultures'
CREATE INDEX [IX_FK_ContactInfoTranslation_Cultures]
ON [dbo].[ContactInfoTranslation]
    ([CultureID]);
GO

-- Creating foreign key on [CultureID] in table 'ContactInfoTranslation'
ALTER TABLE [dbo].[ContactInfoTranslation]
ADD CONSTRAINT [FK_ContactInfoTranslation_Language]
    FOREIGN KEY ([CultureID])
    REFERENCES [dbo].[Language]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactInfoTranslation_Language'
CREATE INDEX [IX_FK_ContactInfoTranslation_Language]
ON [dbo].[ContactInfoTranslation]
    ([CultureID]);
GO

-- Creating foreign key on [ContactID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Contacts_ContactID]
    FOREIGN KEY ([ContactID])
    REFERENCES [dbo].[Contacts]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Contacts_ContactID'
CREATE INDEX [IX_FK_Orders_Contacts_ContactID]
ON [dbo].[Orders]
    ([ContactID]);
GO

-- Creating foreign key on [CountryID] in table 'CountryTranslations'
ALTER TABLE [dbo].[CountryTranslations]
ADD CONSTRAINT [FK_CountryTranslations_Countries_CountryID]
    FOREIGN KEY ([CountryID])
    REFERENCES [dbo].[Countries]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryTranslations_Countries_CountryID'
CREATE INDEX [IX_FK_CountryTranslations_Countries_CountryID]
ON [dbo].[CountryTranslations]
    ([CountryID]);
GO

-- Creating foreign key on [CultureID] in table 'CountryTranslations'
ALTER TABLE [dbo].[CountryTranslations]
ADD CONSTRAINT [FK_CountryTranslations_Cultures_CultureID]
    FOREIGN KEY ([CultureID])
    REFERENCES [dbo].[Cultures]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryTranslations_Cultures_CultureID'
CREATE INDEX [IX_FK_CountryTranslations_Cultures_CultureID]
ON [dbo].[CountryTranslations]
    ([CultureID]);
GO

-- Creating foreign key on [CurrencyID] in table 'Cultures'
ALTER TABLE [dbo].[Cultures]
ADD CONSTRAINT [FK_Cultures_Currencies_CurrencyID]
    FOREIGN KEY ([CurrencyID])
    REFERENCES [dbo].[Currencies]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cultures_Currencies_CurrencyID'
CREATE INDEX [IX_FK_Cultures_Currencies_CurrencyID]
ON [dbo].[Cultures]
    ([CurrencyID]);
GO

-- Creating foreign key on [CultureID] in table 'FAQTranslation'
ALTER TABLE [dbo].[FAQTranslation]
ADD CONSTRAINT [FK_FAQTranslation_Cultures]
    FOREIGN KEY ([CultureID])
    REFERENCES [dbo].[Cultures]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FAQTranslation_Cultures'
CREATE INDEX [IX_FK_FAQTranslation_Cultures]
ON [dbo].[FAQTranslation]
    ([CultureID]);
GO

-- Creating foreign key on [CultureID] in table 'PrivacyPolicyTranslation'
ALTER TABLE [dbo].[PrivacyPolicyTranslation]
ADD CONSTRAINT [FK_PrivacyPolicyTranslation_Cultures]
    FOREIGN KEY ([CultureID])
    REFERENCES [dbo].[Cultures]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrivacyPolicyTranslation_Cultures'
CREATE INDEX [IX_FK_PrivacyPolicyTranslation_Cultures]
ON [dbo].[PrivacyPolicyTranslation]
    ([CultureID]);
GO

-- Creating foreign key on [CultureID] in table 'RegionTranslations'
ALTER TABLE [dbo].[RegionTranslations]
ADD CONSTRAINT [FK_RegionTranslations_Cultures_CultureID]
    FOREIGN KEY ([CultureID])
    REFERENCES [dbo].[Cultures]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionTranslations_Cultures_CultureID'
CREATE INDEX [IX_FK_RegionTranslations_Cultures_CultureID]
ON [dbo].[RegionTranslations]
    ([CultureID]);
GO

-- Creating foreign key on [CurrencyID] in table 'VehicleOrders'
ALTER TABLE [dbo].[VehicleOrders]
ADD CONSTRAINT [FK_VehicleOrders_Currencies_CurrencyID]
    FOREIGN KEY ([CurrencyID])
    REFERENCES [dbo].[Currencies]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleOrders_Currencies_CurrencyID'
CREATE INDEX [IX_FK_VehicleOrders_Currencies_CurrencyID]
ON [dbo].[VehicleOrders]
    ([CurrencyID]);
GO

-- Creating foreign key on [FAQID] in table 'FAQTranslation'
ALTER TABLE [dbo].[FAQTranslation]
ADD CONSTRAINT [FK_FAQTranslation_FAQ]
    FOREIGN KEY ([FAQID])
    REFERENCES [dbo].[FAQ]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FAQTranslation_FAQ'
CREATE INDEX [IX_FK_FAQTranslation_FAQ]
ON [dbo].[FAQTranslation]
    ([FAQID]);
GO

-- Creating foreign key on [CultureID] in table 'FAQTranslation'
ALTER TABLE [dbo].[FAQTranslation]
ADD CONSTRAINT [FK_FAQTranslation_Language]
    FOREIGN KEY ([CultureID])
    REFERENCES [dbo].[Language]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FAQTranslation_Language'
CREATE INDEX [IX_FK_FAQTranslation_Language]
ON [dbo].[FAQTranslation]
    ([CultureID]);
GO

-- Creating foreign key on [CultureID] in table 'PrivacyPolicyTranslation'
ALTER TABLE [dbo].[PrivacyPolicyTranslation]
ADD CONSTRAINT [FK_PrivacyPolicyTranslation_Language]
    FOREIGN KEY ([CultureID])
    REFERENCES [dbo].[Language]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrivacyPolicyTranslation_Language'
CREATE INDEX [IX_FK_PrivacyPolicyTranslation_Language]
ON [dbo].[PrivacyPolicyTranslation]
    ([CultureID]);
GO

-- Creating foreign key on [UserID] in table 'OrderHistory'
ALTER TABLE [dbo].[OrderHistory]
ADD CONSTRAINT [FK_OrderHistory_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderHistory_User'
CREATE INDEX [IX_FK_OrderHistory_User]
ON [dbo].[OrderHistory]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'OrderHistoryDetail'
ALTER TABLE [dbo].[OrderHistoryDetail]
ADD CONSTRAINT [FK_OrderHistoryDetail_User1]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderHistoryDetail_User1'
CREATE INDEX [IX_FK_OrderHistoryDetail_User1]
ON [dbo].[OrderHistoryDetail]
    ([UserID]);
GO

-- Creating foreign key on [OrderID] in table 'VehicleOrders'
ALTER TABLE [dbo].[VehicleOrders]
ADD CONSTRAINT [FK_VehicleOrders_Orders_OrderID]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Orders]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleOrders_Orders_OrderID'
CREATE INDEX [IX_FK_VehicleOrders_Orders_OrderID]
ON [dbo].[VehicleOrders]
    ([OrderID]);
GO

-- Creating foreign key on [OrderID] in table 'VehicleOtherPassengers'
ALTER TABLE [dbo].[VehicleOtherPassengers]
ADD CONSTRAINT [FK_VehicleOtherPassengers_Orders_OrderID]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Orders]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleOtherPassengers_Orders_OrderID'
CREATE INDEX [IX_FK_VehicleOtherPassengers_Orders_OrderID]
ON [dbo].[VehicleOtherPassengers]
    ([OrderID]);
GO

-- Creating foreign key on [PrivacyPolicyID] in table 'PrivacyPolicyTranslation'
ALTER TABLE [dbo].[PrivacyPolicyTranslation]
ADD CONSTRAINT [FK_PrivacyPolicyTranslation_PrivacyPolicy]
    FOREIGN KEY ([PrivacyPolicyID])
    REFERENCES [dbo].[PrivacyPolicy]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrivacyPolicyTranslation_PrivacyPolicy'
CREATE INDEX [IX_FK_PrivacyPolicyTranslation_PrivacyPolicy]
ON [dbo].[PrivacyPolicyTranslation]
    ([PrivacyPolicyID]);
GO

-- Creating foreign key on [RegionID] in table 'RegionTranslations'
ALTER TABLE [dbo].[RegionTranslations]
ADD CONSTRAINT [FK_RegionTranslations_Regions_RegionID]
    FOREIGN KEY ([RegionID])
    REFERENCES [dbo].[Regions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionTranslations_Regions_RegionID'
CREATE INDEX [IX_FK_RegionTranslations_Regions_RegionID]
ON [dbo].[RegionTranslations]
    ([RegionID]);
GO

-- Creating foreign key on [RolID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Rol]
    FOREIGN KEY ([RolID])
    REFERENCES [dbo].[Rol]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Rol'
CREATE INDEX [IX_FK_User_Rol]
ON [dbo].[User]
    ([RolID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------