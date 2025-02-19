using UnityEngine;

namespace Enities
{
    public class SpaceShip : Entity
    {
        private void Awake()
        {
            EntityName = "Player Ship";
            Speed = 10f;
            Health = 100;
            Score = 0;
        }

    }
}