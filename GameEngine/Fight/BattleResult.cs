using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Fight
{
    public class BattleResult
    {
        public event Action? CreateItems;
        private bool _battleSucess;
        //tutaj event
        public bool BattleSuccess 
        {
            get { return _battleSucess; }
            set { _battleSucess = value;
                if (value)
                {
                    CreateItems?.Invoke();
                }
            } 
        }
    }
}
