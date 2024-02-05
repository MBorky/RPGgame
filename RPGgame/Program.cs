using GameEngine;
using GameEngine.Fight;
using GameEngine.Eq;
// See https://aka.ms/new-console-template for more information
// Primitive obsession
// Value object
// Atrybuty zamienic na klase - statystyki wrzucic do klasy jednej
// Rozdzielic character od profession, character ma przetrzymywc profession
// Character ma byc koordynacja wewnetrznych obiektow
// klasa perki ma koordynowac dostep do perkow uzalezniony od dupereli
TeamManager teamManager = new ();
Console.Write(teamManager.ShowTeamInfo());
WorldLevel worldLevel = new();

GameEngine.Fight.PrepareFight preparedFight = new(teamManager.Players, worldLevel.Level);
BattleResult result;
NewItemCreator itemCreator = new(worldLevel, teamManager.Players);
do 
{
    result = preparedFight.StartFight();
    if (result.BattleSuccess)
    {
        worldLevel.WorldLevelUp();
    }
} while (result.BattleSuccess);


// Obserwator, do zmiany świata
