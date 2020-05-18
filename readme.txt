Vorgangsweise Klausurvorbereitung Azure: 
========================================

Es soll eine WebApi und eine FunctionApplication erzeugt werden. 

WebApp: 
=======
1.) Erzeugen einer leeren WebApplication
2.) Löschen der vorhandenen Controller und der WeatherForecase Model-Klasse
3.) Erzeugen aller Model-Klassen im Models-Ordner (Comment, SocialMediaPost, CosmosDb)
	Für die CosmosDB werden die Daten abgeändert (steht in Angabe, deswegen eigenes Model)
	Für die "geringfügige Umformung" werden lediglich die Feldnamen geändert auf + db (Comments-Klasse bleibt aufgrund der Einfachheit gleich)
4.) Erzeugen eines leeren Api-Controllers (SocialMediaPostController)
5.) Ändern der Route (nicht api/SocialMediaPost sonddern /socialmedia). 
6.) Anlegen eines Storage Accounts und Sichern des Connection-Strings in appsettings
7.) INstallieren der NugetPackages Microsoft.Azure.Storage.Common, Microsoft.Azure.Storage.Queue
8.) Implementieren der Post-Methode


==== Ab hier dann Kurz die Functions-Application implementieren

Functions: 
==========
1.) Erzeugen einer neuen "Azure Functions" Applikation (gleich mit QueueTrigger)
2.) ApplicationSettings (local.settings.json) um Connection-Strings erweitern
3.) Model Klassen SocialMediaPost und Comment in die Applikation kopieren (für Deserialisierung)
4.) Installieren des NugetPackages Microsoft.Azure.WebJobs.Extensions.CosmosDB
5.) Implementieren der Methode (Daten etwas ändern und in CosmosDb schreiben). 


==== Ab hier wieder weiter bei der WebApp

Es sollen noch 2 Gets implementiert werden....einmal für einzelne IDs und einmal mit einem parameter
9.) Installieren des NugetPackages Microsoft.Azure.Cosmos
10.) Erzeugen einer DatabaseReader-Klasse
11.) Methoden für einzelne Abfrage implementieren
12.) Controller-Methode Get implementieren
13.) Schritt 11 und 12 für mehrere Posts (Wenn beispielsweise Topic übergeben wird)
