using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtRaces
{
    class Guy
    {
        public int cashAsset;
        public string name;
        public decimal stake;
        public decimal betOnDog;
         
        /*public bool EnoughCash(decimal betMoney)
        {
            if ((betMoney > cashAsset) || (cashAsset <5)) return false;
            else return true; 
        }*/
        public void Collect(bool isWin)
        {
            if (isWin) cashAsset = cashAsset + 2 * (int)stake;
            else cashAsset = cashAsset - (int)stake;

        }
        public void PlaceBet(decimal money, decimal dog)
        {
            if ((money > cashAsset) || (cashAsset < 5))
                MessageBox.Show(name + ", you don't have enough menoy to bet!");
            else stake = money;
            betOnDog = dog;
        }
    }
}
