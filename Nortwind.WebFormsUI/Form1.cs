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
using Nortwind.Entities.Concrete;

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

            cbxCategoryControl.DataSource = _categoryService.GetAll();
            cbxCategoryControl.DisplayMember = "CategoryName";
            cbxCategoryControl.ValueMember = "CategoryId";
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

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvProducts.CurrentRow.Cells[0].Value.ToString();
            tbxProductName.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            cbxCategoryControl.SelectedValue = dgvProducts.CurrentRow.Cells[1].Value;
            tbxUnitPrice.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
            tbxQuantityPerUnit.Text = dgvProducts.CurrentRow.Cells[4].Value.ToString();
            tbxStockAmount.Text = dgvProducts.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productService.Add(new Product
            {
                ProductName = tbxProductName.Text,
                CategoryId = Convert.ToInt32(cbxCategoryControl.SelectedValue),
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                QuantityPerUnit = tbxQuantityPerUnit.Text,
                UnitsInStock = Convert.ToInt16(tbxStockAmount.Text)
            });
            LoadProducts();
            ControlsClear();
        }

        void ControlsClear()
        {
            tbxProductName.Clear();
            tbxQuantityPerUnit.Clear();
            tbxStockAmount.Clear();
            txtId.Clear();
            tbxSearch.Clear();
            tbxUnitPrice.Clear();
            cbxCategoryControl.SelectedIndex = 0;
            cbxCategory.SelectedIndex = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId = Convert.ToInt32(txtId.Text),
                CategoryId = Convert.ToInt32(cbxCategoryControl.SelectedValue),
                ProductName = tbxProductName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                QuantityPerUnit = tbxQuantityPerUnit.Text,
                UnitsInStock = Convert.ToInt16(tbxStockAmount.Text)
                
            });
            ControlsClear();
            LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                _productService.Delete(new Product
                {
                    ProductId = Convert.ToInt32(txtId.Text)
                });
                ControlsClear();
                LoadProducts();
            }
           
        }

        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            FrmCategory frmCategory = new FrmCategory();
            frmCategory.Show();
        }
    }
}
