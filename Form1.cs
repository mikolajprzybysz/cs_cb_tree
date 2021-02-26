using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;    // Add a reference to Microsoft.VisualBasic.

namespace CBTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private BTree<Person> m_Tree = new BTree<Person>();

        // Add a Person.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Person per = new Person(txtSsn.Text, txtFirstName.Text, txtLastName.Text);

                if (per.FirstName.Length == 0) per.FirstName = "first" + per.SSN;
                if (per.LastName.Length == 0) per.LastName = "last" + per.SSN;

                m_Tree.AddItem(per.SSN, per);

                lstPeople.Items.Clear();
                m_Tree.AddToListBox(lstPeople);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtSsn.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtSsn.Focus();
        }

        // Add some random Persons.
        private void btnRandom_Click(object sender, EventArgs e)
        {
            string num_str = Interaction.InputBox("# Persons:", "# Persons", "", -1, -1);
            if (num_str.Length == 0) return;

            for (int i = 1; i <= int.Parse(num_str); i++)
            {
                Person per = new Person();
                m_Tree.AddItem(per.SSN, per);
            }

            lstPeople.Items.Clear();
            m_Tree.AddToListBox(lstPeople);
            txtSsn.Focus();
        }

        // Find the Person with the given SSN.
        private void btnFind_Click(object sender, EventArgs e)
        {
            Person per = m_Tree.FindItem(txtSsn.Text);
            if (per == null)
            {
                MessageBox.Show("This person isn't in the tree", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else {
                MessageBox.Show(per.SSN + "\n" + per.FirstName + "\n" + per.LastName,
                    per.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtSsn.Focus();
        }

        // Remove the Person with the given SSN.
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                m_Tree.RemoveItem(txtSsn.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            txtSsn.Clear();
            lstPeople.Items.Clear();
            m_Tree.AddToListBox(lstPeople);
            txtSsn.Focus();
        }

        // Find the selected Person and copy the SSN into the SSN text box.
        private void lstPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSsn.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();

            if (lstPeople.SelectedIndex < 0) return;
            string txt = lstPeople.SelectedItem.ToString().Trim();
            txtSsn.Text = txt.Split(new char[]{':'})[0].Trim();
        }
    }
}