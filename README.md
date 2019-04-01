#Prérequis
*Vusual Studio Code
* .Net Core SDK

#Préparation de la structure de la solution
* `mkdir Isen.DotNet`
* cd isen.dotnet
* `git init`
* `touch .gitignore` (ou le créer depuis VS) puis reccupéréer un gitignore spécifique à .Net Core
* Créer le repository sur git puis l'ajouter en temps que remote `git remote add origin https://github.com/Kirlia83/IsenCsharp.git`
* `git add .`
* `git commit -m "initial commit"`
* `git push origin master`

Créer un projet Console, dans un sous-dossier src:
* Créer le dossier src/ et naviguer dedans
* Dans le dossier src, créer Isen.DotNet.ConsoleApp et naviguer dedans
* Créer le projet ConsoleApp: `dotnet new console`

Créer le fichier solution
* Naviguer vers la racine du projet
* Créer le fichier .sln : `dotnet new sln`
* Ajouter les différents éléménts de la solution à ce projet (projet console + readme + gitignore):
** `dotnet sln add src/Isen.DotNet.ConsoleApp/`

Creer un dossier src/Isen.DotNet.Library et naviguer dedans.
Avecl la CLI .Net (dont l'interface en ligne de commande, que l'on utilise depuis le début), créer un projet de type 'librairie de classe':
`dotnet new classlib`
Référencer ce nouveau projet dans le fichier solution (.sln).
Depuis la racine : `dotnet sln add src/Isen.DotNet.Library`

Ajouter le projet Library comme référence du projet ConsoleApp.
* Naviguer dans le dossei du projet console
* `dotnet add reference ../Isen.DotNet.Library` 

# C#
Supprimer la classe autogénérée (ClassC1)

#Tests unitaires
* A la racine de la solution, créer un dossier `tests`et un sous-dossier `Isen.DotNet.Library.Tests`
* Naviguer vers ce dossier
* `dotnet new xunit`
* Ajouter ce projet au sln. Depuis la racine : `dotnet sln add tests/Isen.DotNet.Library.Tests`
* Revenir dans le dossier de projet tests
* Référencer le projet Library dans le projet de test : `dotnet add reference ../../src/Isen.DotNet.Library`
* Renommer la classe générée automatiquement dans le projet de test et l'appeler 'MyCollectionTests'
* Coder un test de la méthode Add
* Executer les test
* Coder les accesseurs indexeurs
* Coder les tests de Count et Index

#Refractoring de la class MyCollection en générique
* Réécriture de la classe MyCollection qui devient générique
* Modification de MyCollection en MyCollection<string>()
* Renommer MyCollectionTest.cs en MyCollectionStringTest.cs et renommer la classe de la même façon.
* Duppliquer MyCollectionStringTest en MyCollectionCharTest et adapter le code de test en conséquence

#Implémentation de l'interface IList<T>
* Indiquer l'implémentation de l'héritage
Utilise l'ampoule Omnnisharp pour générer le using manquant

#Modele City
Créer dans Models une class City avec Id Name ZipCode.
Dans person ajouter champ BornIn de type City

#Refactoring
Deplacer Id et Name vers une class de base abstraite : 'BaseModel'.

Faire dériver City et Person de BaseModel.
Noter les champs Id et Name comme des override de BaseModel