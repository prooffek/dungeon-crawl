# Dungeon Crawl (sprint 2)

## Story

Last week you created a pretty good [Roguelike](https://en.wikipedia.org/wiki/Roguelike) game. It already has some features but the players have no opportunity to save their games. It can be annoying especially when you have to leave the game aside suddenly.

The gamer community bragging for saving functionality and some other new interesting ideas like:

- sharing game with each other
- maps of different sizes
- player tracking camera movement

The management is handing out a **prioritized list** of new user stories that should be appended to the unfinished stories from last week in your product backlog. Try to estimate these new stories as well, and based on the estimations pick the stories your team can finish in this sprint.

> Using database for saving game state feature is a business critical item which overrides every other priority now!

Let's continue this entertaining project, and make our players happier!

## What are you going to learn?

- Serialization of objects
- Communicating with database
- Writing unit tests for your classes
- Design pattern: **Data Access Object**

## Tasks

1. Create a new sprint from the existing backlog. Last week you had a long list of stories, a few new stories this week.
    - The new items are added to the backlog
    - The team has created a new sprint plan based upon the unified backlog
    - The mandatory "Saving game" backlog item is in Sprint 2 and planned in detail

2. As you will work in a new repository but you need the code from the previous sprint, add the `dungeon-crawl-2` repository as a new remote to the previous sprint's repository, then pull (merge) and push your changes into it.
    - There is a merge commit in the project's repository that contains code from the previous sprint

3. Allow the user to save the current state of the game in a database. Extend the given schema if needed.
    - The application uses SQL Server database with the given schema: `schema_ddl.sql`
    - The application respects the `MSSQL_USER_NAME`, `MSSQL_PASSWORD`, `MSSQL_DB_NAME` environment variables
    - Students has an Entity Relationship diagram (connections between classes, 1-1, 1-many...) in a digitalized format.
    - When the user hits `F5` key, the game is saves the current state (current map, player's position and content of the inventory) in the database, overwriting the old game state (if exists within the database). In the screen's corner, a UI text displays "Game saved." for 5 seconds.
    - Already discovered maps are also saved in DB.
    - When the user hits `F9`, the game loads the previously saved state (map, position and inventory). After loading, in the screen's corner, a UI text displays "Game loaded." for 5 seconds. 

4. Allow the user to export (serialize) his game state into a text file, and load (deserialize) the game from the exported file.
    - Pressing `F10` triggers the export mechanism.
    - The exporting process creates the exported file in the `exported_saves` subfolder in the game's main directory. The file's name is generated with the following pattern: `<game-name>_<save's-date-and-hour>.json`
    - The file stores every necessary game state information in JSON format.
    - Pressing `F11` imports the last exported game (it selects the file based on the date and hour in the file's name). If the chosen file isn't in proper format, the game displays a message "IMPORT ERROR!" on UI, in the screen's corner.

5. The customer seeks for quality assurance and wants to see that your code is covered by unit tests. It is important that beyond positive test cases also cover negative scenarios.
    - Every unit test method is well arranged and follows the `arrange`-`act`-`assert` structure
    - Unit test classes and methods follow these naming conventions consistently:
- classes: `<The name of the tested class>Test`
- methods: `<the name of the tested method>_<expected input / tested state>_<expected behavior>`
    - Every test class has at least one negative test case (and more if it's plausible)
    - Code coverage of self-created business logic classes is above 90%

## General requirements

None

## Hints

- Break the backlog items into smaller tasks so that you can work in parallel
- The given DB schema is only an example. Probably you need to alter is according to the requirements. For instance it doesn't contain any info about inventory or discovered maps by the player
- Write as many unit tests as possible to cover your business logic
- If a method takes a reference type parameter there should be test for getting `null` as an argument. It is called negative test cases.
- You can read easily an environment variable's value: `System.GetEnvironmentVariable("VAR_NAME");`
- How to view and edit environment variables in [Visual Studio](https://www.tutorialsteacher.com/core/aspnet-core-environment-variable) and in [Rider](https://blog.jetbrains.com/dotnet/2017/08/23/rundebug-configurations-rider/)


## Background materials

- <i class="far fa-exclamation"></i> [Software testing](project/curriculum/materials/pages/general/software-testing.md)
- <i class="far fa-book-open"></i> [Positive or negative](https://stackoverflow.com/questions/8162423)
- <i class="far fa-exclamation"></i> [How to design classes](project/curriculum/materials/pages/csharp/how-to-design-classes.md)
- <i class="far fa-book-open"></i> [Unity Documentaton](https://docs.unity3d.com/Manual/index.html)
- <i class="far fa-exclamation"></i> [SQL in Visual Studio and CRUD operations](https://alexcodetuts.com/2019/04/26/how-to-connect-sql-server-database-using-c-and-perform-crud-operation-part-1/)
- <i class="far fa-exclamation"></i> [Obtaining data through SQL DataReader](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/retrieving-data-using-a-datareader)
- <i class="far fa-exclamation"></i> [JSON.NET](https://www.newtonsoft.com/json)
- [1-Bit Pack by Kenney](https://kenney.nl/assets/bit-pack)
