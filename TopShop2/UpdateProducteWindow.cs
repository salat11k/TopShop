﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopShop.Repository;
using TopShop2.Models;

namespace TopShop2
{
    public partial class UpdateProducteWindow : Form
    {
        private IRepository<Product> _repository;

        public UpdateProducteWindow(IRepository<Product> repository)
        {
            InitializeComponent();

            _repository = repository;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _repository.Update(new Product() {Title = textBox1.Text, Price = (int)numericUpDown2.Value},(int)numericUpDown1.Value);
            Close();
        }
    }
}
