using GameEngine;
using GameEngine.Fight;
// See https://aka.ms/new-console-template for more information
// Primitive obsession
// Value object
// Atrybuty zamienic na klase - statystyki wrzucic do klasy jednej
// Rozdzielic character od profession, character ma przetrzymywc profession
// Character ma byc koordynacja wewnetrznych obiektow
// klasa perki ma koordynowac dostep do perkow uzalezniony od dupereli
TeamManager teamManager = new ();
Console.Write(teamManager.ShowTeamInfo());
int worldLevel = 1;

GameEngine.Fight.PrepareFight preparedFight = new(teamManager.Players, worldLevel);
BattleResult result;
do 
{
    result = preparedFight.StartFight();
    if (result.BattleSuccess)
    {
        worldLevel++;
    }
} while (result.BattleSuccess);


// Obserwator, do zmiany świata



