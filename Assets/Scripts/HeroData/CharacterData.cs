using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class CharacterData
    {
        public enum CharacterName { LAMBERT, VESEMIR, ESKEL, GERALT, YENNEFER, TRISS, CIRI, KEIRA, SHANI,
        ZOLTAN};

        public enum Boss
        {
            IMLERITH, EREDIN, RADOVID_V, DETLAFF, GAUNTER_O_DIMM, CARETAKER, OLGIERD, VILGEFORTZ, ORIANNA,
            UNSEEN_ELDER
        };

        public enum LockedState { UNLOCKED, LOCKED};

        public enum SelectedState { UNSELECTED, SELECTED};



        public float maxHealth;
        public float currentHealth;
        public float attackPower;
        public int level;
        public float experiencePoints;

    }
}

