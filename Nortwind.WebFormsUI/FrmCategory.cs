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
    public partial class FrmCategory : Form
    {
        private ICategoryService _categoryService;
        public FrmCategory()
        {
            InitializeComponent();
            _categoryService = new CategoryManager(new EfCateegoryDal());
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxCategoryId.Text = dgvCategories.CurrentRow.Cells[0].Value.ToString();
            tbxCategoryName.Text = dgvCategories.CurrentRow.Cells[1].Value.ToString();
            tbxDescription.Text = dgvCategories.CurrentRow.Cells[2].Value.ToString();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            dgvCategories.DataSource = _categoryService.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _categoryService.Add(new Category
            {
                CategoryName = tbxCategoryName.Text,
                Description = tbxDescription.Text
            });
            ControlsClear();
            LoadCategories();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _categoryService.Update(new Category
            {
                CategoryId = Convert.ToInt32(tbxCategoryId.Text),
                CategoryName = tbxCategoryName.Text,
                Description = tbxDescription.Text
            });
            ControlsClear();
            LoadCategories();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _categoryService.Delete(new Category
            {
                CategoryId = Convert.ToInt32(tbxCategoryId.Text)
            });
            ControlsClear();
            LoadCategories();
        }

        void ControlsClear()
        {
            tbxCategoryName.Clear();
            tbxDescription.Clear();
            tbxDescription.Clear();
        }
    }
}
