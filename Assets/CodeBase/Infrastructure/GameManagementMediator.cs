﻿using System;
using UnityEngine;

public class GameManagementMediator : IDisposable
{
    private GameManagement _gameManagement;
    private GameOverPanel _gameOverPanel;
    private Character _character;

    public GameManagementMediator(GameOverPanel gameOverPanel, Character character, GameManagement gameManagement)
    {
        _gameManagement = gameManagement;
        _gameOverPanel = gameOverPanel;
        _character = character;

        _gameOverPanel.RestartButtonClicked += OnRestartButtonClicked;
        _gameOverPanel.ExitButtonClicked += OnExitButtonClicked;

        _character.Died += OnCharacterDied;
    }

    public void Dispose()
    {
        _gameOverPanel.RestartButtonClicked -= OnRestartButtonClicked;
        _gameOverPanel.ExitButtonClicked -= OnExitButtonClicked;

        _character.Died -= OnCharacterDied;
    }

    private void OnCharacterDied()
    {
        _gameOverPanel.Show();
        _gameManagement.EndGame();
    }

    private void OnExitButtonClicked()
    {
        _gameManagement.ExitGame();
    }

    private void OnRestartButtonClicked()
    {
        _gameOverPanel.Hide();
        _gameManagement.RestartGame();
    }
}
