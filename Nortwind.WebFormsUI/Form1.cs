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

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvProducts.DataSource = _productService.GetAll();
        }
    }
}
