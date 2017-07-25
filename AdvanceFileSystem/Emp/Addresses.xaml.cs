using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using AdvanceFileSystem.Models;

namespace AdvanceFileSystem.Emp
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Addresses : UserControl
    {
        //List<Address> addresses;

        //ننشئ هذا المتغير من الكلاس يلي سويناها
        //هذا المتغير بمثل الداتا بيس بشكل عام
        private DatabaseContext db = new DatabaseContext();

        public Addresses()
        {
            InitializeComponent();
            FillAddresses();
        }
        

        //إضافة عنوان جديد
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //بما انه اضافة لازم اول شي ناخذ المعلومات يلي ادخلها المستخدم
            string address = addressBox.Text;
            //ننشء اوبجكت جديد من النوع يلي بدنا نضيفه
            Address adress = new Address();

            //وضعنا الاسم يلي اخذناه من الانبت للاوبجكت
            adress.Name = address;

            //نتحقق انه صح ولا لا
            if(adress.IsValid)
            {
                //من متغير الداتا بيس بدنا العناوين ونضيف عليها العنوان الجديد
                db.Addersses.Add(adress);
                //نحفظ التغيرات الي سويناها "الاضافة"
                db.SaveChanges();

                //بيمسح محتوى الصندوق
                addressBox.Clear();

                //بيعيد ملئ العنواين من الداتا بيس
                FillAddresses();
            }
            else
            {
                //اذا مش صحيح الاوبجكت بيظهر الخطا تبعه
                MessageBox.Show(adress.Error);
            }
           // short id = (short)Connection.InsertAddress(address);
            
            //FillAddresses();
        }

        //ملئ الجدول بالعناوين
        private void FillAddresses ()
        {
            //addresses = Connection.GetAddresses();
            //addresstable.ItemsSource = addresses;

            //ندخل الى الجدول يلي سويناها
            //سميناه addresstable
            //من خاصية الاitemsource 
            //نضعها من الداتا بيس العنواين وطبعا نحولها لليست
            addresstable.ItemsSource = db.Addersses.ToList();
        }

        //هذا الفنكشن لما نضغط عالخلية بالجدول مرتين
        //عشان يظهر العنوان بالتكست بوكس
        private void addresstable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //بياخذ العنوان من الجدول
            Address address = (Address)addresstable.SelectedItem;

            //بيتحقق انه ضغط على عنوان صح
            if(address != null)
            {
                //بيخفي زر الاضافة
                addButton.Visibility = Visibility.Hidden;
                //وبيظهر زر التعديل
                saveButton.Visibility = Visibility.Visible;

                //بيضع داخل التكست بوكس النص من الجدول
                addressBox.Text = address.Name;
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            //يقوم بحذف الاختيار من الجدول
            addresstable.SelectedIndex = -1;

            //اظهار زر الاضافة
            addButton.Visibility = Visibility.Visible;

            //اخفاء زر الحفظ
            saveButton.Visibility = Visibility.Hidden;

            //يمسح ما في داخل صندوق الادرس
            addressBox.Clear();
        }

        //حفظ التغيرات
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //بياخذ العنوان من الجدول
            Address address = (Address)addresstable.SelectedItem;

            //بيضع قيمة الاسم يلي اخذناها من الجدول ونضعها بالتكست بوكس
            address.Name = addressBox.Text;

            //Connection.UpdateAddress(add);

            //بيحفظ التغيرات
            db.SaveChanges();

            //بيمسح النص الموجود بالتكست بوكس
            addressBox.Clear();

            //بيعيد ملئ العناوين من الداتا بيس
            FillAddresses();
        }
    }
}
