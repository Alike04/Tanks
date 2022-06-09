using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private List<Player.Player> _players;
        private Map.Map _map;
        private int _playerCount;
        private List<Player.Player> _activePlayers;
        private int _activePlayerCount;
        public static GameManager Instance;
        public event Action OnStart;
        public event Action OnStop;
        private void Awake()
        {
            Instance = this;
        }
        public void SetPlayers(int number)
        {
            _playerCount = number;
        }
        public Transform[] GetPlayersPosition()
        {
            return _activePlayers.Select(x => x.transform).ToArray();
        }
        public void StartGame()
        {
            for (int i = 0; i < _playerCount; i++)
            {
                var player = _players[i];
                Instantiate(player, _map.Points[i]);
                player.OnDie += PlayerDie;
                player.OnDie += () => { _activePlayers.Remove(player); };
            }
            OnStart?.Invoke();
        }
        private void PlayerDie()
        {
            _activePlayerCount--;
            if (_activePlayerCount == 1)
            {
                StopGame();
            }
        }
        private void StopGame()
        {
            SetWinner(_activePlayers[0]);
            OnStop?.Invoke();
        }
        private void SetWinner(Player.Player player)
        {
            Debug.Log("player " + player.Number + " is won");
        }

    }
}

