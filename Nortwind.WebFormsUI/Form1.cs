using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nortwind.Business.Abstract;
using Nortwind.Business.Concrete;
using Nortwind.DataAccess.Concrete.EntityFramework;

namespace Nortwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private IProductService _productService = new ProductManager(new EfProductDal());
        private ICategoryService _categoryService = new CategoryManager(new EfCateegoryDal());

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgvProducts.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                dgvProducts.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch 
            {
               
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbxSearch.Text))
            {
                LoadProducts();
            }
            else
            {
                dgvProducts.DataSource = _productService.GetProductsByProductName(tbxSearch.Text);
            }
        }
    }
}
