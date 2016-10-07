﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmhand.API.Monsters
{
    public class Monster
    {
        public static Dictionary<string, MonsterInformation> Monsters { get; } = new Dictionary<string, MonsterInformation>();

        public static void RegisterMonster(MonsterInformation monsterInformation)
        {
            Monsters[monsterInformation.Name] = monsterInformation;
        }
    }
}
