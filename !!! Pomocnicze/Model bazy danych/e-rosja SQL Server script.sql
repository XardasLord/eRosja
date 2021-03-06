USE [master]
GO
/****** Object:  Database [e-rosja]    Script Date: 01/18/2015 22:59:44 ******/
CREATE DATABASE [e-rosja] ON  PRIMARY 
( NAME = N'e-rosja', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\e-rosja.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'e-rosja_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\e-rosja_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [e-rosja] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [e-rosja].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [e-rosja] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [e-rosja] SET ANSI_NULLS OFF
GO
ALTER DATABASE [e-rosja] SET ANSI_PADDING OFF
GO
ALTER DATABASE [e-rosja] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [e-rosja] SET ARITHABORT OFF
GO
ALTER DATABASE [e-rosja] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [e-rosja] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [e-rosja] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [e-rosja] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [e-rosja] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [e-rosja] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [e-rosja] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [e-rosja] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [e-rosja] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [e-rosja] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [e-rosja] SET  DISABLE_BROKER
GO
ALTER DATABASE [e-rosja] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [e-rosja] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [e-rosja] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [e-rosja] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [e-rosja] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [e-rosja] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [e-rosja] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [e-rosja] SET  READ_WRITE
GO
ALTER DATABASE [e-rosja] SET RECOVERY SIMPLE
GO
ALTER DATABASE [e-rosja] SET  MULTI_USER
GO
ALTER DATABASE [e-rosja] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [e-rosja] SET DB_CHAINING OFF
GO
USE [e-rosja]
GO
/****** Object:  Table [dbo].[waluty]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[waluty](
	[id_waluty] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_waluty] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[uzytkownicy]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[uzytkownicy](
	[id_uzytkownicy] [int] IDENTITY(1,1) NOT NULL,
	[login] [varchar](50) NOT NULL,
	[haslo] [varchar](40) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[zarejestrowano] [datetime] NOT NULL,
	[ostatnie_logowanie] [datetime] NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_uzytkownicy] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[przejscia]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[przejscia](
	[id_przejscia] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_przejscia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[alkohole]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[alkohole](
	[id_alkohole] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_alkohole] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kantory]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kantory](
	[id_kantory] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_kantory] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[papierosy]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[papierosy](
	[id_papierosy] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_papierosy] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[paliwa]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[paliwa](
	[id_paliwa] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_paliwa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kursy]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kursy](
	[id_kursy] [int] IDENTITY(1,1) NOT NULL,
	[id_kantory] [int] NOT NULL,
	[id_waluty] [int] NOT NULL,
	[kurs] [numeric](10, 3) NOT NULL,
	[data] [datetime] NOT NULL,
	[aktualne] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_kursy] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stacje_benzynowe]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stacje_benzynowe](
	[id_stacje_benzynowe] [int] IDENTITY(1,1) NOT NULL,
	[id_przejscia] [int] NOT NULL,
	[nazwa] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_stacje_benzynowe] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sklepy]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sklepy](
	[id_sklepy] [int] IDENTITY(1,1) NOT NULL,
	[id_przejscia] [int] NOT NULL,
	[nazwa] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_sklepy] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[uaktualnienia_kursy]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uaktualnienia_kursy](
	[id_uaktualnienia_kursy] [int] IDENTITY(1,1) NOT NULL,
	[id_kantory] [int] NOT NULL,
	[id_uzytkownicy] [int] NOT NULL,
	[kurs] [numeric](10, 3) NOT NULL,
	[data] [datetime] NOT NULL,
	[zrealizowano] [int] NOT NULL,
	[odrzucono] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_uaktualnienia_kursy] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zmiany]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[zmiany](
	[id_zmiany] [int] IDENTITY(1,1) NOT NULL,
	[id_przejscia] [int] NOT NULL,
	[nazwa] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_zmiany] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[wyjazdy]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wyjazdy](
	[id_wyjazdy] [int] IDENTITY(1,1) NOT NULL,
	[id_uzytkownicy] [int] NOT NULL,
	[id_przejscia] [int] NOT NULL,
	[id_stacje_benzynowe] [int] NOT NULL,
	[id_paliwa] [int] NOT NULL,
	[ilosc_paliwa] [numeric](10, 2) NOT NULL,
	[id_alkohole] [int] NULL,
	[id_sklepy_alkohole] [int] NULL,
	[ilosc_alkoholu] [numeric](10, 1) NULL,
	[id_papierosy] [int] NULL,
	[id_sklepy_papierosy] [int] NULL,
	[ilosc_papierosow] [int] NULL,
	[data] [date] NOT NULL,
	[godzina] [time](7) NOT NULL,
	[kanal] [int] NOT NULL,
	[mandat] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_wyjazdy] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uaktualnienia_alkohol]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uaktualnienia_alkohol](
	[id_uaktualnienia_alkohol] [int] IDENTITY(1,1) NOT NULL,
	[id_przejscia] [int] NOT NULL,
	[id_alkohole] [int] NOT NULL,
	[id_sklepy] [int] NOT NULL,
	[id_uzytkownicy] [int] NOT NULL,
	[cena] [decimal](10, 0) NOT NULL,
	[data] [datetime] NOT NULL,
	[zrealizowano] [int] NOT NULL,
	[odrzucono] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_uaktualnienia_alkohol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uaktualnienia_papierosy]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uaktualnienia_papierosy](
	[id_uaktualnienia_papierosy] [int] IDENTITY(1,1) NOT NULL,
	[id_przejscia] [int] NOT NULL,
	[id_papierosy] [int] NOT NULL,
	[id_sklepy] [int] NOT NULL,
	[id_uzytkownicy] [int] NOT NULL,
	[cena] [decimal](10, 0) NOT NULL,
	[data] [datetime] NOT NULL,
	[zrealizowano] [int] NOT NULL,
	[odrzucono] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_uaktualnienia_papierosy] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uaktualnienia_paliwo]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uaktualnienia_paliwo](
	[id_uaktualnienia_paliwo] [int] IDENTITY(1,1) NOT NULL,
	[id_przejscia] [int] NOT NULL,
	[id_paliwa] [int] NOT NULL,
	[id_stacje_benzynowe] [int] NOT NULL,
	[id_uzytkownicy] [int] NOT NULL,
	[cena] [decimal](10, 0) NOT NULL,
	[data] [datetime] NOT NULL,
	[zrealizowano] [int] NOT NULL,
	[odrzucono] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_uaktualnienia_paliwo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[papierosy_ceny]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[papierosy_ceny](
	[id_papierosy_ceny] [int] IDENTITY(1,1) NOT NULL,
	[id_papierosy] [int] NOT NULL,
	[id_przejscia] [int] NOT NULL,
	[id_sklepy] [int] NOT NULL,
	[cena_paczka] [decimal](10, 2) NULL,
	[cena_pakiet] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_papierosy_ceny] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[paliwo_ceny]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paliwo_ceny](
	[id_paliwo_ceny] [int] IDENTITY(1,1) NOT NULL,
	[id_paliwa] [int] NOT NULL,
	[id_stacje_benzynowe] [int] NOT NULL,
	[cena] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_paliwo_ceny] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cykl_zmian]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cykl_zmian](
	[id_cykl_zmian] [int] IDENTITY(1,1) NOT NULL,
	[data_poczatkowa] [date] NULL,
	[id_zmiany] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cykl_zmian] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[alkohol_ceny]    Script Date: 01/18/2015 22:59:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alkohol_ceny](
	[id_alkohol_ceny] [int] IDENTITY(1,1) NOT NULL,
	[id_alkohole] [int] NOT NULL,
	[id_przejscia] [int] NOT NULL,
	[id_sklepy] [int] NOT NULL,
	[cena] [decimal](10, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_alkohol_ceny] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF__uzytkowni__ostat__1BFD2C07]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uzytkownicy] ADD  DEFAULT (NULL) FOR [ostatnie_logowanie]
GO
/****** Object:  Default [DF__uzytkowni__statu__1CF15040]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uzytkownicy] ADD  DEFAULT ('0') FOR [status]
GO
/****** Object:  Default [DF__kursy__data__03317E3D]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[kursy] ADD  DEFAULT (getdate()) FOR [data]
GO
/****** Object:  Default [DF__uaktualni__zreal__108B795B]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_kursy] ADD  DEFAULT ('0') FOR [zrealizowano]
GO
/****** Object:  Default [DF__uaktualni__odrzu__117F9D94]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_kursy] ADD  DEFAULT ('0') FOR [odrzucono]
GO
/****** Object:  Default [DF__wyjazdy__id_alko__1FCDBCEB]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy] ADD  DEFAULT (NULL) FOR [id_alkohole]
GO
/****** Object:  Default [DF__wyjazdy__id_skle__20C1E124]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy] ADD  DEFAULT (NULL) FOR [id_sklepy_alkohole]
GO
/****** Object:  Default [DF__wyjazdy__ilosc_a__21B6055D]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy] ADD  DEFAULT (NULL) FOR [ilosc_alkoholu]
GO
/****** Object:  Default [DF__wyjazdy__id_papi__22AA2996]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy] ADD  DEFAULT (NULL) FOR [id_papierosy]
GO
/****** Object:  Default [DF__wyjazdy__id_skle__239E4DCF]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy] ADD  DEFAULT (NULL) FOR [id_sklepy_papierosy]
GO
/****** Object:  Default [DF__wyjazdy__ilosc_p__24927208]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy] ADD  DEFAULT (NULL) FOR [ilosc_papierosow]
GO
/****** Object:  Default [DF__wyjazdy__kanal__25869641]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy] ADD  DEFAULT ('0') FOR [kanal]
GO
/****** Object:  Default [DF__wyjazdy__mandat__267ABA7A]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy] ADD  DEFAULT ('0') FOR [mandat]
GO
/****** Object:  Default [DF__uaktualni__zreal__0DAF0CB0]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_alkohol] ADD  DEFAULT ('0') FOR [zrealizowano]
GO
/****** Object:  Default [DF__uaktualni__odrzu__0EA330E9]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_alkohol] ADD  DEFAULT ('0') FOR [odrzucono]
GO
/****** Object:  Default [DF__uaktualni__zreal__164452B1]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_papierosy] ADD  DEFAULT ('0') FOR [zrealizowano]
GO
/****** Object:  Default [DF__uaktualni__odrzu__173876EA]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_papierosy] ADD  DEFAULT ('0') FOR [odrzucono]
GO
/****** Object:  Default [DF__uaktualni__zreal__1367E606]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_paliwo] ADD  DEFAULT ('0') FOR [zrealizowano]
GO
/****** Object:  Default [DF__uaktualni__odrzu__145C0A3F]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_paliwo] ADD  DEFAULT ('0') FOR [odrzucono]
GO
/****** Object:  Default [DF__papierosy__cena___07F6335A]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[papierosy_ceny] ADD  DEFAULT (NULL) FOR [cena_paczka]
GO
/****** Object:  Default [DF__papierosy__cena___08EA5793]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[papierosy_ceny] ADD  DEFAULT (NULL) FOR [cena_pakiet]
GO
/****** Object:  Default [DF__cykl_zmia__data___00551192]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[cykl_zmian] ADD  DEFAULT (NULL) FOR [data_poczatkowa]
GO
/****** Object:  ForeignKey [fk_kursy__kantory]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[kursy]  WITH CHECK ADD  CONSTRAINT [fk_kursy__kantory] FOREIGN KEY([id_kantory])
REFERENCES [dbo].[kantory] ([id_kantory])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[kursy] CHECK CONSTRAINT [fk_kursy__kantory]
GO
/****** Object:  ForeignKey [fk_kursy__waluty]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[kursy]  WITH CHECK ADD  CONSTRAINT [fk_kursy__waluty] FOREIGN KEY([id_waluty])
REFERENCES [dbo].[waluty] ([id_waluty])
GO
ALTER TABLE [dbo].[kursy] CHECK CONSTRAINT [fk_kursy__waluty]
GO
/****** Object:  ForeignKey [fk_stacje_benzynowe__przejscia]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[stacje_benzynowe]  WITH CHECK ADD  CONSTRAINT [fk_stacje_benzynowe__przejscia] FOREIGN KEY([id_przejscia])
REFERENCES [dbo].[przejscia] ([id_przejscia])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[stacje_benzynowe] CHECK CONSTRAINT [fk_stacje_benzynowe__przejscia]
GO
/****** Object:  ForeignKey [fk_sklepy__przejscia]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[sklepy]  WITH CHECK ADD  CONSTRAINT [fk_sklepy__przejscia] FOREIGN KEY([id_przejscia])
REFERENCES [dbo].[przejscia] ([id_przejscia])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sklepy] CHECK CONSTRAINT [fk_sklepy__przejscia]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_kursy__kantory]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_kursy]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_kursy__kantory] FOREIGN KEY([id_kantory])
REFERENCES [dbo].[kantory] ([id_kantory])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[uaktualnienia_kursy] CHECK CONSTRAINT [fk_uaktualnienia_kursy__kantory]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_kursy__uzytkownicy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_kursy]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_kursy__uzytkownicy] FOREIGN KEY([id_uzytkownicy])
REFERENCES [dbo].[uzytkownicy] ([id_uzytkownicy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[uaktualnienia_kursy] CHECK CONSTRAINT [fk_uaktualnienia_kursy__uzytkownicy]
GO
/****** Object:  ForeignKey [fk_zmiany__przejscia]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[zmiany]  WITH CHECK ADD  CONSTRAINT [fk_zmiany__przejscia] FOREIGN KEY([id_przejscia])
REFERENCES [dbo].[przejscia] ([id_przejscia])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[zmiany] CHECK CONSTRAINT [fk_zmiany__przejscia]
GO
/****** Object:  ForeignKey [fk_wyjazdy__alkohole]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy]  WITH CHECK ADD  CONSTRAINT [fk_wyjazdy__alkohole] FOREIGN KEY([id_alkohole])
REFERENCES [dbo].[alkohole] ([id_alkohole])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[wyjazdy] CHECK CONSTRAINT [fk_wyjazdy__alkohole]
GO
/****** Object:  ForeignKey [fk_wyjazdy__paliwa]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy]  WITH CHECK ADD  CONSTRAINT [fk_wyjazdy__paliwa] FOREIGN KEY([id_paliwa])
REFERENCES [dbo].[paliwa] ([id_paliwa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[wyjazdy] CHECK CONSTRAINT [fk_wyjazdy__paliwa]
GO
/****** Object:  ForeignKey [fk_wyjazdy__papierosy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy]  WITH CHECK ADD  CONSTRAINT [fk_wyjazdy__papierosy] FOREIGN KEY([id_papierosy])
REFERENCES [dbo].[papierosy] ([id_papierosy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[wyjazdy] CHECK CONSTRAINT [fk_wyjazdy__papierosy]
GO
/****** Object:  ForeignKey [fk_wyjazdy__przejscia]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy]  WITH CHECK ADD  CONSTRAINT [fk_wyjazdy__przejscia] FOREIGN KEY([id_przejscia])
REFERENCES [dbo].[przejscia] ([id_przejscia])
GO
ALTER TABLE [dbo].[wyjazdy] CHECK CONSTRAINT [fk_wyjazdy__przejscia]
GO
/****** Object:  ForeignKey [fk_wyjazdy__sklepy_alkohole]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy]  WITH CHECK ADD  CONSTRAINT [fk_wyjazdy__sklepy_alkohole] FOREIGN KEY([id_sklepy_alkohole])
REFERENCES [dbo].[sklepy] ([id_sklepy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[wyjazdy] CHECK CONSTRAINT [fk_wyjazdy__sklepy_alkohole]
GO
/****** Object:  ForeignKey [fk_wyjazdy__sklepy_papierosy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy]  WITH CHECK ADD  CONSTRAINT [fk_wyjazdy__sklepy_papierosy] FOREIGN KEY([id_sklepy_papierosy])
REFERENCES [dbo].[sklepy] ([id_sklepy])
GO
ALTER TABLE [dbo].[wyjazdy] CHECK CONSTRAINT [fk_wyjazdy__sklepy_papierosy]
GO
/****** Object:  ForeignKey [fk_wyjazdy__stacje_benzynowe]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy]  WITH CHECK ADD  CONSTRAINT [fk_wyjazdy__stacje_benzynowe] FOREIGN KEY([id_stacje_benzynowe])
REFERENCES [dbo].[stacje_benzynowe] ([id_stacje_benzynowe])
GO
ALTER TABLE [dbo].[wyjazdy] CHECK CONSTRAINT [fk_wyjazdy__stacje_benzynowe]
GO
/****** Object:  ForeignKey [fk_wyjazdy__uzytkownicy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[wyjazdy]  WITH CHECK ADD  CONSTRAINT [fk_wyjazdy__uzytkownicy] FOREIGN KEY([id_uzytkownicy])
REFERENCES [dbo].[uzytkownicy] ([id_uzytkownicy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[wyjazdy] CHECK CONSTRAINT [fk_wyjazdy__uzytkownicy]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_alkohol__alkohole]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_alkohol]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_alkohol__alkohole] FOREIGN KEY([id_alkohole])
REFERENCES [dbo].[alkohole] ([id_alkohole])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[uaktualnienia_alkohol] CHECK CONSTRAINT [fk_uaktualnienia_alkohol__alkohole]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_alkohol__przejscia]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_alkohol]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_alkohol__przejscia] FOREIGN KEY([id_przejscia])
REFERENCES [dbo].[przejscia] ([id_przejscia])
GO
ALTER TABLE [dbo].[uaktualnienia_alkohol] CHECK CONSTRAINT [fk_uaktualnienia_alkohol__przejscia]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_alkohol__sklepy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_alkohol]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_alkohol__sklepy] FOREIGN KEY([id_sklepy])
REFERENCES [dbo].[sklepy] ([id_sklepy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[uaktualnienia_alkohol] CHECK CONSTRAINT [fk_uaktualnienia_alkohol__sklepy]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_alkohol__uzytkownicy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_alkohol]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_alkohol__uzytkownicy] FOREIGN KEY([id_uzytkownicy])
REFERENCES [dbo].[uzytkownicy] ([id_uzytkownicy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[uaktualnienia_alkohol] CHECK CONSTRAINT [fk_uaktualnienia_alkohol__uzytkownicy]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_papierosy__papierosy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_papierosy]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_papierosy__papierosy] FOREIGN KEY([id_papierosy])
REFERENCES [dbo].[papierosy] ([id_papierosy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[uaktualnienia_papierosy] CHECK CONSTRAINT [fk_uaktualnienia_papierosy__papierosy]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_papierosy__przejscia]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_papierosy]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_papierosy__przejscia] FOREIGN KEY([id_przejscia])
REFERENCES [dbo].[przejscia] ([id_przejscia])
GO
ALTER TABLE [dbo].[uaktualnienia_papierosy] CHECK CONSTRAINT [fk_uaktualnienia_papierosy__przejscia]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_papierosy__sklepy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_papierosy]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_papierosy__sklepy] FOREIGN KEY([id_sklepy])
REFERENCES [dbo].[sklepy] ([id_sklepy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[uaktualnienia_papierosy] CHECK CONSTRAINT [fk_uaktualnienia_papierosy__sklepy]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_papierosy__uzytkownicy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_papierosy]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_papierosy__uzytkownicy] FOREIGN KEY([id_uzytkownicy])
REFERENCES [dbo].[uzytkownicy] ([id_uzytkownicy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[uaktualnienia_papierosy] CHECK CONSTRAINT [fk_uaktualnienia_papierosy__uzytkownicy]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_paliwo__paliwa]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_paliwo]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_paliwo__paliwa] FOREIGN KEY([id_paliwa])
REFERENCES [dbo].[paliwa] ([id_paliwa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[uaktualnienia_paliwo] CHECK CONSTRAINT [fk_uaktualnienia_paliwo__paliwa]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_paliwo__przejscia]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_paliwo]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_paliwo__przejscia] FOREIGN KEY([id_przejscia])
REFERENCES [dbo].[przejscia] ([id_przejscia])
GO
ALTER TABLE [dbo].[uaktualnienia_paliwo] CHECK CONSTRAINT [fk_uaktualnienia_paliwo__przejscia]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_paliwo__stacje_benzynowe]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_paliwo]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_paliwo__stacje_benzynowe] FOREIGN KEY([id_stacje_benzynowe])
REFERENCES [dbo].[stacje_benzynowe] ([id_stacje_benzynowe])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[uaktualnienia_paliwo] CHECK CONSTRAINT [fk_uaktualnienia_paliwo__stacje_benzynowe]
GO
/****** Object:  ForeignKey [fk_uaktualnienia_paliwo__uzytkownicy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[uaktualnienia_paliwo]  WITH CHECK ADD  CONSTRAINT [fk_uaktualnienia_paliwo__uzytkownicy] FOREIGN KEY([id_uzytkownicy])
REFERENCES [dbo].[uzytkownicy] ([id_uzytkownicy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[uaktualnienia_paliwo] CHECK CONSTRAINT [fk_uaktualnienia_paliwo__uzytkownicy]
GO
/****** Object:  ForeignKey [fk_papierosy_ceny__papierosy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[papierosy_ceny]  WITH CHECK ADD  CONSTRAINT [fk_papierosy_ceny__papierosy] FOREIGN KEY([id_papierosy])
REFERENCES [dbo].[papierosy] ([id_papierosy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[papierosy_ceny] CHECK CONSTRAINT [fk_papierosy_ceny__papierosy]
GO
/****** Object:  ForeignKey [fk_papierosy_ceny__przejscia]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[papierosy_ceny]  WITH CHECK ADD  CONSTRAINT [fk_papierosy_ceny__przejscia] FOREIGN KEY([id_przejscia])
REFERENCES [dbo].[przejscia] ([id_przejscia])
GO
ALTER TABLE [dbo].[papierosy_ceny] CHECK CONSTRAINT [fk_papierosy_ceny__przejscia]
GO
/****** Object:  ForeignKey [fk_papierosy_ceny__sklepy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[papierosy_ceny]  WITH CHECK ADD  CONSTRAINT [fk_papierosy_ceny__sklepy] FOREIGN KEY([id_sklepy])
REFERENCES [dbo].[sklepy] ([id_sklepy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[papierosy_ceny] CHECK CONSTRAINT [fk_papierosy_ceny__sklepy]
GO
/****** Object:  ForeignKey [fk_paliwo_ceny__paliwa]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[paliwo_ceny]  WITH CHECK ADD  CONSTRAINT [fk_paliwo_ceny__paliwa] FOREIGN KEY([id_paliwa])
REFERENCES [dbo].[paliwa] ([id_paliwa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[paliwo_ceny] CHECK CONSTRAINT [fk_paliwo_ceny__paliwa]
GO
/****** Object:  ForeignKey [fk_paliwo_ceny__stacje_benzynowe]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[paliwo_ceny]  WITH CHECK ADD  CONSTRAINT [fk_paliwo_ceny__stacje_benzynowe] FOREIGN KEY([id_stacje_benzynowe])
REFERENCES [dbo].[stacje_benzynowe] ([id_stacje_benzynowe])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[paliwo_ceny] CHECK CONSTRAINT [fk_paliwo_ceny__stacje_benzynowe]
GO
/****** Object:  ForeignKey [id_cykl_zmian__zmiany]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[cykl_zmian]  WITH CHECK ADD  CONSTRAINT [id_cykl_zmian__zmiany] FOREIGN KEY([id_zmiany])
REFERENCES [dbo].[zmiany] ([id_zmiany])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[cykl_zmian] CHECK CONSTRAINT [id_cykl_zmian__zmiany]
GO
/****** Object:  ForeignKey [fk_alkohol_ceny__alkohole]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[alkohol_ceny]  WITH CHECK ADD  CONSTRAINT [fk_alkohol_ceny__alkohole] FOREIGN KEY([id_alkohole])
REFERENCES [dbo].[alkohole] ([id_alkohole])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[alkohol_ceny] CHECK CONSTRAINT [fk_alkohol_ceny__alkohole]
GO
/****** Object:  ForeignKey [fk_alkohol_ceny__przejscia]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[alkohol_ceny]  WITH CHECK ADD  CONSTRAINT [fk_alkohol_ceny__przejscia] FOREIGN KEY([id_przejscia])
REFERENCES [dbo].[przejscia] ([id_przejscia])
GO
ALTER TABLE [dbo].[alkohol_ceny] CHECK CONSTRAINT [fk_alkohol_ceny__przejscia]
GO
/****** Object:  ForeignKey [fk_alkohol_ceny__sklepy]    Script Date: 01/18/2015 22:59:45 ******/
ALTER TABLE [dbo].[alkohol_ceny]  WITH CHECK ADD  CONSTRAINT [fk_alkohol_ceny__sklepy] FOREIGN KEY([id_sklepy])
REFERENCES [dbo].[sklepy] ([id_sklepy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[alkohol_ceny] CHECK CONSTRAINT [fk_alkohol_ceny__sklepy]
GO
