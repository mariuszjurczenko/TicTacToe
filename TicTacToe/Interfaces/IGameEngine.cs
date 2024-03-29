﻿namespace TicTacToe.Interfaces;

public interface IGameEngine
{
    IPlayer CurrentPlayer { get; }
    IBoard Board { get; }
    bool IsGameRunning { get; }
    IGameStatistics Statistics { get; }

    void InitializePlayers();
    void WhoPlayerStartsFirst();
    void SwitchPlayer();
    bool CheckForWinner();
    bool CheckForTie();
    void InitializeBoard();
    void MakeMove(int row, int column);
    bool IsCurrentPlayerAI();
    void MakeAIMove();
    void SetGameRunning(bool isRunning);
    void PrintBoard();
    bool IsFieldEmpty(int row, int column);
}
