// Viết chương trình quản lý sản phẩm với các chức năng
// Xem danh sách sản phẩm
// Thêm sản phẩm
// Sửa tên/giá sản phẩm
// Xóa sản phẩm
// Tính thuế dựa theo công thức: 5% trên giá + thuế đặc biệt tùy loại

// Sản phẩm sẽ có cấu trúc như sau:
// Mã sản phẩm
// Tên sảnh phẩm
// Loại: L0: chỉ tính thuế cơ bản; L1 thuế đặc biệt 5%
// Giá sản phẩm
// Số lượng

using Screens;
using Product;

namespace Buoi5
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            ProductData productData = new ProductData();
            productData.id = "1";
            productData.name = "A";
            productData.type = new TypeOne();
            productData.price = 50;
            productData.quantity = 960;
            productManager.add(productData);

            ScreenController screenController = new ScreenController() {
                iScreenAction = new OnboardScreen(),
                productManager = productManager
            };
            while (true)
            {
                screenController.render();
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 0)
                {
                    return;
                }
                screenController.selected(option);
            }
        }
    }

    class ScreenController
    {
        public ScreenName currentScreen { get; set; }

        public required UserInterface iScreenAction;
        public required ProductManager productManager;
        public ScreenController()
        {
            currentScreen = ScreenName.ONBOARD;
        }

        public void navigate(ScreenName screenName)
        {
            switch(screenName)
            {
                case ScreenName.PRODUCT_SCREEN:
                    {

                        iScreenAction = new ProductScreen() {
                            action = productManager
                        };
                        
                        break;
                    }
                default: Console.WriteLine("Khong co tinh nang nay"); break;
            }
        }

        public void render()
        {
            Console.Clear();
            iScreenAction.render();
        }

        public void selected(int option)
        {
            navigate(iScreenAction.selected(option));
        }
    }
}