using System;

namespace Factory
{

    class Weapon { }
    
    class DragonSword : Weapon { }
    class SpikedShield : Weapon { }

    class RedDragonSword : DragonSword { }
    class GreenDragonSword : DragonSword { }

    class RedSpikedShield: SpikedShield { }
    class GreenSpikedShield : SpikedShield { }

    class MagicStick : Weapon { }

    class RedMagicStick: MagicStick { }
    class GreenMagicStick : MagicStick { }

    class YellowMagicStick: MagicStick { }
    class YellowSpikedShield : SpikedShield { }
    class YellowDragonSword : DragonSword { }



    class Program
    {
        static void Main()
        {
           
        }
    }
}
