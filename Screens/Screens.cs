using Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screens
{
    public enum ScreenName
    {
        ONBOARD,
        PRODUCT_SCREEN
    }

    public interface UserInterface
    {
        void render();
        ScreenName selected(int option);
    }
}
