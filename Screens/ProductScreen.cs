using Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Screens {
    interface ProductAction {
        List<ProductData> getProducts();
        int findIndex(string id);
        bool add(ProductData data);
        bool edit(ProductData data, string id);
        bool remove(string id);
    }
    class ProductScreen : UserInterface {
        public required ProductAction action;
        public void render()
        {
            header();
            foreach (ProductData product in action.getProducts())
            {
                row(product);
            }

            Console.WriteLine("===========");
            Console.WriteLine("Chuc nang: ");
            Console.WriteLine("1. Them san pham");
            Console.WriteLine("2. Sua san pham");
            Console.WriteLine("3. Xoa san pham");
            Console.WriteLine("4. Tinh thue");
            Console.WriteLine("0. Thoat");
        }

        private void header()
        {
            Console.Write("Id");
            Console.Write("\t|\t");
            Console.Write("Name");
            Console.Write("\t|\t");
            Console.Write("Type");
            Console.Write("\t|\t");
            Console.Write("Price");
            Console.Write("\t|\t");
            Console.Write("Quantity");
            Console.Write("\t|\t");
            Console.Write("Total");
            Console.WriteLine();
        }

        private void row(ProductData product)
        {
            Console.Write(product.id);
            Console.Write("\t|\t");
            Console.Write(product.name);
            Console.Write("\t|\t");
            Console.Write(product.type.getName());
            Console.Write("\t|\t");
            Console.Write(product.price);
            Console.Write("\t|\t");
            Console.Write(product.quantity);
            Console.Write("\t\t|\t");
            Console.Write((product.type.getTax() + 100) * product.price * product.quantity);
            Console.WriteLine();
        }

        public ScreenName selected(int option)
        {
            switch (option)
            {
                case 1:
                    {
                        addProduct();
                        break;
                    }
                case 2:
                    {
                        editProduct();
                        break;
                    }
                case 3:
                    {
                        deleteProduct();
                        break;
                    }
                default: Console.WriteLine("Khong co tinh nang nay"); break;
            }
            return ScreenName.PRODUCT_SCREEN;
        }

        private void inputProductDetail(ProductData data)
        {
            Console.WriteLine("Ten san pham: ");
            data.name = Console.ReadLine();
            Console.WriteLine("Gia san pham: ");
            data.price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("So luong san pham: ");
            data.quantity = Convert.ToInt32(Console.ReadLine());

            int option = -1;
            while (option != 1 && option != 2)
            {
                Console.WriteLine("Loai san pham: ");
                Console.WriteLine("1. L0: ");
                Console.WriteLine("2. L1: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1: data.type = new BaseType(); return;
                    case 2: data.type = new TypeOne(); return;
                    default: Console.WriteLine("Loai san pham khong chinh xac"); break;
                }
            }
        }

        private void addProduct()
        {
            ProductData data = new ProductData();
            Console.WriteLine("Nhap thong tin san pham");
            Console.WriteLine("Ma san pham: ");
            data.id = Console.ReadLine();
            inputProductDetail(data);

            action.add(data);
            Console.WriteLine("Them thanh cong");

            Thread.Sleep(1000);
        }

        private void editProduct()
        {
            ProductData data = new ProductData();
            Console.WriteLine("Nhap ma san pham can sua: ");
            string inputId = Console.ReadLine();
            if (action.findIndex(inputId) == -1)
            {
                Console.WriteLine("Khong co san pham nao co ma " + inputId);
            } else
            {
                inputProductDetail(data);
                action.edit(data, inputId);
                Console.WriteLine("Sua thanh cong");
            }

            Thread.Sleep(1000);
        }

        private void deleteProduct()
        {
            Console.WriteLine("Nhap ma san pham can xoa: ");
            string inputId = Console.ReadLine();

            if (action.remove(inputId))
            {
                Console.WriteLine("Xoa thanh cong");
            } else
            {
                Console.WriteLine("Khong co san pham nao co ma " + inputId);
            }

            Thread.Sleep(1000);
        }
    }
}
