using Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screens {
    class OnboardScreen : UserInterface {
        void UserInterface.render()
        {
            Console.WriteLine("Chuong trinh quan ly san pham");
            Console.WriteLine("1. Xem danh sach san pham");
            Console.WriteLine("0. Thoat");
        }

        ScreenName UserInterface.selected(int option)
        {
            switch (option)
            {
                case 1:
                    {
                        return ScreenName.PRODUCT_SCREEN;
                    }
                default: Console.WriteLine("Khong co tinh nang nay"); return ScreenName.ONBOARD;
            }
        }
    }
}
